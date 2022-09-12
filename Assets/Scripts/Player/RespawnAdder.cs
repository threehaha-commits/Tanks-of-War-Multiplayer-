using UnityEngine;

public class RespawnAdder : MonoBehaviour
{
    private void Awake()
    {
        RespawnPlayers respawner = FindObjectOfType<RespawnPlayers>();
        respawner.AddPlayer(gameObject);
    }
}