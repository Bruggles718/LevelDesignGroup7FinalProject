using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AzureSky;

public class DayNight : MonoBehaviour
{
    public float duration = 20f;
    public float endValue;
    public AzureTimeController atc;
    private float _startValue = 0;
    private bool _firstEnter = true;
    private bool _start = false;
    private float _elapsedTime = 0.0f;
    private float _timeValue;

    void Update() {

        if (_start)
        {
            if (_elapsedTime <= duration)
            {
                _elapsedTime += Time.deltaTime;
                _timeValue = Mathf.Lerp(_startValue, endValue, _elapsedTime / duration);
                atc.SetTimeline(_timeValue);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_firstEnter && other.CompareTag("Player")) {
            if (atc != null) _startValue = atc.GetTimeline();
            _start = true;
            _firstEnter = false;
        }
    }

    
    
    
}
