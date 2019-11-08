// ////////////////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ///////////////////////////////////////////////// Class: EnemyManager //
public class EnemyManager : MonoBehaviour {
    // ============================================ Public interface < ==//
    // ------------------------------------------------ Behaviour << --==//
    public void SpawnEnemyAtRandomLocation(int wave) {
        // Set ranges
        const float rangeMin = 5.5f;
        const float rangeMax = 7.5f;

        Vector3 randomLocation =
            Quaternion.Euler(0, Random.Range(0, 360), 0)
            * (Random.Range(rangeMin, rangeMax)
               * Vector3.forward
               + new Vector3(0, 0.5f, 0));

        GameObject enemy = Instantiate(enemyPrefab,
                        GameObject.Find("Player").transform.position + randomLocation,
                        Quaternion.identity);
        enemy.GetComponent<Enemy>().health = 100.0f + 25.0f * Random.Range(0, wave);
        enemy.GetComponent<Enemy>().velocity = 1500 + wave * 125;
        enemies.Add(enemy);
    }
    public bool areThereAnyEnemies()
            => (GameObject.FindGameObjectsWithTag("Enemy")).Length != 0;
    // ----------------------------------------------------- Data << --==//
    // ............................................ Parameters <<< ..--==//
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject commandManager;
    // ................................................. Other <<< ..--==//
    // TODO: This list doesn't work for now, to be fixed
    List<GameObject> enemies = new List<GameObject>();
}
// ///////////////////////////////////////////////////////////////////// //
