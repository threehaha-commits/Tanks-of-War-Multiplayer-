using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(ClickHandler))]
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
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!View.IsMine) 
                return;
            
            RaycastHit2D hit = RayHelper.GetMouseHit();

            if (!hit.collider.CompareTag("Player"))
            {
                Mover.Moving(RotateHelper.GetRotation());
            }
        }
    }
}