using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBoss : MonoBehaviour
{
    public int hp;
    public int maxhp = 3;
    public int damage;  
    void Start()
    {
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
        }
    }
    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
