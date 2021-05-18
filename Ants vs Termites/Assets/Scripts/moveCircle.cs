using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCircle : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 15f;
    

    Vector2 movement;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
