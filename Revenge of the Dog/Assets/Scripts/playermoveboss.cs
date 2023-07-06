using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermoveboss : MonoBehaviour
{
    public float speed = 5f;
    private float direction = 0f;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        }
        else if (direction < 0f)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        }
        direction = Input.GetAxis("Vertical");

        if (direction > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x ,direction * speed );
        }
        else if (direction < 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, direction * speed);
        }
    }
}
