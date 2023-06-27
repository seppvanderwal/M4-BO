using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyattackboss : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(Destroy());
    }

    
  
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Object.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Attack")
        {
            Object.Destroy(this.gameObject);
        }
    }
}
