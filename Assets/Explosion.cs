using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Update()
    {
        time -= Time.deltaTime;
        GetComponentsInChildren<Light>()[0].intensity
            -= ((4.0f / timeStart) * Time.deltaTime);
        if (time <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    float timeStart = 1;
    float time = 1;
}
