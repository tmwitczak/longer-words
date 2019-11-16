// ////////////////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// //////////////////////////////////////////////////// Class: Explosion //
public class Explosion : MonoBehaviour {
    // ====================================== Private implementation < ==//
    // ------------------------------------------------ Behaviour << --==//

    public CameraShake cameraShake;

    private void Update() {
        timePassed = Mathf.Clamp(timePassed + Time.deltaTime,
                                 0.0f, duration);
        if (Mathf.Approximately(timePassed, duration)) {
            Destroy(gameObject);
        }
        SetLightsIntensity();
        StartCoroutine( cameraShake.Shake(0.15f, 0.4f));
    }
    private void SetLightsIntensity() {
        GetComponentsInChildren<Light>()[0].intensity
            -= ((4.0f / duration) * Time.deltaTime);
    }
    // ----------------------------------------------------- Data << --==//
    // ............................................ Parameters <<< ..--==//
    [SerializeField] private float duration;
    // ................................................. Timer <<< ..--==//
    private float timePassed = 0.0f;
}
// ///////////////////////////////////////////////////////////////////// //
