using Photon.Pun;
using UnityEngine;

public class Attack : PhotonSerialize
{
    public IBulletIdentify BulletIdentify { private get; set; }
    [SerializeField] private Transform BulletSpawnPosition;
    private float ReloadTime;
    private float MaxReloadTime = 0.15f;
    private RaycastHelper RayHelper;
    private RotationHelper RotateHelper;
    
    void Start()
    {
        RayHelper = new RaycastHelper(transform);
        RotateHelper = new RotationHelper(transform);
        ReloadTime = MaxReloadTime;
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            if (ReloadTime > 0)
            {
                ReloadTime -= Time.deltaTime;
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                myTransform.rotation = RotateHelper.GetRotation();
                RaycastHit2D hit = RayHelper.Hit(BulletSpawnPosition);
                if (hit == false)
                    return;
                if (hit.collider.tag == "Player" && hit.collider.gameObject != gameObject)
                {
                    Debug.Log(BulletIdentify.Bullet.ToString());
                    PhotonNetwork.Instantiate(BulletIdentify.Bullet.name, BulletSpawnPosition.position, RotateHelper.GetRotation());
                    ReloadTime = MaxReloadTime;
                }
            }
        }
    }
}
