using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;
    public int damage = 10;
    
    // Function that finds target

    public void Find (Transform targetted)
    {
        target = targetted;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distancePerFrame = speed * Time.deltaTime;

        // If the bullet is going to pass through the enemy, it is hit

        if (dir.magnitude <= distancePerFrame)
        {
            Damage(target);
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);
    }

    // Destroys bullet when hit

    void HitTarget()
    {
        Destroy(gameObject);
    }

    // Damage enemy

    void Damage(Transform enemy)
    {
        Health mob = enemy.GetComponent<Health>();
        
        if (mob != null)
        {
            mob.TakeDamage(damage);
        }
    }
}
