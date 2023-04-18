using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public Transform target;
    public Transform targetback;
    public float speed = 1f;

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
        
        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * speed;

            yield return null;
 
        }

        Quaternion lookbackRotation = Quaternion.LookRotation(targetback.position - transform.position);

        time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookbackRotation, time);

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
            this.enabled = false;
        }
    }

    void StartMoving()
    {
        GetComponent<PlayerController>().enabled = true;
    }

}
