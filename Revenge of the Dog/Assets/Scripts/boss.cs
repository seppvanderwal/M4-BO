using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public int hp;
    public int maxhp;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

    public void Phase2()
    {

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
        if(hp <= 25)
        {
            Phase2();
        }

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
