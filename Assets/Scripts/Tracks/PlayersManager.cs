using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayersManager : MonoBehaviour
{
    [SerializeField]
    private int playersCount = 0;

    [SerializeField]
    private List<GameObject> players;
    
    [SerializeField]
    private List<GameObject> playersFinished;

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
        if (playersFinished.Contains(player))
        {
            return;
        }

        playersFinished.Add(player);
        if (playersFinished.Count == playersCount)
        {
            GameObject endScreen = GameObject.FindGameObjectWithTag("Finish").transform.GetChild(0).gameObject;
            endScreen.SetActive(true);
            TextMeshProUGUI text = endScreen.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            int i = 0;
            foreach (var p in playersFinished)
            {
                i++;
                text.text +=  "\n" + i + ". " + p.name;
            }
        }
    }
    public void returnToMenu()
    {
        SceneManager.LoadScene("Menu/Assets/Scenes/Menu/MainMenu");
    }
}
