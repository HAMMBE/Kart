using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champignon : IObject
{

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public override void Execute(GameObject player)
    {
        Rigidbody carRbdy = player.GetComponent<Rigidbody>();
        //carRbdy.AddForce(Vector3.up * 10, ForceMode.Impulse);
        
        carRbdy.velocity += carRbdy.transform.forward * 20;
        
    }
}
