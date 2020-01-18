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

            FindObjectOfType<AudioManager>().Play(GetComponent<AudioSource>(), "power-up");
        }
    }


    IEnumerator PickUp(Collider player)
    {
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        Player p = player.GetComponent<Player>();

        p.setHealth(150.0f , 150.0f);
 

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        ParticleSystem particleSystem = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        var emission = particleSystem.emission;
        emission.enabled = false;

        Light spotlight = GameObject.Find("Spot Light").GetComponent<Light>();
        spotlight.enabled = false;

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
