using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserboss : MonoBehaviour
{
    public GameObject attackPrefab;
    public Transform attackSpawnPoint;
    public GameObject laika;



    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();

        }
    }

    void Fire()
    {
        
        GameObject attack = Instantiate(attackPrefab, attackSpawnPoint.position, attackSpawnPoint.rotation);
        Rigidbody2D attackRB = attack.GetComponent<Rigidbody2D>();
        Rigidbody2D laikaRB = laika.GetComponent<Rigidbody2D>();
        attackRB.velocity = new Vector2(5, 0);
        attackRB.AddForce(attackRB.velocity);
    }
}
