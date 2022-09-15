using Photon.Pun;
using UnityEngine;

public class PlayerGroup : MonoBehaviour, IPunObservable
{
    public int Group { get; private set; }
    private int index;
    private int Index => index.PlayerIndex();

    private void Start()
    {
        Group = Index;
    }
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            stream.SendNext(Group);
        }
        else
        {
            Group = (int)stream.ReceiveNext();
        }
    }
}