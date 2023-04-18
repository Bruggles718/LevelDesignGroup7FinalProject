using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AzureSky;

public class ReturnCycle : MonoBehaviour
{
    public float duration = 20f;
    public float endValue = 2.03f;
    public AzureTimeController atc;
    private float _startValue = 0;
    private float _cycles = 0f;
    private bool _firstEnter = true;
    private bool _secondEnter = false;
    private bool _start = false;
    private float _elapsedTime = 0.0f;
    private float _tVal = 0f;
    private float _timeValue;

    private void Start() {
        if (atc != null) _startValue = atc.GetTimeline();
    }

    void Update()
    {
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
        if (_firstEnter && other.CompareTag("Player"))
        {
            Debug.Log("First enter");
            _firstEnter = false;
            _secondEnter = true;
        }
        else if (_secondEnter && other.CompareTag("Player"))
        {
            Debug.Log("Second enter");
            _secondEnter = false;
            _start = true;
        }
    }

    private void OnDrawGizmos() {
        
    }
}