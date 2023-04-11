using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public Light sunLight;
    public float duration = 20f;
    public float timeInterval = 1f;
    public float amount = 1.0f;
    private float _cycles = 0f;
    private bool _firstEnter = true;
    private bool _start = false;
    private float _elapsedTime = 0.0f;
    
    // Update is called once per frame
    void Update()
    {
        if (_start)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= timeInterval && _cycles <= duration)
            {
                _elapsedTime %= timeInterval;
                sunLight.transform.Rotate(new Vector3(amount,0,0));
                _cycles++;
            } else if (_cycles >= duration)
            {
                _start = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_firstEnter)
        {
            _start = true;
            _firstEnter = false;
        }
    }
}
