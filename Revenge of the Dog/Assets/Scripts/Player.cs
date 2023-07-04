using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject deathLocation;
    [SerializeField] AudioSource[] music; 

    public GameObject[] hearts;
    public int maxHealth = 3;
    public int health;

    public float speed = 5f;
    private float direction = 0f;

    private float inputHorizontal, inputVertical;
    

    //Timer
    float delay = 3.0f;
    private float timer = 0.0f;

    private Animator anim;
    private SpriteRenderer s;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        s = GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();

        health = maxHealth;
    }

    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        //Walking
        if (direction > 0f)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            anim.SetTrigger("run");
            
        }
        else if (direction < 0f)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            anim.SetTrigger("run");

        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetTrigger("Idle");
        }

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            float force = 7f;
            rb.velocity = Vector2.up * force;
            
        }
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            music[4].Play();
            anim.SetTrigger("Jump");
            anim.ResetTrigger("run");
        }
        

        FlipSprite();
        //Health system
        if (health <= 0)
        {
            timer += Time.deltaTime;
            music[3].Play();

            if (timer > delay)
            {
                SceneManager.LoadScene("GameOver Screen");
            }
        }
        IdleSwitch();
    }


    void IdleSwitch()
    {    
            anim.SetInteger("IdleSwitch", Random.Range(0,10));
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health == 1)
        {
            anim.SetTrigger("isDamaged");
            hearts[2].SetActive(false);
            //getHit.Play();
            music[0].Play();
        }
        if(health == 2)
        {
            anim.SetTrigger("isDamaged");
            hearts[1].SetActive(false);
            //getHit.Play();
            music[0].Play();
        }
        if(health == 0)
        {
            gameObject.transform.localScale= new Vector3( 0.8f, 0.8f, 0.8f);
            gameObject.transform.position = deathLocation.transform.position;
            speed = 0;
            Destroy(hearts[2]);
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            anim.SetTrigger("isDead");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bone")
        { 
            collision.gameObject.SetActive(false);
            ScoreManager.instance.AddPoint(this);
            //boneCollection.Play();
            music[1].Play();
        }
        if(collision.tag == "GoldenBone")
        {
            collision.gameObject.SetActive(false);
            ScoreManager.instance.GoldenBone(this);
            // boneCollection.Play();
            music[1].Play();
        }
        if(collision.tag == "Heart")
        {
            health += 1;
            if (health <= 1)
            {
                collision.gameObject.SetActive(false);
                hearts[0].SetActive(true);
                //healthPoint.Play();
                music[2].Play();
            }
            if(health <=2)
            {
                collision.gameObject.SetActive(false);
                hearts[1].SetActive(true);
                //healthPoint.Play();
                music[2].Play();
            }
        }
    }

    private void FlipSprite()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal > 0)
        {
            s.flipX= false;
        }

        if (inputHorizontal < 0)
        {
            s.flipX= true;
        }
    }
}