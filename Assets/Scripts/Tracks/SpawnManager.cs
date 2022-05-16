using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] carPrefab;
    [SerializeField]private InfoToPass infoToPass;
    // Start is called before the first frame update
    void Start()
    {
        int carToSpawn1 = infoToPass.carP1;
        Transform spawn1 = transform.GetChild(0).transform;
        
        GameObject car1 = Instantiate(carPrefab[carToSpawn1], spawn1.position, spawn1.rotation);
        car1.name = "Player 1";
        if (infoToPass.nbPlayers > 1)
        {
            int carToSpawn2 = infoToPass.carP2;
            Transform spawn2 = transform.GetChild(1).transform;
            GameObject car2 = Instantiate(carPrefab[carToSpawn2], spawn2.position, spawn2.rotation); 
            car2.transform.GetChild(0).GetComponent<AudioListener>().enabled = false;
            car2.name = "Player 2";
        }
        GetComponent<PlayersManager>().CountPlayers();
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
