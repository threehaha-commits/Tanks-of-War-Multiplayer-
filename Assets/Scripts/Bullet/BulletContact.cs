using Photon.Pun;
using UnityEngine;

public class BulletContact : MonoBehaviourPun
{
    [SerializeField] private int Damage;
    private GameObject Target;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Target = collision.gameObject;
        photonView.RPC("DeactiveBullet", RpcTarget.AllViaServer);
    }

    [PunRPC]
    private void DeactiveBullet()
    {
        Target?.gameObject.GetComponent<DamageHandler>()?.ApplyDamage(Damage);
        gameObject.SetActive(false);
    }
}