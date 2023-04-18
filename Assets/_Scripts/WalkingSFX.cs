using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class WalkingSFX : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip[] sfXs;
    private int _sfXIdx = 0;
    private float _elapsedTime;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        _elapsedTime += Time.deltaTime;
        if (!PlayerController.isMoving || !PlayerController.isGrounded) audioSource.Stop();
        if (_elapsedTime >= sfXs[_sfXIdx].length && PlayerController.isMoving) {
            _elapsedTime = 0f;
            int randomIdx = Random.Range(0, sfXs.Length);
            audioSource.clip = sfXs[randomIdx];
            audioSource.Play();
        }
        

    }
}
