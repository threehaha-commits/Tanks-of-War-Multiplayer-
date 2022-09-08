using Photon.Pun;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float Speed = 40f;
    [SerializeField] private float RotateSpeed = 2f;
    private Rigidbody2D r2d;
    private RaycastHelper RayHelper;
    private RotationHelper RotateHelper;
    private Transform MyTransform;
    [SerializeField] private PhotonView View;
    
    private void Start()
    {
        MyTransform = transform;
        View = gameObject.GetPhotonView();
        RayHelper = new RaycastHelper(transform);
        RotateHelper = new RotationHelper(transform);
        r2d = GetComponent<Rigidbody2D>();
        MyTransform.rotation = RotateHelper.GetRotation();
    }

    private void FixedUpdate()
    {
        if (!View.IsMine) 
            return;
        
        Moving();
    }
 
    private void Moving()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = RayHelper.Hit();

            if (!hit.collider.CompareTag("Player"))
            {
                Quaternion rotation = Quaternion.Lerp(MyTransform.rotation, RotateHelper.GetRotation(), RotateSpeed * Time.deltaTime);
                r2d.velocity = MyTransform.up * Speed * Time.fixedDeltaTime;
                MyTransform.rotation = rotation;
            }
        }
    }
}
