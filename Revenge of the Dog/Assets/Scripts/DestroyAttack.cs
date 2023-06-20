using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Destroy()
        {
            yield return new WaitForSeconds(1);
            Object.Destroy(this.gameObject);
        }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "boss")
        {
            Object.Destroy(this.gameObject);
        }
    }
}
