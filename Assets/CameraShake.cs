using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake( float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-0.5f, 0.5f) * magnitude;
            float y = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.position = new Vector3(originalPos.x + x,originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null; 
        }

        transform.position = originalPos;
    }

}
