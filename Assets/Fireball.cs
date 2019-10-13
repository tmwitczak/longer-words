using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosionPre,
                    collision.gameObject.transform.position,
                    Quaternion.identity);
            Destroy(gameObject);
        }
    }
    [SerializeField] public GameObject explosionPre;
}
