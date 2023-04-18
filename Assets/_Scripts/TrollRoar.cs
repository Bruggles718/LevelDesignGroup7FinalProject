using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollRoar : MonoBehaviour {
    public AudioClip SFX;
    public Transform trollPosition;
    public int playAmount = 10;
    private bool _firstEnter = true;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if (_firstEnter) {
            for (int i = 0; i < playAmount; i++) {
                AudioSource.PlayClipAtPoint(SFX,trollPosition.position);
            }
            _firstEnter = false;
        }
    }
    
}
