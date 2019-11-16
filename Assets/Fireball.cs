// ////////////////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ///////////////////////////////////////////////////// Class: Fireball //
public class Fireball : MonoBehaviour {
    // ============================================ Public interface < ==//
    // ------------------------------------------------ Behaviour << --==//
    // ............................................ Collisions <<< ..--==//
    public CameraShake cameraShake;
    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy") {
            Instantiate(explosionPrefab,
                        collision.gameObject.transform.position,
                        Quaternion.identity);
            Destroy(gameObject);
            StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
        }
    }
    // ====================================== Private implementation < ==//
    // ----------------------------------------------------- Data << --==//
    // ............................................ Parameters <<< ..--==//
    [SerializeField] private GameObject explosionPrefab;
}
// ///////////////////////////////////////////////////////////////////// //
