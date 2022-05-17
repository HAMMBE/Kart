using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : IObject
{
    
    public override void Execute(GameObject player)
    {
        List<GameObject> listPlayers = new List<GameObject>();
        listPlayers.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        foreach (GameObject p in listPlayers)
        {
            if (!player.Equals(p))
            {
                p.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            
        }
    }
}
