using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public static bool cutscenePlaying;
    public Transform target;
    public Transform targetback;
    public float zoomFOV;
    public float regularFOV;
    public float speed = 1f;
    public float startDuration;
    public float lookAtTrollForSeconds;
    public float trollRoarDelay;
    public float endDuration;
    public Camera playerCamera;
    public Troll troll;

    private Coroutine LookCoroutine;
    private Coroutine LookBehindCoroutine;
  
    public void StartRotating()
    {
        if(LookCoroutine != null)
        {        
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt());
    
    }

    private IEnumerator LookAt()
    {
        var camController = Camera.main.GetComponent<CameraController>();
        camController.enabled = false;
        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);

        float time = 0;

        var dir = (target.position - transform.position).normalized;

        var initForward = Camera.main.transform.forward;

        var initFov = Camera.main.fieldOfView;
        
        while(time < startDuration)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            Camera.main.transform.forward = Vector3.Lerp(initForward, dir, time / startDuration);
            Camera.main.fieldOfView = Mathf.Lerp(regularFOV, zoomFOV, time / startDuration);

            time += Time.deltaTime * speed;

            yield return null;
 
        }

        Camera.main.transform.forward = dir;

        yield return new WaitForSeconds(lookAtTrollForSeconds);

        Quaternion lookbackRotation = Quaternion.LookRotation(targetback.position - transform.position);

        time = 0;

        //var initUp = playerCamera.transform.up;
        initForward = dir;
        dir = (targetback.position - transform.position).normalized;

        while (time < endDuration)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, lookbackRotation, time);
            Camera.main.transform.forward = Vector3.Lerp(initForward, dir, time / endDuration);
            //playerCamera.transform.up = Vector3.Lerp(initUp, Vector3.up, time / endDuration);
            //playerCamera.transform.up = initUp;
            Camera.main.fieldOfView = Mathf.Lerp(zoomFOV, regularFOV, time / endDuration);

            time += Time.deltaTime * speed;

            yield return null;
        }


        Camera.main.GetComponent<CameraController>().enabled = true;

        Camera.main.transform.forward = dir;

        yield return null;

        StartMoving();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bear" && this.enabled)
        {
            GetComponent<PlayerController>().enabled = false;
            StartRotating();
            //Invoke("StartMoving", 4.3f);
            Invoke("TrollRoar", trollRoarDelay);
            this.enabled = false;
            cutscenePlaying = true;
        }
    }

    void StartMoving()
    {
        GetComponent<PlayerController>().enabled = true;
        var dir = (targetback.position - transform.position).normalized;
        var flatDir = new Vector3(dir.x, 0, dir.z);
        this.transform.forward = flatDir;
        cutscenePlaying = false;
    }
    
    void TrollRoar()
    {
        troll.Roar();
    }

}
