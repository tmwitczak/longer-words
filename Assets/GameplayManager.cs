// //////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// //////////////////////////////////// Class: GameplayManager //
public
class GameplayManager
        : MonoBehaviour
{
    // ============================ Private implementation < ==//
    // -------------------------------------- Behaviour << --==//
    // .............................. Initialization <<< ..--==//
    private
    void Awake()
    {
    }

    private
    void Start()
    {
        waveText = Instantiate(uiTextPrefab,
                new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Text>();
        waveText.transform.parent = GameObject.Find("Canvas").transform;

        tutorialText = Instantiate(uiTextPrefabSmall,
                new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Text>();
        tutorialText.transform.parent = GameObject.Find("Canvas").transform;
    }

    void Update()
    {
        // Start the wave
        if (!enemyManager.areThereAnyEnemies())
        {
            spawnEnemies();
            waveNumber++;
        }

        // Get input
        if (mode == Mode.Locate || mode == Mode.Attack)
        {
            foreach (char c in Input.inputString)
            {
                if (c == '\b' && command.Length != 0)
                {
                    command = command.Substring(0, command.Length - 1);
                }
                else if (c != ' ')
                {
                    command += c;
                }

                if (c == ' ' || Input.GetKey(KeyCode.Return))
                {
                    if (mode == Mode.Locate)
                    {
                        mode = Mode.Move;
                    }
                    else if (mode == Mode.Attack)
                    {
                        if (!emptyWord)
                        {
                            player.Attack(target);
                        }
                        mode = Mode.Move;
                        command = "";
                    }
                }
            }

            if (mode == Mode.Attack && allWordCorrect) {
                if (!emptyWord)
                {
                    player.Attack(target);
                }
                mode = Mode.Move;
                command = "";
                allWordCorrect = false;
            }
        }

        else if (mode == Mode.Move)
        {
            command = "";
            Vector3 direction = Vector3.zero;

            if (Input.GetAxis("Vertical") > 0)
            {
                direction += Vector3.forward;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                direction += Vector3.back;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                direction += Vector3.left;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                direction += Vector3.right;
            }
            player.Move(Time.deltaTime * direction.normalized);

            foreach (char c in Input.inputString)
            {
                if (c == ' ' || Input.GetKey(KeyCode.Return))
                {
                    mode = Mode.Locate;
                }
            }
        }

        // UI
        waveText.text = "Level " + waveNumber.ToString();
        if (mode == Mode.Move)
        {
            waveText.text += " <i>| Move</i>"; 
        }
        if (mode == Mode.Locate)
        {
            waveText.text += " <i>| Locate</i>";
        }
        if (mode == Mode.Attack)
        {
            waveText.text += " <i>| Attack</i>";
        }
        waveText.transform.position = new Vector3(1920 / 2 + 50, 50, 0);
        waveText.color = new Color(0.97f, 0.95f, 0.91f);

        tutorialText.text = "";
        if (mode == Mode.Move)
        {
            tutorialText.text += "Use <b>WASD</b> or <b>Arrow</b> keys to move\nPress <b>Space</b> to locate the enemy"; 
        }
        if (mode == Mode.Locate)
        {
            tutorialText.text += "Enter chosen enemy's number to locate him\nPress <b>Space</b> to leave and move again"; 
        }
        if (mode == Mode.Attack)
        {
            tutorialText.text += "Enter chosen enemy's word to attack him\nPress <b>Space</b> or <b>Enter</b> to attack whenever you want to\n\n<i>(correctly typed letters induce damage,\nincorrectly typed ones - regenerate enemy's health</i>)";
        }
        tutorialText.transform.position = new Vector3(1920 / 2 + 50, 1080 - 575, 0);
        tutorialText.color = new Color(0.97f, 0.95f, 0.91f);
    }

    public
    GameObject target;

    public void enemyTargeted(GameObject e)
    {
        target = e;
        command = "";
        mode = Mode.Attack;
    }

    public void enemyKilled()
    {
        command = "";
        mode = Mode.Move;
    }

    public string currentCommand
    {
        get => command;
        set { command = value; }
    }

    void spawnEnemies()
    {
        for (int i = 0; i < waveNumber + 1; i++)
        {
            enemyManager.SpawnEnemyAtRandomLocation(waveNumber);
        }
    }

    public enum Mode
    {
        Move, Locate, Attack
    }

    public bool allWordCorrect = false;
    public bool emptyWord = false;

    public
    Mode mode = Mode.Move;

    public
    string command;

    private int waveNumber = 0;
    private Text waveText;

    private Text tutorialText;

    [SerializeField] private GameObject uiTextPrefab;
    [SerializeField] private GameObject uiTextPrefabSmall;

    [SerializeField] public CommandManager commandManager;
    [SerializeField] public EnemyManager enemyManager;
    [SerializeField] public InputManager inputManager;
    [SerializeField] public Player player;

    [SerializeField] public string keyUp;
    [SerializeField] public string keyDown;
    [SerializeField] public string keyLeft;
    [SerializeField] public string keyRight;
}
