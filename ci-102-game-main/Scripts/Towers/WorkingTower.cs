using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingTower : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    public string enemyTag = "Enemy";

    public GameObject bullet;
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
            return;
        }

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    // Firess bullet

    void Shoot()
    {
        GameObject fireBullet = (GameObject)Instantiate(bullet, firePoint.position, firePoint.rotation);
        Bullet shotBullet = fireBullet.GetComponent<Bullet>();

        if (shotBullet != null)
        {
            shotBullet.Find(target);
        }
        
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

        if (nearestEnemy != null && shortestDistance <= range) {
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
