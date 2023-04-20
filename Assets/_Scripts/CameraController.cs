using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float pitch = 0f;
    // public GameObject flashlight;
    Transform playerBody;

    public float moveX = 0;
    public float moveY = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (playerBody != null) this.transform.forward = playerBody.transform.forward;
        if (Cutscene.cutscenePlaying) return;
        playerBody = transform.parent.transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        moveX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        moveY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //yaw
        playerBody.Rotate(Vector3.up * moveX);

        //pitch
        pitch -= moveY;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        // flashlight.transform.localRotation = transform.localRotation;
        transform.Rotate(new Vector3(0, 0, 0));
        // flashlight.transform.Rotate(new Vector3(0,0,0));
    }
}