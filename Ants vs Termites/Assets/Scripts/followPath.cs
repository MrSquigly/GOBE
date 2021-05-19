using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class followPath : MonoBehaviour
{

    public float speed;

    public Animator animator;

    private Waypoints wPoints;

    private int waypointIndex;

    void Start()
    {
        wPoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    void Update()
    {
        animator.SetFloat("speed", speed);

        if (animator.GetBool("combat") == true)
        {
            Debug.Log("combat!");
            speed = 0;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, wPoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

            Vector2 dir = wPoints.waypoints[waypointIndex].position - transform.position;
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90;
            animator.SetFloat("rotation", (angle * Mathf.Deg2Rad));

            if (Vector2.Distance(transform.position, wPoints.waypoints[waypointIndex].position) < 0.01f)
            {

                if (waypointIndex < wPoints.waypoints.Length - 1)
                {
                    waypointIndex++;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("colliding");
            animator.SetBool("combat", true);
        }
    }
}

