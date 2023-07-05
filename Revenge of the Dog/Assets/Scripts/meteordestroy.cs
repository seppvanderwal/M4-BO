using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteordestroy : MonoBehaviour
{
    public int hp;
    public int maxhp = 3;
    public int damage;

    void Start()
    {
        hp = maxhp;
    }

    
    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Attack")
        {
            TakeDamage(damage);
        }
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            //Destroy(this.gameObject);
        }
    }

    
    private void Update()
    {
       
    }
}
    
