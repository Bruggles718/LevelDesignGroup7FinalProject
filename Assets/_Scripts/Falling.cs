using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public Transform _mainCam;
    public Transform target;
    public float gravity = 9.81f;
    public float speed = 2f;
    private bool _notColliding = true;
    private Rigidbody _myRb;
    [SerializeField]
    private GameObject _cutscene;
    // Start is called before the first frame update
    void Start()
    {
        _myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_notColliding)
        {
            float downwardForce = gravity * _myRb.mass * speed;
            _myRb.AddForce(new Vector3(0,-1,0) * downwardForce);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        _notColliding = false;
    }

    private void OnCollisionExit(Collision other)
    {
        _notColliding = true;
    }

    
}
