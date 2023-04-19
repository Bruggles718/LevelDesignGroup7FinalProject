using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollRoarTrigger : MonoBehaviour
{
    public Troll trollScript;
    public bool active = true;

    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            trollScript.Roar();
        }
        active = false;
    }
}
