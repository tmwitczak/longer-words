// //////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                else
                {
                    command += c;
                }

                if (c == ' ')
                {
                    if (mode == Mode.Locate)
                    {
                        mode = Mode.Move;
                    }
                    else if (mode == Mode.Attack) {
                        player.Attack(target);
                        mode = Mode.Move;
                        command = "";
                    }
                }
            }
        }

        else if (mode == Mode.Move)
        {
            command = "";
            if (Input.GetKey(keyUp))
            {
                player.Move(Time.deltaTime * Vector3.forward);
            }
            if (Input.GetKey(keyDown))
            {
                player.Move(Time.deltaTime * Vector3.back);
            }
            if (Input.GetKey(keyLeft))
            {
                player.Move(Time.deltaTime * Vector3.left);
            }
            if (Input.GetKey(keyRight))
            {
                player.Move(Time.deltaTime * Vector3.right);
            }

            foreach (char c in Input.inputString)
            {
                if (c == ' ')
                {
                    mode = Mode.Locate;
                }
            }
        }

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
    }

    void spawnEnemies()
    {
        for (int i = 0; i < waveNumber + 4; i++)
        {
            enemyManager.SpawnEnemyAtRandomLocation(waveNumber);
        }
    }

    public enum Mode
    {
        Move, Locate, Attack
    }

    public
    Mode mode = Mode.Move;

    public
    string command;

    private int waveNumber = 0;

    [SerializeField] public CommandManager commandManager;
    [SerializeField] public EnemyManager enemyManager;
    [SerializeField] public InputManager inputManager;
    [SerializeField] public Player player;

    [SerializeField] public string keyUp;
    [SerializeField] public string keyDown;
    [SerializeField] public string keyLeft;
    [SerializeField] public string keyRight;
}
