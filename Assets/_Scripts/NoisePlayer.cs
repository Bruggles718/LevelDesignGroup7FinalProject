using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NoisePlayer : MonoBehaviour
{
    public AudioClip noiseSFX;
    public AudioSource audioSource;
    public float duration = 10f;
    private bool _firstEnter = true;
    private bool _startExit = false;
    private float _elapsedTime;

    private void Update() {
        
        if (_startExit) {

            if (_elapsedTime <= duration) {
                _elapsedTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(0.2f, 0f, _elapsedTime / duration);
            }
            else {
                _elapsedTime = 0.0f;
                audioSource.Stop();
                audioSource.volume = 0.2f;
                audioSource.clip = null;
                _startExit = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log(gameObject.name);
            audioSource.clip = noiseSFX;
            audioSource.loop = true;
            audioSource.Play();
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) _startExit = true;

    }
}
