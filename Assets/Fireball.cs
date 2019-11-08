// ////////////////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ///////////////////////////////////////////////////// Class: Fireball //
public class Fireball : MonoBehaviour {
    // ============================================ Public interface < ==//
    // ------------------------------------------------ Behaviour << --==//
    // ............................................ Collisions <<< ..--==//
    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy") {
            Instantiate(explosionPrefab,
                        collision.gameObject.transform.position,
                        Quaternion.identity);
            Destroy(gameObject);
        }
    }
    // ====================================== Private implementation < ==//
    // ----------------------------------------------------- Data << --==//
    // ............................................ Parameters <<< ..--==//
    [SerializeField] private GameObject explosionPrefab;
}
// ///////////////////////////////////////////////////////////////////// //
