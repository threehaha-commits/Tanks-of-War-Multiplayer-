using Photon.Pun;
using UnityEngine;

public class PlayerGroup : MonoBehaviour
{
    public int Group { get; private set; }
    private int index;
    private int Index => index.PlayerIndex();
    private PhotonView View;

    private void Start()
    {
        View = gameObject.GetPhotonView();
        View.RPC("SetPlayerGroup", RpcTarget.AllBuffered, Index);
    }
    
    [PunRPC]
    private void SetPlayerGroup(int index)
    {
        Group = index;
        gameObject.name = gameObject.name + " " + Group;
    }
}