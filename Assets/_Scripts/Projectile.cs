using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float initialUpwardVelocity;

    public bool showGizmos = true;
    public int resolution = 15;

    private Vector3 gizmoPos;
    public bool updateGizmoPos = true;

    // Start is called before the first frame update
    void Start()
    {
        updateGizmoPos = false;
        var position = this.transform.position;
        gizmoPos = position;
        var targetPos = this.target.position;
        var initialHeight = position.y - targetPos.y;

        float a = 0.5f * Physics.gravity.y;
        float b = this.initialUpwardVelocity;
        float c = initialHeight;

        var t = (-b - Mathf.Sqrt(b * b - (4 * a * c))) / (2 * a);

        var flatPos = new Vector3(position.x, 0, position.z);
        var flatTargetPos = new Vector3(targetPos.x, 0, targetPos.z);
        var distance = Vector3.Distance(flatPos, flatTargetPos);

        var horizontalVelocity = distance / t;
        var direction = (flatTargetPos - flatPos).normalized;

        var velocity = direction * horizontalVelocity + Vector3.up * initialUpwardVelocity;

        GetComponent<Rigidbody>().AddForce(velocity, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;
        Vector3 position;
        if (updateGizmoPos)
        {
            position = this.transform.position;
        }
        else
        {
            position = gizmoPos;
        }
        var targetPos = this.target.position;
        var initialHeight = position.y - targetPos.y;

        float a = 0.5f * Physics.gravity.y;
        float b = this.initialUpwardVelocity;
        float c = initialHeight;

        var t = (-b - Mathf.Sqrt(b * b - (4 * a * c))) / (2 * a);

        var flatPos = new Vector3(position.x, 0, position.z);
        var flatTargetPos = new Vector3(targetPos.x, 0, targetPos.z);
        var distance = Vector3.Distance(flatPos, flatTargetPos);

        var horizontalVelocity = distance / t;
        var direction = (flatTargetPos - flatPos).normalized;

        var velocity = direction * horizontalVelocity + Vector3.up * initialUpwardVelocity;
        Gizmos.color = Color.white;

        for (int i = 0; i <= resolution; i += 1)
        {
            var spherePos = position;
            spherePos += direction * (((float)i / (float)resolution) * distance);
            spherePos.y = targetPos.y + EvaluateQuadratic(a, b, c, (((float)i / (float)resolution) * t));
            Gizmos.DrawSphere(spherePos, 1);
        }
    }

    float EvaluateQuadratic(float a, float b, float c, float t)
    {
        return a * t * t + b * t + c;
    }
}
