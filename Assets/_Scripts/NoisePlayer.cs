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
                audioSource.volume = Mathf.Lerp(1.0f, 0f, _elapsedTime / duration);
                Debug.Log(audioSource.volume);
            }
            else {
                audioSource.Stop();
                audioSource.clip = null;
                _startExit = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (_firstEnter) {
            audioSource.clip = noiseSFX;
            audioSource.loop = true;
            audioSource.Play();
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if (_firstEnter) {
            _startExit = true;
            _firstEnter = false;
        }
        
    }
}