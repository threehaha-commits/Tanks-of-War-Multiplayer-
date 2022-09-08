using Photon.Pun;
using UnityEngine;

public class PlayerPosition : MonoBehaviour, IPunObservable
{
    private Vector2 startPosition = Vector2.zero;
    private Vector2 StartPosition
    {
        get
        {
            
            if(startPosition != Vector2.zero)
                return startPosition;
            
            int index = 0;
            index = index.PlayerIndex();
            if (index == 0)
                startPosition = GameObject.Find("L_SpawnPoint").transform.position;
            else
                startPosition = GameObject.Find("R_SpawnPoint").transform.position;
            return startPosition;
        }
    }
    private Vector3 position;
    public RoundEventViewer _roundManager { private get; set; }
    private PhotonView photonView;

    private void Start()
    {
        photonView = gameObject.GetPhotonView();
        if (!photonView.IsMine)
            return;
        transform.position = position = StartPosition;
        _roundManager.AddListener(ReturnPlayerToStartPosition, 0);
    }
    
    private void ReturnPlayerToStartPosition()
    {
        transform.position = position;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}