using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{

    public CameraShake cameraShake;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Explosion"))
        {
            StartCoroutine(cameraShake.Shake(0.05f, 0.2f));
        }
    }
}
