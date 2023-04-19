using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public Transform target;
    public Transform targetback;
    public float zoomFOV;
    public float regularFOV;
    public float speed = 1f;
    public float startDuration;
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
        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);

        float time = 0;
        
        while(time < startDuration)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, zoomFOV, time);

            time += Time.deltaTime * speed;

            yield return null;
 
        }

        Quaternion lookbackRotation = Quaternion.LookRotation(targetback.position - transform.position);

        time = 0;

        while (time < endDuration)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookbackRotation, time);
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, regularFOV, time);

            time += Time.deltaTime * speed;

            yield return null;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bear" && this.enabled)
        {
            GetComponent<PlayerController>().enabled = false;
            StartRotating();
            Invoke("StartMoving", 4.3f);
            Invoke("TrollRoar", trollRoarDelay);
            this.enabled = false;
        }
    }

    void StartMoving()
    {
        GetComponent<PlayerController>().enabled = true;
    }
    
    void TrollRoar()
    {
        troll.Roar();
    }

}
