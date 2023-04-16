using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderRedirector : MonoBehaviour
{
    [SerializeField] private float power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            other.GetComponent<Rigidbody>().AddForce(this.transform.forward * power, ForceMode.VelocityChange);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * power);
    }
}
