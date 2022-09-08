using Photon.Pun;
using UnityEngine;

public class PlayerFabric
{
    private readonly GameObject NewPlayer;
    
    public PlayerFabric(GameObject player)
    {
        NewPlayer = player;
    }
    
    public PhotonView Create()
    {
        var player = PhotonNetwork.Instantiate(NewPlayer.name, Vector2.zero, new Quaternion(0, 0, 0, 0));
        return player.GetPhotonView();
    }
}