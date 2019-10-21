// //////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ////////////////////////////////////////////// Class: Enemy //
public
class Enemy
        : MonoBehaviour
{
    // ================================== Public interface < ==//
    // -------------------------------------- Behaviour << --==//

    // ============================ Private implementation < ==//
    // -------------------------------------- Behaviour << --==//
    // .............................. Initialization <<< ..--==//
    private
    void Awake()
    {
        SetupReferencesToComponents();
    }

    private
    void SetupReferencesToComponents()
    {
        rigidbody = GetComponent<Rigidbody>();
        light = GetComponentsInChildren<Light>()[0];
    }

    private
    CommandManager.Commands RegisterInCommandManagerAndGetCommands()
        => (commands = commandManager.register(this));

    // .............................. TODO: name this section <<< ..--==//
    private
    void Start()
    {
        SetupReferenceToPlayer();

        SetupReferencesToManagers();
        RegisterInCommandManagerAndGetCommands();

        InstantiateCommandText();
    }

    private
    void SetupReferenceToPlayer()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    private void SetupReferencesToManagers()
    {
        commandManager = GameObject.Find("CommandManager")
            .GetComponent<CommandManager>();
        gameplayManager = GameObject.Find("GameplayManager")
            .GetComponent<GameplayManager>();
    }

    private
    void InstantiateCommandText()
    {
        commandText = Instantiate(uiTextPrefab,
                new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Text>();
        commandText.transform.parent = GameObject.Find("Canvas").transform;
        commandText.text = commands.locate;

        healthUI = Instantiate(uiTextPrefabSmall,
                new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Text>();
        healthUI.transform.parent = GameObject.Find("Canvas").transform;
        healthUI.text = health.ToString();
    }

    // .............................. Destruction <<< ..--==//
    private
    void OnDestroy()
    {
        gameplayManager.enemyKilled();
        commandManager.release(this);
    }

    // ................................. Update loop <<< ..--==//
    void Update()
    {
        bool destroy = true;

        // Check and update command UI
        string currentCommand = "";
        if (gameplayManager.mode == GameplayManager.Mode.Locate)
        {
            currentCommand = commands.locate;
        }
        if (gameplayManager.mode == GameplayManager.Mode.Attack)
        {
            currentCommand = commands.attack;
        }

        List<bool> letterStatus = new List<bool>(new bool[currentCommand.Length]);
        for (int i = 0; i < gameplayManager.currentCommand.Length; i++)
        {
            if (currentCommand[i] == gameplayManager.currentCommand[i])
            {
                letterStatus[i] = true;
            }
            else
            {
                letterStatus[i] = false;
            }
        }
        commandText.text = "";
        light.intensity = 0;
        if (gameplayManager.mode != GameplayManager.Mode.Move)
        {
            correctLetters = 0;
            notcorrectletters = 0;
        }
        for (int i = 0; i < currentCommand.Length; i++)
        {
            commandText.text += "<color=";
            if (letterStatus[i])
            {
                commandText.text += "#747E80";
                light.intensity += 0.25f;
                correctLetters++;
            }
            else
            {
                if (i > gameplayManager.currentCommand.Length - 1)
                {
                    commandText.text += "#f7f3e8";
                }
                else
                {
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
        Vector3 uiPos = Camera.main.WorldToScreenPoint(this.transform.position);
        commandText.transform.position = uiPos + new Vector3(0, 0, 1);
        healthUI.transform.position = uiPos + new Vector3(0, 50, 0);
        healthUI.color = new Color(0.95f, 0.35f, 0.24f);

        if (destroy)
        {
            if (gameplayManager.mode == GameplayManager.Mode.Locate)
            {
                gameplayManager.enemyTargeted(gameObject);
            }
            else if (gameplayManager.mode == GameplayManager.Mode.Attack)
            {
                // Destroy(commandText);
                // Destroy(gameObject);
            }
        }

        if (gameplayManager.mode == GameplayManager.Mode.Move
        || (gameplayManager.mode == GameplayManager.Mode.Attack
            && gameplayManager.target != this.gameObject))
        {
            commandText.text = "";
        }

        healthUI.text = "(" + ((int)health).ToString() + ")";


        if (health <= 0.0f)
        {
            Destroy(commandText);
            Destroy(healthUI);
            Destroy(gameObject);
        }
        else
        {
            GetComponentsInChildren<Light>()[1].intensity = 0.5f * health / 100.0f;
        }
    }

    float correctLetters = 0;
    float notcorrectletters = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            health -= (100 * correctLetters / commands.attack.Length);
            health += (400 * notcorrectletters / commands.attack.Length);
            if (health >= 100) health = 100;
            correctLetters = 0;
            notcorrectletters = 0;
        }
    }


    void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        rigidbody.AddForce(velocity * Time.deltaTime
                           * (player.transform.position
                              - transform.position).normalized);
    }


    // ------------------------------------------- Data << --==//
    // .............. Accessible from Unity's editor <<< ..--==//
    [SerializeField] private GameObject uiTextPrefab;
    [SerializeField] private GameObject uiTextPrefabSmall;
    [SerializeField] public float velocity;

    // .................................. Components <<< ..--==//
    private new Rigidbody rigidbody;

    private GameObject player;
    private Text commandText;
    private Text healthUI;

    private CommandManager.Commands commands;

    CommandManager commandManager;
    GameplayManager gameplayManager;

    Light light;

    public float health = 100.0f;

}

// /////////////////////////////////////////////////////////// //