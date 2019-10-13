// //////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// /////////////////////////////////////// Class: EnemyManager //
public
class EnemyManager
        : MonoBehaviour
{
    // ================================== Public interface < ==//
    // -------------------------------------- Behaviour << --==//
    public
    void SpawnEnemyAtRandomLocation(int wave)
    {
        // Set ranges
        const float rangeMin = 5;
        const float rangeMax = 10;

        Vector3 randomLocation =
            Quaternion.Euler(0, Random.Range(0, 360), 0)
            * (Random.Range(rangeMin, rangeMax)
               * Vector3.forward
               + new Vector3(0, 0.5f, 0));

        GameObject enemy = Instantiate(enemyPrefab,
                        GameObject.Find("Player").transform.position + randomLocation,
                        Quaternion.identity);
        enemy.GetComponent<Enemy>().velocity = 1500 + wave * 500;
        enemies.Add(enemy);

        // enemies[enemies.Count - 1].command =
        //     commandManager.generateNewCommand(
        //         CommandManager.CommandType.Locate,
        //         enemies[enemies.Count - 1]);
    }

    // ------------------------------------------- Data << --==//
    // .............. Accessible from Unity's editor <<< ..--==//
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public GameObject commandManager;


    public bool areThereAnyEnemies()
    {
        return (GameObject.FindGameObjectsWithTag("Enemy")).Length != 0;
    }


    // Update is called once per frame
    void Update()
    {

    }

    List<GameObject> enemies = new List<GameObject>();
}
