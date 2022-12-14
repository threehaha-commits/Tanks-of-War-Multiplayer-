using Photon.Pun;
using UnityEngine;

public class PhotonSerialize : MonoBehaviour, IPunObservable
{
    private Vector3 Pos = Vector3.zero;
    private Quaternion Rot = Quaternion.identity;
    private readonly float LerpValue = 15;
    protected PhotonView photonView;
    protected Transform myTransform;

    private void Awake()
    {
        PhotonNetwork.SendRate = 40;
        PhotonNetwork.SerializationRate = 20;
        myTransform = transform;
        photonView = gameObject.GetPhotonView();
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            myTransform.position = Vector3.Lerp(myTransform.position, Pos, LerpValue * Time.fixedDeltaTime);
            myTransform.rotation = Quaternion.Lerp(myTransform.rotation, Rot, LerpValue * Time.fixedDeltaTime);
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            Pos = (Vector3)stream.ReceiveNext();
            Rot = (Quaternion)stream.ReceiveNext();
        }
    }
}
