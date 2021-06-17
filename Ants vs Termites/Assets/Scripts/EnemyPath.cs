using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
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
        waypointIndex = wPoints.waypoints.Length - 1;
    }

    // Update is called once per frame
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
                if (waypointIndex > 0)
                {
                    waypointIndex--;
                }
                else
                {
                    Destroy(gameObject);
                    PlayerPrefs.SetFloat("Repellent", (PlayerPrefs.GetFloat("Repellent") - 1));
                    statsManager.killCount++;
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    { 
        if (collision.gameObject.tag.Equals("Ally"))
        {
            animator.SetBool("combat", true);
            stats.TakeDamage();
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
