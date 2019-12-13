// ////////////////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ///////////////////////////////////////////////// Class: EnemyManager //
public class EnemyManager : MonoBehaviour {
    // ============================================ Public interface < ==//
    // ------------------------------------------------ Behaviour << --==//
    public void SpawnEnemyAtRandomLocation(int wave, int a, int b, int c, int vel) {
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
        var e = enemy.GetComponent<Enemy>();
        e.health = 100.0f;// + 25.0f * Random.Range(0, wave);
        // e.velocity = 1500 + wave * 50 / (a*b*c);
        e.velocity = 1500 + vel / (a*b*c);
        e.GenerateParts(a, b, c);

        enemies.Add(enemy);
    }
    public void SaveEnemies()
    {
        
        SaveSystem.SaveEnemy(EnemiesList());
        savedEnemies = EnemiesList();
        Debug.Log("Number of enemies:  " + savedEnemies.Count);
        for (int i = 0; i < savedEnemies.Count; i++)
        {
            Debug.Log("health[" + i + "] = " + savedEnemies[i].health);
        }
    }
    private List<Enemy> EnemiesList()
    {
        List<Enemy> enemiesList = new List<Enemy>();
        Enemy e;
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemy.Length; i++)
        {
            e = enemy[i].GetComponent<Enemy>();
            enemiesList.Add(e);
        }
        return enemiesList;
    }

    public void LoadEnemy()
    {
        EnemyData enemyData = SaveSystem.LoadEnemy();
        List<Enemy> lista = new List<Enemy>();
        lista = EnemiesList();
        
        Debug.Log("Number of enemies saved:  " + savedEnemies.Count);
        Debug.Log("Number of enemies in lista:  " + lista.Count);

        for (int i = 0; i < savedEnemies.Count; i++)
        {
            Debug.Log("health[" +i+"] = " + savedEnemies[i].health);
        }
            for (int i = 0; i < savedEnemies.Count; i++)
        {
           savedEnemies[i].setMultiplier(enemyData.multiplier[i]);
           lista[i].health=enemyData.health[i];

           lista[i].setPosition(enemyData.position[i][0], enemyData.position[i][1], enemyData.position[i][2]);
        }


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
    List<Enemy> savedEnemies = new List<Enemy>();

 
}
// ///////////////////////////////////////////////////////////////////// //
