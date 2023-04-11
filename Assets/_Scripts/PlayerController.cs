using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    public float speed = 10f;
    public float jumpHeight = 10f;
    public float gravity = 9.81f;
    public float airControl = 10f;
    private Vector3 input;
    //private Animator anim;

    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        input = (transform.right * moveHorizontal+ transform.forward * moveVertical).normalized;
        input *= speed;

       

        if (controller.isGrounded)
        {
            /*
            if (input == Vector3.zero)
            {
                anim.SetInteger("animState", 4);
            }
            else
            { 
                anim.SetInteger("animState", 1); 
            }*/
            
            moveDirection = input;
            if (Input.GetButton("Jump"))
            {
                //Debug.Log("Here");
                //anim.SetInteger("animState", 5);
                //anim.SetInteger("animState", 3);
                moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
            }
            else
            {
                moveDirection.y = 0.0f;
            }
        }
        else
        {
            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(input * Time.deltaTime);
    }
}
