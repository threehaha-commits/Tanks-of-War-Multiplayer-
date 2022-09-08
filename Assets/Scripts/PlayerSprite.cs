using Photon.Pun;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private  Sprite[] Sprite;
    private SpriteRenderer Renderer;
    private PhotonView View;
    private int index;
    
    private void Start()
    {
        View = gameObject.GetPhotonView();
        if (!View.IsMine)
            return;
        View.RPC("SetSprite", RpcTarget.AllBuffered, index.PlayerIndex());
    }

    [PunRPC]
    private void SetSprite(int index)
    {
        Renderer = GetComponent<SpriteRenderer>();
        Renderer.sprite = Sprite[index];
    }
}