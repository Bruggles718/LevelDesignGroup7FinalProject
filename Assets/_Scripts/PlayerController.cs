using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    public float sprintSpeed = 15f;
    public float speed = 10f;
    public float jumpHeight = 10f;
    public float gravity = 9.81f;
    public float airControl = 10f;
    private Vector3 input;
    private float distanceToGround;
    //private Animator anim;

    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        this.distanceToGround = GetComponent<Collider>().bounds.extents.y;
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        input = Vector3.ClampMagnitude((transform.right * moveHorizontal+ transform.forward * moveVertical), Mathf.Max(Mathf.Abs(moveHorizontal), Mathf.Abs(moveVertical)));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            input *= sprintSpeed;
        }
        else
        {
            input *= speed;
        }

       

        if (IsGrounded())
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
        controller.Move(moveDirection * Time.deltaTime);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(this.transform.position, -Vector3.up, this.distanceToGround + 0.2f);
    }
}
