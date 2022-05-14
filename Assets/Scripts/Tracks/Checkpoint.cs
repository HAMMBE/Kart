using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public int checkpointNumber;
    public TextMesh text;
    
    void Start()
    {
        text.text = "" + checkpointNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
