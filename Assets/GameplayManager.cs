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
            if (c == '\b') {
                if (command.Length > 0) {
                    command = command.Substring(0, command.Length - 1);
                }
                if (command.Length == 0) {
                    emptyWord = true;
                }
            }
            else if (c != ' ') {
                if (mode == Mode.MoveAndLocate && c >= '0' && c <= '9') {
                    if (currentCommand.Length < 2) {
                        command += c;
                    }
                }
                else if(mode == Mode.Attack) {
                    // print (currentCommand.Length);
                    // print( target.GetComponent<Enemy>().currentCommand.Length);
                    if (currentCommand.Length <
                        target.GetComponent<Enemy>().currentCommand.Length) {
                        command += c;
                    }
                }
            }
            if (c == ' ' || Input.GetKey(KeyCode.Return)) {
                if (mode == Mode.Attack) {
                    if (!emptyWord) {
                        // player.Attack(target.GetComponent<Enemy>().getAveragePosition());
                    }
                    mode = Mode.MoveAndLocate;
                    command = "";
                }
            }
        }
        if (mode == Mode.Attack && allWordCorrect) {
            if (!emptyWord) {
                player.Attack(target.GetComponent<Enemy>().getAveragePosition());
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
        // if (mode == Mode.MoveAndLocate) {
        //     tutorialText.text += "Use <b>WASD</b> or <b>Arrow</b> keys to move\nEnter chosen enemy's number to locate him";
        // }
        // if (mode == Mode.Attack) {
        //     tutorialText.text += "Enter chosen enemy's word to attack him\nPress <b>Space</b> or <b>Enter</b> to attack whenever you want to\n\n<i>(correctly typed letters induce damage,\nincorrectly typed ones - regenerate enemy's health</i>)";
        // }
        tutorialText.transform.position = new Vector3(1920 / 2 + 50, 1080 - 575, 0);
        tutorialText.color = new Color(0.97f, 0.95f, 0.91f);
    }
    void spawnEnemies() {
        switch(waveNumber) {
            case 0:
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 1, 1, 0);
                break;
            case 1:
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 1, 1, 100);
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 1, 1, 100);
                break;
            case 2:
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 2, 1, 1, 200);
                break;
            case 3:
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 2, 1, 50);
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 2, 1, 50);
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 1, 1, 400);
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 1, 1, 400);
                break;
            case 4:
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 2, 2, 2, 400);
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 2, 1, 400);
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 2, 1, 400);
                break;
            case 5:
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 3, 3, 3, 600);
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 1, 1, 600);
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 1, 1, 600);
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 1, 1, 600);
                enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 1, 1, 600);
                break;
            default:
                for (int i = 0; i < waveNumber; i++) {
                    enemyManager.SpawnEnemyAtRandomLocation(waveNumber, 1, 1, 1, 0);
                }
                break;
        }
    }
    void spawnPowerUps()
    {
        if (GameObject.Find("FreezePowerUp(Clone)") == null && GameObject.Find("SpeedPowerUp(Clone)") == null && GameObject.Find("HealthPowerUp(Clone)") == null)
        {
            powerUpManager.SpawnPowerUpAtRandomLocation(1);
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
