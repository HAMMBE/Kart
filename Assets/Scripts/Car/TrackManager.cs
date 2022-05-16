using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class 
TrackManager : MonoBehaviour

{
    private int currentCheckpoint;
    private int currentLap;
    private int nbCheckpoints;
    private Checkpoint lastCheckpoint;
    private int nbLaps;

    public GameObject lapCounterDisplay;
    // Start is called before the first frame update
    void Start()
    {
        lastCheckpoint = null;
        currentCheckpoint = 0;
        currentLap = 0;
        
        List<GameObject> listCheckpoint = new List<GameObject>(); 
        listCheckpoint.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));
        nbCheckpoints = listCheckpoint.Count;

        nbLaps = GameObject.FindGameObjectWithTag("FinishLine").GetComponent<FinishLine>().maxLap;
        
        UpdateLapUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRespawn(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (lastCheckpoint != null)
            {
                Transform player = GetComponent<Transform>();
                Transform child = lastCheckpoint.transform.GetChild(3).transform;
                player.position = child.position;
                player.rotation = child.rotation;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            Checkpoint checkpointTrigger = other.GetComponent<Checkpoint>();
            if (currentCheckpoint == checkpointTrigger.checkpointNumber - 1)
            { 
                    lastCheckpoint = checkpointTrigger;
                    currentCheckpoint++;
            }
            else
            {
                Debug.Log("Checkpoint error");
            }
            
        }else if (other.CompareTag("FinishLine"))
        {
            if (currentCheckpoint == nbCheckpoints)
            {
                if (currentLap >= other.GetComponent<FinishLine>().maxLap)
                {
                    GameObject.Find("PlayerManager").GetComponent<PlayersManager>().PlayerFinished(gameObject);
                    //Destroy(gameObject);
                    Debug.Log("Finish");
                    UpdateLapUI();
                }
                else
                {
                    Debug.Log("Lap");
                    currentLap++;
                    currentCheckpoint = 0;
                    UpdateLapUI();
                }
            }
            else
            {
                Debug.Log("T'as raté un checkpoint frerot");
            }
        }
    }
    
    public void UpdateLapUI()
    {
        lapCounterDisplay.GetComponent<Text>().text = "Lap " + (currentLap + 1) + "/" + (nbLaps + 1);
    }
}
