using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthBoss : MonoBehaviour
{
    public int hp;
    public int maxhp = 3;
    public int damage; 
    public Animator animator;

    //Timer
    float delay = 0.2f;
    private float timer = 0.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        hp = maxhp;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "meteor")
        {
            TakeDamage(damage);
            animator.SetBool("Spaceship_Damage", true);           
        }
    }
        
    private void Update()
    {
        if (hp <= 0)
        {
            timer += Time.deltaTime;
            gameObject.SetActive(false);

            //if (timer > delay)
            //{
                SceneManager.LoadScene("Gameover");
           // }
        }
    }
}
