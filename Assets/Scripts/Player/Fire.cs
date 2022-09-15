using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(FireController))]
public class Fire : MonoBehaviour
{
    private Pool<GameObject> BulletPool;
    private PhotonView View;
    public IBulletIdentify BulletIdentify { get; set; }
    private Transform BulletSpawnPosition;

    private void Start()
    {
        View = GetComponent<PhotonView>();
        BulletSpawnPosition = transform.GetChild(0);
    }

    public void Attack(Quaternion rotation)
    {
        View.RPC("Shot", RpcTarget.All, gameObject.name, BulletSpawnPosition.position, rotation);
    }
    
    [PunRPC]
    private void Shot(string name, Vector3 position, Quaternion rotation)
    {
        var player = GameObject.Find(name);
        var pool = player.GetComponent<Fire>().BulletPool;
        var bulletObjectFromIdentify = player.GetComponent<Fire>().BulletIdentify.Bullet;
        var bulletTransform = pool.Get(bulletObjectFromIdentify).transform;
        bulletTransform.position = position;
        bulletTransform.rotation = rotation;
    }
}