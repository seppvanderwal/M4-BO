using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;


public class Laser : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public GameObject StartVFX;
    public GameObject EndVFX;
    public float cooldown;
    public float lastShot;

    private List<ParticleSystem> particles = new List<ParticleSystem>();
    private bool canShoot = true;

    void Start()
    {
        
        FillLists();
        DisableLaser();
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot == true)
        {
            EnableLaser();
           
        }

        if (Input.GetButton("Fire1"))
        {
            UpdateLaser();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            canShoot= false;
            DisableLaser();
            
        }

        

    }
 
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
    
        void EnableLaser()
        {
        if (Time.time - lastShot < cooldown)
        {
            return;
        }
        lastShot = Time.time;
            lineRenderer.enabled = true;

        for (int i = 0; i < particles.Count; i++)
            particles[i].Play();
        }

        void UpdateLaser()
        {
            var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);    

            lineRenderer.SetPosition(0,(Vector2)firePoint.position);
            StartVFX.transform.position = (Vector2)firePoint.position;

            lineRenderer.SetPosition(1, mousePos);

            Vector2 direction = mousePos - (Vector2)transform.position;
            RaycastHit2D hit = Physics2D.Raycast((Vector2)firePoint.position, direction.normalized, direction.magnitude);

        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }

            EndVFX.transform.position = lineRenderer.GetPosition(1);
        }

        void DisableLaser()
        {
            lineRenderer.enabled = false;

        for (int i = 0; i < particles.Count; i++)
            particles[i].Stop();
            StartCoroutine(Cooldown());
        }

        void FillLists()
        {
            for(int i=0; i<StartVFX.transform.childCount; i++)
        {
            var ps = StartVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps != null)
            {
                particles.Add(ps);
            }
        }
        
        for (int i = 0; i < EndVFX.transform.childCount; i++)
            {
                var ps = EndVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    particles.Add(ps);
                }
            }
        }
}