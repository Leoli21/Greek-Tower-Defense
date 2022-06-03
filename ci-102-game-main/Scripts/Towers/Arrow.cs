using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform target;
    public string enemyTag = "Enemy";

    public float range = 1f;
    public float damage = 250f;
    public float time = 3f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0f) {
            time -= Time.deltaTime;
        } 
        else
        {
            Target();
            Destroy(gameObject);
        }
    }

    void Target()
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
                mob.TakeDamage(damage);
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
