using Photon.Pun;
using UnityEngine;

public class FireController : MonoBehaviour
{
    private PhotonView View;
    private Fire Fire;
    private RotationHelper RotateHelper;
    private Reloader Reloader = new Reloader();
    
    void Start()
    {
        View = GetComponent<PhotonView>();
        Fire = GetComponent<Fire>();
        RotateHelper = new RotationHelper(transform);
    }

    private void Update() 
    {
        if (View.IsMine)
        {
            if (Reloader.IsReload)
                return;

            if (Input.GetMouseButton(1))
            {
                transform.rotation = RotateHelper.GetRotation();
                Fire.Attack(RotateHelper.GetRotation());
                Reloader.StartReload();
            }
        }
    }
}