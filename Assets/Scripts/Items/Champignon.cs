using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champignon : IObject
{
    public override void Execute(GameObject player)
    {
        Rigidbody carRbdy = player.GetComponent<Rigidbody>();
        carRbdy.velocity += carRbdy.transform.forward * 20;
        
    }
}
