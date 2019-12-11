// ////////////////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ///////////////////////////////////////////////////// Class: Fireball //
public class Fireball : MonoBehaviour {
    // ============================================ Public interface < ==//
    // ------------------------------------------------ Behaviour << --==//
    // ............................................ Collisions <<< ..--==//
    bool destroyed = false;
    public void OnCollisionEnter(Collision collision) {
        if (!destroyed && collision.gameObject.CompareTag("Enemy")) {
            Instantiate(explosionPrefab,
                        collision.gameObject.transform.position,
                        Quaternion.identity);
            GameObject.Find("Main Camera").GetComponent<CameraFollowPlayer>()
                .Shake(0.5f, 0.3f, GetComponent<Rigidbody>().velocity);
            destroyed = true;
            Destroy(gameObject);
        }
    }
    // ====================================== Private implementation < ==//
    // ----------------------------------------------------- Data << --==//
    // ............................................ Parameters <<< ..--==//
    [SerializeField] private GameObject explosionPrefab;
}
// ///////////////////////////////////////////////////////////////////// //
