using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePowerUp : MonoBehaviour
{

    public GameObject pickUpEffect;


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

        Enemy e;
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i =0; i < enemy.Length; i++)
        {
            e = enemy[i].GetComponent<Enemy>();
            e.setMultiplier(0);
        }


        
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        ParticleSystem particleSystem = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        var emission = particleSystem.emission;
        emission.enabled = false;

        Light spotlight = GameObject.Find("Spot Light").GetComponent<Light>();
        spotlight.enabled = false;

        yield return new WaitForSeconds(5.0f);


        for (int i = 0; i < enemy.Length; i++)
        {
            e = enemy[i].GetComponent<Enemy>();
            e.setMultiplier(1);
        }


        Destroy(gameObject);
    }
}
