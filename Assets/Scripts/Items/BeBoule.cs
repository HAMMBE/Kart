using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeBoule : IObject
{
    public GameObject greenShellPrefab;
    public GameObject _firePoint;
    private GameObject go;
    private Vector3 carRbVel;

    public override void Execute(GameObject gameO)
    {
        Debug.Log("J'envoie PowerUp");
        
        go = Instantiate(greenShellPrefab,gameO.transform.GetChild(2).transform.position, gameO.transform.GetChild(2).transform.rotation); 
        carRbVel = gameO.GetComponent<Rigidbody>().velocity;
        go.GetComponent<Rigidbody>().AddForce(carRbVel*1.10f, ForceMode.VelocityChange);
        
    }

    public void FixedUpdate()
    {
       if (go != null && go.GetComponent<Rigidbody>().velocity.magnitude < 60f)
       {
            go.GetComponent<Rigidbody>().AddForce(carRbVel*1.10f, ForceMode.VelocityChange);
       }
    }
}
