using System.Collections;
using UnityEngine;

public class attack : MonoBehaviour
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

    }

   
}
