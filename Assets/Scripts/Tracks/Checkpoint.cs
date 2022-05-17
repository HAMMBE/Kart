using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public int checkpointNumber;
    public TextMesh text;
    
    //Show the number of the checkpoint
    void Start()
    {
        text.text = "" + checkpointNumber;
    }
}
