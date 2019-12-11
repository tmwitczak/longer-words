using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    public bool scaleDown = false;

    void Start() {}

    void Update() {
        Vector3 velocity = Vector3.zero;
        if (scaleDown) {
            this.gameObject.transform.localScale = Vector3.SmoothDamp(
                gameObject.transform.localScale,
                Vector3.zero,
                ref velocity,
                0.075f
            );
        }
    }
}
