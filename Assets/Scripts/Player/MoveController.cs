using Photon.Pun;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private RaycastHelper RayHelper;
    private RotationHelper RotateHelper;
    private PhotonView View;
    private Move Mover;
    
    private void Start()
    {
        Mover = GetComponent<Move>();
        View = GetComponent<PhotonView>();
        RayHelper = new RaycastHelper(transform);
        RotateHelper = new RotationHelper(transform);

        if (!View.IsMine)
            enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = RayHelper.GetMouseHit();

            if (!hit.collider.CompareTag("Player"))
            {
                Mover.Moving(RotateHelper.GetRotation());
            }
        }
    }
}