using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private float direction = 0f;

    private float inputHorizontal;
    private float inputVertical;
    private bool facingRight = true;

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
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            float force = 5f;
            rb.velocity = Vector2.up * force;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bone")
        { 
            collision.gameObject.SetActive(false);
            ScoreManager.instance.AddPoint(this);  
        }
    }

    private void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (inputHorizontal > 0)
        {
            Flip();
        }

        if (inputHorizontal < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentscale = gameObject.transform.localScale;
        currentscale.x *= -1;
        gameObject.transform.localScale = currentscale;

        facingRight = !facingRight;
    }
}