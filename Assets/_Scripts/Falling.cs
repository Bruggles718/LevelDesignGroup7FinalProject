using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public AudioClip clip;
    public float gravity = 9.81f;
    public float speed = 2f;
    private bool _notColliding = true;
    private Rigidbody _myRb;
    bool _firstEnter = true;

    private Rigidbody[] rbs;
    

    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        //_myRb = GetComponent<Rigidbody>();
        rbs = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rbs[0].position.y <= 75f && _firstEnter)
        {
            _firstEnter = false;
        }
    }

    private void FixedUpdate()
    {
        if (_notColliding)
        {
            float downwardForce = gravity * 70 * speed;
            //_myRb.AddForce(new Vector3(0,-1,0) * downwardForce);
            foreach (var rb in rbs)
            {
                //rb.AddForce(new Vector3(0, -1, 0) * downwardForce);
            }
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

    public void PlaySound()
    {
        AudioSource.PlayClipAtPoint(clip, this.transform.position);
    }
}
