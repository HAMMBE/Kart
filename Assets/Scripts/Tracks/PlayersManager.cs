using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    [SerializeField]
    private int playersCount = 0;

    [SerializeField]
    private List<GameObject> players;
    
    [SerializeField]
    private List<GameObject> playersFinished;
    // Start is called before the first frame update
    void Start()
    {
        players = new List<GameObject>();
    }
    
    public void CountPlayers()
    {
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        playersCount = players.Count;
    }

    public void PlayerFinished(GameObject player)
    {
        playersFinished.Add(player);
        if (playersFinished.Count == playersCount)
        {
            //GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
            Debug.Log("Tous les joueurs ont fini");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
