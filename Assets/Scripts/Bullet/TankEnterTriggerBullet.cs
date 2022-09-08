using Photon.Pun;
using UnityEngine;

public class TankEnterTriggerBullet : MonoBehaviour
{
    private PhotonView View;
    public BulletVisual Image { private get; set; }
    private Attack Attack;
    
    private void Start()
    {
        View = gameObject.GetPhotonView();
        Attack = GetComponent<Attack>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet Item"))
            return;
        
        Debug.Log(Time.time);

        Attack.BulletIdentify = collision.GetComponent<IBulletIdentify>();
        Image?.SetImage(collision.GetComponent<SpriteRenderer>().sprite);
        collision.gameObject.SetActive(false);
    }
}