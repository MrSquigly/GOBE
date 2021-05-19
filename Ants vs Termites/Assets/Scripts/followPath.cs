using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPath : MonoBehaviour
{

    public float speed;

    public Animator animator;

    private Waypoints wPoints;

    private int waypointIndex;

    private Vector2 target;

    void Start()
    {
        wPoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wPoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        animator.SetFloat("speed", speed);

        if (Vector2.Distance(transform.position, wPoints.waypoints[waypointIndex].position) < 0.01f)
        {
            
            if(waypointIndex < wPoints.waypoints.Length - 1)
            {
                waypointIndex += 1;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}

