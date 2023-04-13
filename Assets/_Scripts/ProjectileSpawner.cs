using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject projectilePrefab;
    public Transform target;
    float lockTime;
    // Start is called before the first frame update
    void Start()
    {
        lockTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < lockTime) return;
        var projectile = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity).GetComponent<Projectile>();

        projectile.SetTarget(target);
        projectile.Launch();
        lockTime = Time.time + spawnRate;
    }
}
