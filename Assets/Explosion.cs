// ////////////////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// //////////////////////////////////////////////////// Class: Explosion //
public class Explosion : MonoBehaviour {
    // ====================================== Private implementation < ==//
    // ------------------------------------------------ Behaviour << --==//
    private void Start() {
        FindObjectOfType<AudioManager>().Play(GetComponent<AudioSource>(), "explosion");
    }
    private void Update() {
        timePassed = Mathf.Clamp(timePassed + Time.deltaTime,
                                 0.0f, duration);
        if (Mathf.Approximately(timePassed, duration)) {
            Destroy(gameObject);
        }
        SetLightsIntensity();
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
