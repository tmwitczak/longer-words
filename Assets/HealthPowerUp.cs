using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{

    public GameObject pickUpEffect;
    public float duration = 20.0f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }


    IEnumerator PickUp(Collider player)
    {
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        Player p = player.GetComponent<Player>();

        p.setHealth(150.0f , 150.0f);
 

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(20.0f);

        float actualHealth = p.getHealth();

        if (actualHealth >= 100.0f)
        {
            p.setHealth(100.0f, 100.0f);
 
        }
        else
        {
            p.setHealth(actualHealth, 100.0f);

        }
         

        Destroy(gameObject);
    }
}
