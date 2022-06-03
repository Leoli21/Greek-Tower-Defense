using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingTower : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]

    public float range = 10f;
    public LineRenderer lineRenderer;

    public string enemyTag = "Enemy";

    public float slowSpeed = 2;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (lineRenderer.enabled == true)
            {
                lineRenderer.enabled = false;
            }
            return;
        }
        else
        {
            Laser();
        }
    }

    // Fires laser

    void Laser()
    {
        if (lineRenderer.enabled == false)
        {
            lineRenderer.enabled = true;
        }

        target.GetComponent<Movement>().SetSpeed(slowSpeed);

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    // Updates the target on enemy

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // Sorts through array of enemies

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // Targets nearet enemy, if empty, target is null

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Shows range in scene

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
