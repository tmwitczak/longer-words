using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    // ============================================ Public interface < ==//
    // ------------------------------------------------ Behaviour << --==//
    public void SpawnPowerUpAtRandomLocation(int wave)
    {
        // Set ranges
        const float rangeMin = 10f;
        const float rangeMax = 10f;
        Vector3 randomLocation =
            Quaternion.Euler(0, Random.Range(0, 360), 0)
            * (Random.Range(rangeMin, rangeMax)
               * Vector3.forward
               + new Vector3(0, 0.5f, 0));

        GameObject speedPowerUp = Instantiate(speedPowerUpPrefab,
                        GameObject.Find("Player").transform.position + randomLocation * Random.Range(0.0f,0.5f),
                        Quaternion.identity);
        speedPowerUp.GetComponent<SpeedPowerUp>();
        powerUps.Add(speedPowerUp);

        GameObject healthPowerUp = Instantiate(healthPowerUpPrefab,
                GameObject.Find("Player").transform.position + randomLocation * Random.Range(0.5f, 1.0f),
                Quaternion.identity);
        healthPowerUp.GetComponent<HealthPowerUp>();
        powerUps.Add(healthPowerUp);
    }
    public bool areThereAnyEnemies()
            => (GameObject.FindGameObjectsWithTag("Enemy")).Length != 0;
    // ----------------------------------------------------- Data << --==//
    // ............................................ Parameters <<< ..--==//
    [SerializeField] private GameObject speedPowerUpPrefab;
    [SerializeField] private GameObject healthPowerUpPrefab;

    // ................................................. Other <<< ..--==//
    // TODO: This list doesn't work for now, to be fixed
    List<GameObject> powerUps = new List<GameObject>();
}
