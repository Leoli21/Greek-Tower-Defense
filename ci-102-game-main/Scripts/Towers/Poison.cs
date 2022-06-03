using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public Transform target;
    public string enemyTag = "Enemy";

    public float range = 1f;
    public float damageOverTime = 1500f;
    public float time = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0f)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        // Sorts through array of enemies

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= range)
            {
                // Attacks enemy
                GameObject target = enemy;
                Health mob = target.GetComponent<Health>();
                mob.GetComponent<Health>().TakeDamage(damageOverTime * Time.deltaTime);
            }
        }

        // Shows range in scene

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
