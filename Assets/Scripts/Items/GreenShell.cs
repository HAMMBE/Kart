using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenShell : MonoBehaviour
{
    // Start is called before the first frame update
    public int nbBonce;

    private Rigidbody rb;
    private PIDController pid;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pid = new PIDController();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Function to get the shell to hover
        float speed = Vector3.Dot(rb.velocity, transform.forward);
        float propulsion = 17f - 1.7f * Mathf.Clamp(speed, 50f, 1000f);
        RaycastHit groundHit;

        if (Physics.Raycast(transform.position, -transform.up, out groundHit, 1f))
        {
            float height = groundHit.distance;
            float hoverHeight = 1.5f;
            float hoverForce = 300f;
            
            Vector3 groundNormal = groundHit.normal.normalized;
            float forcePercent = pid.Seek(hoverHeight, height);
            Vector3 force = groundNormal * hoverForce * forcePercent;
            Vector3 gravity = -groundNormal * 20f * height;

            rb.AddForce(force, ForceMode.Acceleration);
            rb.AddForce(gravity, ForceMode.Acceleration);
        }
        else
        {
            Vector3 groundNormal = Vector3.up;
            Vector3 gravity = -groundNormal * 80f;
            
            rb.AddForce(gravity, ForceMode.Acceleration);
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(gameObject);
        }
        else
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Vector3 reflectDir = Vector3.Reflect(transform.forward, contact.normal);
                transform.LookAt(reflectDir + transform.position);
            }
            
            nbBonce--;
            if (nbBonce < 1)
            {
                Destroy(gameObject);
            } 
        }
    }
}

