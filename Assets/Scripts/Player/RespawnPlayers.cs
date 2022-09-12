using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayers : MonoBehaviour
{
    [SerializeField] private RoundEventViewer Viewer;
    public List<GameObject> Players = new List<GameObject>();
    
    private void Start()
    {
        Viewer.AddListener(Respawn, 0);   
    }

    public void AddPlayer(GameObject player)
    {
        Players.Add(player);
    }
    
    private void Respawn()
    {
        foreach (var player in Players)
        {
            player.SetActive(true);
        }
    }
}