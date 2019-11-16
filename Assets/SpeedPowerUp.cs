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
        }
    }


    IEnumerator PickUp(Collider player)
    {
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        Player p = player.GetComponent<Player>();
        //if(p.getVelocity() < 225.0f)
        //{
            p.setVelocity(multiplier);
        //}
        

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(20.0f);

        p.setVelocity(1.0f / multiplier);

        Destroy(gameObject);
    }
}
