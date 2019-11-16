// ////////////////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// ////////////////////////////////////////////// Class: GameplayManager //
public class GameplayManager : MonoBehaviour {
    // ============================================ Public interface < ==//
    // ------------------------------------------------ Behaviour << --==//
    public void enemyTargeted(GameObject e) {
        target = e;
        command = "";
        mode = Mode.Attack;
    }
    public void enemyKilled() {
        command = "";
        mode = Mode.MoveAndLocate;
    }
    public string currentCommand {
        get => command;
        set { command = value; }
    }
    public enum Mode {
        MoveAndLocate, Attack
    }
    // ====================================== Private implementation < ==//
    // ------------------------------------------------ Behaviour << --==//
    // ........................................ Initialization <<< ..--==//
    private void Start() {
        waveText = Instantiate(uiTextPrefab,
                new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Text>();
        waveText.transform.parent = GameObject.Find("Canvas").transform;

        tutorialText = Instantiate(uiTextPrefabSmall,
                new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Text>();
        tutorialText.transform.parent = GameObject.Find("Canvas").transform;
    }
    // ........................................... Update loop <<< ..--==//
    private void Update() {
        // ''''''''''''''''''''''''''''''''''''''''''''''''' Start the wave
        if (!enemyManager.areThereAnyEnemies()) {
            spawnEnemies();
            spawnPowerUps();
            waveNumber++;
        }
        // '''''''''''''''''''''''''''''''''''''''''''''''''''''' Get input
        foreach (char c in Input.inputString) {
            if (c == '\b' && command.Length != 0) {
                command = command.Substring(0, command.Length - 1);
            }
            else if (c != ' ') {
                if ((mode == Mode.MoveAndLocate && c >= '0' && c <= '9')
                || mode == Mode.Attack) {
                    command += c;
                }
            }
            if (c == ' ' || Input.GetKey(KeyCode.Return)) {
                if (mode == Mode.Attack) {
                    if (!emptyWord) {
                        player.Attack(target.transform);
                    }
                    mode = Mode.MoveAndLocate;
                    command = "";
                }
            }
        }
        if (mode == Mode.Attack && allWordCorrect) {
            if (!emptyWord) {
                player.Attack(target.transform);
            }
            mode = Mode.MoveAndLocate;
            command = "";
            allWordCorrect = false;
        }
        else if (mode == Mode.MoveAndLocate) {
            Vector3 direction = Vector3.zero;

            if (Input.GetAxis("Vertical") > 0) {
                direction += Vector3.forward;
            }
            if (Input.GetAxis("Vertical") < 0) {
                direction += Vector3.back;
            }
            if (Input.GetAxis("Horizontal") < 0) {
                direction += Vector3.left;
            }
            if (Input.GetAxis("Horizontal") > 0) {
                direction += Vector3.right;
            }
            player.Move(Time.deltaTime * direction.normalized);
        }
        // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' UI
        waveText.text = "Level " + waveNumber.ToString();
        if (mode == Mode.MoveAndLocate) {
            waveText.text += " <i>| Move and locate</i>"; 
        }
        if (mode == Mode.Attack) {
            waveText.text += " <i>| Attack</i>";
        }
        waveText.transform.position = new Vector3(1920 / 2 + 50, 50, 0);
        waveText.color = new Color(0.97f, 0.95f, 0.91f);

        tutorialText.text = "";
        if (mode == Mode.MoveAndLocate) {
            tutorialText.text += "Use <b>WASD</b> or <b>Arrow</b> keys to move\nEnter chosen enemy's number to locate him";
        }
        if (mode == Mode.Attack) {
            tutorialText.text += "Enter chosen enemy's word to attack him\nPress <b>Space</b> or <b>Enter</b> to attack whenever you want to\n\n<i>(correctly typed letters induce damage,\nincorrectly typed ones - regenerate enemy's health</i>)";
        }
        tutorialText.transform.position = new Vector3(1920 / 2 + 50, 1080 - 575, 0);
        tutorialText.color = new Color(0.97f, 0.95f, 0.91f);
    }
    void spawnEnemies() {
        for (int i = 0; i < waveNumber + 1; i++) {
            enemyManager.SpawnEnemyAtRandomLocation(waveNumber);
        }
    }
    void spawnPowerUps()
    {
        for (int i = 0; i < waveNumber + 1; i++)
        {
            powerUpManager.SpawnPowerUpAtRandomLocation(waveNumber);
        }
    }

    // ............................................ Parameters <<< ..--==//
    [SerializeField] private GameObject uiTextPrefab;
    [SerializeField] private GameObject uiTextPrefabSmall;
    [SerializeField] private CommandManager commandManager;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private PowerUpManager powerUpManager;
    [SerializeField] private Player player;
    // ................................................. Other <<< ..--==//
    public bool allWordCorrect = false;
    public bool emptyWord = false;

    public Mode mode = Mode.MoveAndLocate;

    public string command;

    private int waveNumber = 0;
    private Text waveText;

    private Text tutorialText;
    public GameObject target;

}
// ///////////////////////////////////////////////////////////////////// //
