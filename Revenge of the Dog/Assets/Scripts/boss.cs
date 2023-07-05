using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public int hp;
    public int maxhp;
    public int damage;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
        animator= GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        animator.SetTrigger("TriggerDamage"); 
    }
   
    void Attack()
    {
        if (hp > 25)
        {
            animator.SetInteger("Idle", Random.Range(0, 100));
            animator.SetInteger("Attack", Random.Range(0, 100));
        }  
    }  



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Attack")
        {
            TakeDamage(damage);
        }
    }

    private void Update()
    {
        Attack();

        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
