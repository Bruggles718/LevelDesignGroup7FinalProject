using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Breathing : MonoBehaviour {
    public AudioClip breatingSfx;
    public float timeInterval = 30f;
    private float _elapsedTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= timeInterval && PlayerController.isMoving && PlayerController.isGrounded) {
            _elapsedTime = _elapsedTime % timeInterval;
            AudioSource.PlayClipAtPoint(breatingSfx, transform.position);
        }
    }
}
