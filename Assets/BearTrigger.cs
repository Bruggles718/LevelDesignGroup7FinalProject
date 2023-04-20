using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var bear = GameObject.FindWithTag("Bear");
            Rigidbody[] rbs = bear.GetComponentsInChildren<Rigidbody>();

            foreach (var rb in rbs)
            {
                rb.isKinematic = false;
            }
        }

    }
}
