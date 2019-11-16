using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    // ============================================ Public interface < ==//
    // ------------------------------------------------ Behaviour << --==//
    public void SpawnPowerUpAtRandomLocation(int wave)
    {
        int number = Random.Range(1, 4);

        // Set ranges
        const float rangeMin = 10f;
        const float rangeMax = 10f;
        Vector3 randomLocation =
            Quaternion.Euler(0, Random.Range(0, 360), 0)
            * (Random.Range(rangeMin, rangeMax)
               * Vector3.forward
               + new Vector3(0, 0.5f, 0));

        switch (number)
        {

            case 1:
                GameObject speedPowerUp = Instantiate(speedPowerUpPrefab,
                                GameObject.Find("Player").transform.position + randomLocation * Random.Range(0.2f, 0.7f),
                                Quaternion.identity);
                speedPowerUp.GetComponent<SpeedPowerUp>();
                powerUps.Add(speedPowerUp);
                break;

            case 2:
                GameObject healthPowerUp = Instantiate(healthPowerUpPrefab,
                        GameObject.Find("Player").transform.position + randomLocation * Random.Range(0.2f, 0.7f),
                        Quaternion.identity);
                healthPowerUp.GetComponent<HealthPowerUp>();
                powerUps.Add(healthPowerUp);
                break;

            case 3:
                GameObject freezePowerUp = Instantiate(freezePowerUpPrefab,
                     GameObject.Find("Player").transform.position + randomLocation * Random.Range(0.2f, 0.7f),
                     Quaternion.identity);
                freezePowerUp.GetComponent<FreezePowerUp>();
                powerUps.Add(freezePowerUp);
                break;
        }

    }
    public bool areThereAnyEnemies()
            => (GameObject.FindGameObjectsWithTag("Enemy")).Length != 0;
    // ----------------------------------------------------- Data << --==//
    // ............................................ Parameters <<< ..--==//
    [SerializeField] private GameObject speedPowerUpPrefab;
    [SerializeField] private GameObject healthPowerUpPrefab;
    [SerializeField] private GameObject freezePowerUpPrefab;

    // ................................................. Other <<< ..--==//
    // TODO: This list doesn't work for now, to be fixed
    List<GameObject> powerUps = new List<GameObject>();
}
