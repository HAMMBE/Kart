using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeBoule : IObject
{
    public GameObject greenShellPrefab;
    public GameObject _firePoint;

    

    public override void Execute(GameObject gameO)
    {
        Debug.Log("J'envoie PowerUp");
        
        GameObject go = Instantiate(greenShellPrefab,gameO.transform.GetChild(2).transform.position, gameO.transform.GetChild(2).transform.rotation); 
        Rigidbody carRb = gameO.GetComponent<Rigidbody>();
        go.GetComponent<Rigidbody>().AddForce(carRb.velocity*2, ForceMode.VelocityChange);
    }
}
