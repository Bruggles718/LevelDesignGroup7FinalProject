using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public AudioClip clip;
    public Transform _mainCam;
    public float gravity = 9.81f;
    public float speed = 2f;
    private bool _notColliding = true;
    private Rigidbody _myRb;
    bool _firstEnter = true;
    

    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        _myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= 75f && _firstEnter)
        {
            AudioSource.PlayClipAtPoint(clip, this.transform.position);
            _firstEnter = false;
        }
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
