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
        transform.position = Vector3.SmoothDamp(
            transform.position,
            player.position + offset,
            ref currentVelocity,
            smoothTime);
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
}
// ///////////////////////////////////////////////////////////////////// //
