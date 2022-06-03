using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 5f;
    private Transform target;
    private int wavepointIndex = 0; 

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        // Goes to waypoint at a set speed

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    // Gets next waypoint to travel to

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            Stats.Life -= 1;
            WaveSpawner.EnemiesAlive--;
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
