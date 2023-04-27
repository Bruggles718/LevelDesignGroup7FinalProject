using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDropSound : MonoBehaviour
{
    [SerializeField] private bool _triggered = false;

    public Falling falling;

    private void OnCollisionEnter(Collision collision)
    {
        if(!_triggered && collision.gameObject.layer == 7)
        {
            _triggered = true;
            falling.PlaySound();
        }
    }
}
