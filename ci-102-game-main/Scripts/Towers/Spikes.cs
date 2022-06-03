using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Transform target;
    public string enemyTag = "Enemy";

    public float range = 1f;
    public float damage = 100f;


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

        Damage(target);

        if (damage <= 0)
        {
            Destroy(gameObject);
        }

    }

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

    void Damage(Transform enemy)
    {
        Health mob = enemy.GetComponent<Health>();

        if (mob != null)
        {
            if (damage >= mob.health)
            {
                float enemyHealth = mob.health;
                mob.TakeDamage(damage);
                damage -= enemyHealth;
            }
            else
            {
                mob.TakeDamage(damage);
                damage = 0;
            }
        }
    }

    // Shows range in scene

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
