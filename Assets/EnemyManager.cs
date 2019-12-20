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

    public void SpawnEnemy(int a, int b, int c, int vel, EnemyData data)
    {
        Vector3 vector = new Vector3(data.position[0], data.position[1], data.position[2]);
        GameObject enemy = Instantiate(enemyPrefab,
                        vector,
                        Quaternion.identity);
        var e = enemy.GetComponent<Enemy>();
        e.health = data.health;// + 25.0f * Random.Range(0, wave);
        // e.velocity = 1500 + wave * 50 / (a*b*c);
        e.velocity = 1500 + vel / (a * b * c);
        e.GenerateParts(a, b, c);

        enemies.Add(enemy);
    }

    //Enemy save working with one enemy 
    public void SaveEnemies()
    {
        
        Enemy e = new Enemy();
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemy.Length; i++)
        {
            e = enemy[i].GetComponent<Enemy>();
            savedEnemies.Add(e);
            SaveSystem.SaveEnemy(e, i);
        }
        
        //savedEnemies = EnemiesList();
        
        //Debug.Log("Number of enemies:  " + savedEnemies.Count);
        //for (int i = 0; i < savedEnemies.Count; i++)
        //{
        //    Debug.Log("health[" + i + "] = " + savedEnemies[i].health);
        //}
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

    //public void LoadEnemy()
    //{
    //    EnemyData enemyData = SaveSystem.LoadEnemy();
    //    List<Enemy> lista = new List<Enemy>();
    //    lista = EnemiesList();

    //    Debug.Log("Number of enemies saved:  " + savedEnemies.Count);
    //    //Debug.Log("Number of enemies in lista:  " + lista.Count);

    //    for (int i = 0; i < savedEnemies.Count; i++)
    //    {
    //        Debug.Log("health[" +i+"] = " + savedEnemies[i].health);
    //    }
    //        for (int i = 0; i < savedEnemies.Count; i++)
    //    {
    //        savedEnemies[i].setMultiplier(enemyData.multiplier[i]);
    //        savedEnemies[i].health = enemyData.health[i];
    //        savedEnemies[i].setPosition(enemyData.position[i][0], enemyData.position[i][1], enemyData.position[i][2]);
    //        //savedEnemies[i].setPosition(2 + i, 2 + i, 2 + i);

    //    }
    //}


    //Enemy load working with one enemy
    //public void LoadEnemy()
    //{
    //    Enemy e = new Enemy();
    //    GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
    //    List<EnemyData> data = new List<EnemyData>();
    //    for (int j = 0; j < enemy.Length; j++)
    //    {
    //        e = enemy[j].GetComponent<Enemy>();

    //    }
    //    for (int i = 0; i < savedEnemies.Count; i++)
    //    {
    //        data.Add(SaveSystem.LoadEnemy(i));

    //        e.health = data[i].health;
    //        e.setMultiplier(data[i].multiplier);
    //        e.setPosition(data[i].position[0], data[i].position[1], data[i].position[2]);
    //    }
    //    Debug.Log("Liczba obiektow data: " + data.Count);

    //}
    public void LoadEnemy()
    {

        List<EnemyData> data = new List<EnemyData>();
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] numbers = GameObject.FindGameObjectsWithTag("LocateNumber");
        Enemy e = new Enemy();
        for (int i = 0; i < enemy.Length; i++)
        {
            Destroy(numbers[i]);
            Destroy(enemy[i]);
        }
        for (int i = 0; i < enemy.Length+1; i++)
        {
            Destroy(numbers[i]);
           
        }
        for (int i = 0; i < savedEnemies.Count; i++) { 
            data.Add(SaveSystem.LoadEnemy(i));
            SpawnEnemy(1, 1, 1, 0, data[i]);

        }
        Debug.Log("Liczba obiektow data: " + data.Count);

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
