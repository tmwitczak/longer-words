// ////////////////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// //////////////////////////////////////////////////////// Class: Enemy //
[System.Serializable]
public class Enemy : MonoBehaviour {
    // ============================================ Public interface < ==//
    // ------------------------------------------------ Behaviour << --==//
    // ----------------------------------------------------- Data << --==//
    public float velocity;
    private float multiplier = 1.0f;

    int xParts, yParts, zParts;
    // ====================================== Private implementation < ==//
    // ------------------------------------------------ Behaviour << --==//
    // ........................................ Initialization <<< ..--==//

    private void Awake() {
        SetupReferencesToComponents();

        commands = new CommandManager.Commands();
        commands.locate = "";
        commands.attack = "";
    }
    private void SetupReferencesToComponents() {
        rigidbody = GetComponent<Rigidbody>();
        light = GetComponentsInChildren<Light>()[0];
    }
    private CommandManager.Commands RegisterInCommandManagerAndGetCommands()
        => (commands = commandManager.register(this));

    private void Start() {
        SetupReferenceToPlayer();

        SetupReferencesToManagers();
        RegisterInCommandManagerAndGetCommands();

        InstantiateCommandText();
    }
    private void SetupReferenceToPlayer() {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    private void SetupReferencesToManagers() {
        commandManager = GameObject.Find("CommandManager")
            .GetComponent<CommandManager>();
        gameplayManager = GameObject.Find("GameplayManager")
            .GetComponent<GameplayManager>();
    }
    private void InstantiateCommandText()
    {
        commandText = Instantiate(uiTextPrefab,
                new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Text>();
        commandText.transform.parent = GameObject.Find("Canvas").transform;
        commandText.tag = "LocateNumber";
        commandText.text = commands.locate;

        healthUI = Instantiate(uiTextPrefabSmall,
                new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Text>();
        healthUI.transform.parent = GameObject.Find("Canvas").transform;
        healthUI.text = health.ToString();
    }
    public void GenerateParts(int x, int y, int z) {
        xParts = x;
        yParts = y;
        zParts = z;
        float scale = 1.0f;

        for (int i = 0; i < x; ++i) {
            for (int j = 0; j < z; ++j) {
                for (int k = 0; k < y; ++k) {
                    var part = Instantiate(enemyPartPrefab,
                        new Vector3(i * scale, j * scale, k * scale), Quaternion.identity);
                    part.transform.parent = gameObject.transform.Find("Elements").transform;
                    part.transform.localScale = new Vector3(scale, scale, scale);
                    part.transform.localPosition =
                        new Vector3((i - x/2) * scale, ((y - j) - y/2) * scale, (k - z/2) * scale);
                }
            }
        }
    }
    // ........................................... Destruction <<< ..--==//
    private void OnDestroy() {
        gameplayManager.enemyKilled();
        commandManager.release(this);
    }

    // ........................................... Update loop <<< ..--==//
    public string currentCommand = "";

    private void Update() {
        GetComponents<AudioSource>()[0].volume = 
                Mathf.Clamp((rigidbody.velocity.magnitude / 2.0f), 0.0f, 1.0f);

        timeToNextCollision = Mathf.Clamp(timeToNextCollision - Time.deltaTime,
        0.0f, 5.0f);

        bool destroy = true;

        // Check and update command UI
        currentCommand = "";
        if (gameplayManager.mode == GameplayManager.Mode.MoveAndLocate) {
            currentCommand = commands.locate;
        }
        if (gameplayManager.mode == GameplayManager.Mode.Attack) {
            currentCommand = commands.attack;
        }

        List<bool> letterStatus = new List<bool>(new bool[currentCommand.Length]);
        var gameplayCurrentCommand = gameplayManager.currentCommand.Substring(0, Mathf.Min(currentCommand.Length, gameplayManager.currentCommand.Length));
        for (int i = 0; i < gameplayCurrentCommand.Length; i++) {
            if (currentCommand[i] == gameplayCurrentCommand[i]) {
                letterStatus[i] = true;
            }
            else {
                letterStatus[i] = false;
            }
        }

        commandText.text = "";
        light.intensity = 0;

        if (gameplayManager.mode == GameplayManager.Mode.Attack) {
            correctLetters = 0;
            notcorrectletters = 0;
        }

        for (int i = 0; i < currentCommand.Length; i++) {
            commandText.text += "<color=";
            if (letterStatus[i]) {
                commandText.text += "#747E80";
                light.intensity += 0.25f;
                correctLetters++;
            }
            else {
                if (i > gameplayCurrentCommand.Length - 1) {
                    commandText.text += "#f7f3e8";
                }
                else {
                    commandText.text += "#F2583E";
                    light.intensity -= 0.125f;
                    notcorrectletters++;
                }

                destroy = false;
            }
            commandText.text += ">";
            commandText.text += currentCommand[i];
            commandText.text += "</color>";
        }

        if (gameplayManager.mode == GameplayManager.Mode.Attack &&correctLetters == commands.attack.Length) {
            gameplayManager.allWordCorrect = true;
        }

        if (gameplayManager.mode == GameplayManager.Mode.Attack && correctLetters == 0 && notcorrectletters == 0) {
            gameplayManager.emptyWord = true;
        }
        else {
            gameplayManager.emptyWord = false;
        }

        // Render the UI
        Vector3 uiPos = Camera.main.WorldToScreenPoint(getAveragePosition());
        float textWidth = commandText.GetComponent<Text>().preferredWidth;
        float textHeight = commandText.GetComponent<Text>().preferredHeight;
        if(uiPos.x <= textWidth || uiPos.x >= Screen.width - textWidth ||
           uiPos.y <= textHeight || uiPos.y >= Screen.height - textHeight) {
            commandText.text = "...";
            textWidth = commandText.GetComponent<Text>().preferredWidth;
            textHeight = commandText.GetComponent<Text>().preferredHeight;
        }
        uiPos.x = Mathf.Clamp(uiPos.x, textWidth, Screen.width - textWidth);
        uiPos.y = Mathf.Clamp(uiPos.y, textHeight, Screen.height - textHeight);
        commandText.transform.position = uiPos;// + new Vector3(0, 0, 1);

        // healthUI.transform.position = uiPos + new Vector3(0, 50, 0);
        // healthUI.color = new Color(0.95f, 0.35f, 0.24f);

        if (destroy) {
            if (gameplayManager.mode == GameplayManager.Mode.MoveAndLocate) {
                RegisterInCommandManagerAndGetCommands();
                gameplayManager.enemyTargeted(gameObject);
            }
            else if (gameplayManager.mode == GameplayManager.Mode.Attack) {
                // Destroy(commandText);
                // Destroy(gameObject);
            }
        }

        if ((gameplayManager.mode == GameplayManager.Mode.Attack
            && gameplayManager.target != this.gameObject)) {
            commandText.text = "";
        }

        // healthUI.text = "(" + ((int)health).ToString() + ")";

        if (health <= 0.0f) {
            Destroy(commandText);
            Destroy(healthUI);
            Destroy(gameObject);

        }
        else {
            GetComponentsInChildren<Light>()[1].intensity = 0.5f * health / 100.0f;
        }
    }
    float timeToNextCollision = 0.0f;
    private
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Fireball")) {
            if (Mathf.Approximately(timeToNextCollision, 0.0f)) {
                // print(collision.gameObject.name);
                // health -= (100 * correctLetters / commands.attack.Length);
                // health += (400 * notcorrectletters / commands.attack.Length);
                // if (health >= 100) health = 100;
                // correctLetters = 0;
                // notcorrectletters = 0;

                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                List<Transform> parts
                    = new List<Transform>(gameObject.transform.Find("Elements")
                        .GetComponentsInChildren<Transform>());
                parts.RemoveAt(0);
                if(correctLetters == commands.attack.Length) {
                    for (int i = 0; i < parts.Count; i++) {
                        if (parts[i].gameObject.activeSelf) {
                            // parts[i].gameObject.SetActive(false);
                            parts[i].gameObject.transform.parent = null;
                            parts[i].GetComponent<EnemyPart>().scaleDown = true;
                            parts[i].gameObject.AddComponent<Rigidbody>();
                            parts[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 2, 0)+ collision.gameObject.GetComponent<Rigidbody>().velocity.normalized * 5.0f;

                            for (int j = 0; j < parts.Count; j++) {
                                Physics.IgnoreCollision(
                                    parts[i].GetComponentsInChildren<Collider>()[0],
                                    parts[j].GetComponentsInChildren<Collider>()[0]);
                                Physics.IgnoreCollision(
                                    parts[i].GetComponentsInChildren<Collider>()[0],
                                    player.GetComponent<Collider>());
                            }

                            break;
                        }
                    }
                }

                if (gameObject.transform.Find("Elements")
                        .GetComponentsInChildren<Transform>().Length == 1) {
                    health = 0;
                }
                timeToNextCollision = 1.0f;
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
        }
    }
    private
    void FixedUpdate() {
        MoveTowardsPlayer();
    }
    private void MoveTowardsPlayer() {
        rigidbody.AddForce(velocity * multiplier * Time.deltaTime
                           * (player.transform.position
                              - transform.position).normalized) ;
    }

    public void setMultiplier(float value)
    {
        multiplier = value;
    }

    public float getMultiplier()
    {
        return multiplier;
    }

    public float getHealth()
    {
        return health;
    }

    public Vector3 getPosition()
    {
        return this.transform.position;
    }

    public void setPosition(float x, float y, float z)
    {
        this.transform.position = new Vector3(x, y, z);
    }

    public int getXParts()
    {
        return xParts;
    }

    public int getYParts()
    {
        return yParts;
    }

    public int getZParts()
    {
        return zParts;
    }

    public float getCorrectLetters()
    {
        return correctLetters;
    }

    public float getNotCorrectLetters()
    {
        return notcorrectletters;
    }
    // ----------------------------------------------------- Data << --==//
    // ............................................ Parameters <<< ..--==//
    [SerializeField] private GameObject uiTextPrefab;
    [SerializeField] private GameObject uiTextPrefabSmall;
    [SerializeField] private GameObject enemyPartPrefab;

    // ................................................. Other <<< ..--==//
    private new Rigidbody rigidbody;

    private GameObject player;
    private Text commandText;
    private Text healthUI;

    public CommandManager.Commands commands;

    CommandManager commandManager;
    GameplayManager gameplayManager;

    Light light;

    public float health = 100.0f;

    float correctLetters = 0;
    float notcorrectletters = 0;



    public Vector3 getAveragePosition() {
        var a = transform.Find("Elements").GetComponentsInChildren<Transform>();
        Vector3 average = Vector3.zero;
        for (int i = 1; i < a.Length; i++) {
            average += a[i].position;
        }
        average /= (a.Length - 1);
        return average;
    }
}

// /////////////////////////////////////////////////////////// //
