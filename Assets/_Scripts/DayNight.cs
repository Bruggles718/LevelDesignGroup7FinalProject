using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AzureSky;

public class DayNight : MonoBehaviour
{
    // public Light sunLight;
    public float duration = 20f;
    public float timeInterval = 1f;
    // public float amount = 1.0f;
    public float startValue = 0;
    public float endValue = 2.03f;
    public AzureTimeController atc;
    private float _cycles = 0f;
    private bool _firstEnter = true;
    private bool _start = false;
    private float _elapsedTime = 0.0f;
    private float _tVal = 0f;
    private float _timeValue;
    // Update is called once per frame
    void Update()
    {
        if (_start)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= timeInterval && _cycles <= duration)
            {
                _elapsedTime %= timeInterval;
                _tVal += Time.time;
                _timeValue = Mathf.Lerp(startValue, endValue, _tVal / duration);
                atc.SetTimeline(_timeValue);
                _cycles++;
            }
            /*
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
            */
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_firstEnter && other.CompareTag("Player"))
        {
            _start = true;
            _firstEnter = false;
        }
    }
}
