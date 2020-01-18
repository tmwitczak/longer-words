using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
   
    public GameObject pickUpEffect;
    public float multiplier = 1.5f;

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
        if (p.getVelocity() == 225)
        {
            p.setVelocity(1.0f);
            
        }
        else p.setVelocity(multiplier);



        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;


        ParticleSystem particleSystem = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        var emission = particleSystem.emission;
        emission.enabled = false;

        Light spotlight = GameObject.Find("Spot Light").GetComponent<Light>();
        spotlight.enabled = false;

        yield return new WaitForSeconds(20.0f);

        float a = p.getVelocity();
        if (a <= 100)
        {
            p.setVelocity(1.0f);
        }
        else  p.setVelocity(1.0f / multiplier);


        Destroy(gameObject);
    }
}
