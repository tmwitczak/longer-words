// ////////////////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// /////////////////////////////////////////// Class: CameraFollowPlayer //
public class CameraFollowPlayer : MonoBehaviour {
    // ====================================== Private implementation < ==//
    // ------------------------------------------------ Behaviour << --==//
    private void Start() {
        offset = transform.position - player.position;
    }
    private void Update() {
        handleShaking();
        transform.position = Vector3.SmoothDamp(
            transform.position,
            player.position + offset + shake,
            ref currentVelocity,
            smoothTime) + 0.1f * shakeOffset;
    }
    // ----------------------------------------------------- Data << --==//
    // ............................................ Parameters <<< ..--==//
    [SerializeField] private Transform player;
    [SerializeField] private float smoothTime;
    // ....................................... Camera's offset <<< ..--==//
    // ............. (so it's actually over the player's head) <<< ..--==//
    private Vector3 offset;
    // ....................................... Dummy variables <<< ..--==//
    private Vector3 currentVelocity = Vector3.zero;



    // camera shake
    private float duration;
    private float magnitude;
    private float elapsed;
    private float recalculate = 0.0f;
    Vector3 shake, targetShake, direction, targetShakeOffset, shakeOffset;

    public void Shake(float d, float m, Vector3 v) {
        duration = d;
        magnitude = m;
        elapsed = 0.0f;
        recalculate = 0.0f;
        direction = -v.normalized;
    }

    void handleShaking() {
        if (elapsed < duration) {
            elapsed += Time.deltaTime;
            recalculate += Time.deltaTime;

            if (recalculate > (duration / 10)) {
                recalculate = 0.0f;

                targetShake = direction * magnitude;
                targetShake.y = 0.0f;

                targetShakeOffset.x = Random.Range(-0.5f, 0.5f) * magnitude;
                targetShakeOffset.y = 0.0f;
                targetShakeOffset.z = Random.Range(-0.5f, 0.5f) * magnitude;
            }
        }
        else {
            targetShake = Vector3.zero;
            targetShakeOffset = Vector3.zero;
        }
        shake = targetShake;
        shakeOffset = Vector3.Lerp(Vector3.zero, targetShakeOffset, 0.15f);
    }
}
// ///////////////////////////////////////////////////////////////////// //
