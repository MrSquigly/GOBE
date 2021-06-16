using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class followPath : MonoBehaviour
{

    statsManager stats;

    public float speed;

    public Animator animator;

    private Waypoints wPoints;

    private int waypointIndex;

    public BoxCollider2D allyBox;

    public BoxCollider2D enemyBox;

    void Start()
    {
        stats = GetComponent<statsManager>();
        wPoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    void Update()
    {
        animator.SetFloat("speed", speed);

        if (animator.GetBool("combat") == true || animator.GetBool("dead") == true)
        {

            speed = 0;
        }
        
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, wPoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

            Vector2 dir = wPoints.waypoints[waypointIndex].position - transform.position;
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90;
            animator.SetFloat("rotation", (angle * Mathf.Deg2Rad));

            if (Vector2.Distance(transform.position, wPoints.waypoints[waypointIndex].position) < 0.1f)
            {

                if (waypointIndex < wPoints.waypoints.Length - 1)
                {
                    waypointIndex++;
                }
                else
                {
                    Destroy(gameObject);
                    PlayerPrefs.SetFloat("Interval", PlayerPrefs.GetFloat("Interval") * 0.95f);
                }
            }
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            animator.SetBool("combat", true);
            stats.TakeDamage(stats.attackDamage);
        }
    }

    void FixedUpdate()
    {
        if (speed == 0 && allyBox.IsTouching(enemyBox) == false)
        {
            speed = 5;
            animator.SetBool("combat", false);
        }
    }
}


