using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public float speed;

    public Animator animator;

    private Waypoints wPoints;

    private int waypointIndex;

    void Start()
    {
        wPoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        waypointIndex = wPoints.waypoints.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(waypointIndex);
        animator.SetFloat("speed", speed);

        transform.position = Vector2.MoveTowards(transform.position, wPoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        Vector2 dir = wPoints.waypoints[waypointIndex].position - transform.position;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90;
        animator.SetFloat("rotation", (angle * Mathf.Deg2Rad));

        if (Vector2.Distance(transform.position, wPoints.waypoints[waypointIndex].position) < 0.01f)
        {
            if (waypointIndex > 0)
            {
                waypointIndex--;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
