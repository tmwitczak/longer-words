// //////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ///////////////////////////////////// Class: CommandManager //
public
class CommandManager
        : MonoBehaviour
{
    // ================================== Public interface < ==//
    // -------------------------------------- Behaviour << --==//
    public class Commands
    {
        public string locate;
        public string attack;
    }

    public
    Commands register(Enemy gameObject)
    {
        Commands commands = new Commands();

        // Generate LOCATE command
        commands.locate += locateSymbol;
        for (int i = 0; i < 2; i++)
        {
            commands.locate += (char)('0' + Random.Range(0, 10));
        }

        // Generate ATTACK command
        commands.attack += attackSymbol;
        for (int i = 0; i < 10; i++)
        {
            commands.attack += (char)('a' + Random.Range(0, 26));
        }

        // Register Enemy object
        // TODO:

        return commands;
    }

    public
    void release(Enemy gameObject) {
        //todo:
    }

    public enum CommandType
    {
        Locate, Attack
    }

    // ------------------------------------------- Data << --==//

    // .............. Accessible from Unity's editor <<< ..--==//
    [SerializeField] public GameObject uiTextPrefab;

    // ============================ Private implementation < ==//
    // -------------------------------------- Behaviour << --==//
    // .............................. Initialization <<< ..--==//
    private void Awake()
    {
        locateSymbol = "";
        attackSymbol = "";
    }


    void Start()
    {
    }

    bool commandMode = false;

    void Update()
    {
        // if (Input.GetKey(locateSymbol)) {
        //     commandMode = true;
        // }

        // if ()
    }

    // ................................. Update loop <<< ..--==//

    // ------------------------------------------- Data << --==//
    public string locateSymbol = "";
    public string attackSymbol = "";

    // .................................. Components <<< ..--==//
}

// /////////////////////////////////////////////////////////// //