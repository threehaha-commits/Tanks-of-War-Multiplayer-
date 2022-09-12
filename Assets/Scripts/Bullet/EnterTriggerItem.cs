using Photon.Pun;
using UnityEngine;

public class EnterTriggerItem : MonoBehaviour
{
    private PhotonView View;
    public BulletVisual Image { private get; set; }
    private Fire Fire;
    
    private void Start()
    {
        View = gameObject.GetPhotonView();
        Fire = GetComponent<Fire>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet Item"))
            return;

        Fire.BulletIdentify = collision.GetComponent<IBulletIdentify>();
        Image?.SetImage(collision.GetComponent<SpriteRenderer>().sprite);
        collision.gameObject.SetActive(false);
    }
}