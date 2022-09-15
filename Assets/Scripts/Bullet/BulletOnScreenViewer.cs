using Photon.Pun;
using UnityEngine;

public class BulletOnScreenViewer : MonoBehaviour
{
    private RoundEventViewer RoundViewer;
    
    private void Awake()
    {
        if (gameObject.GetPhotonView().IsMine == false)
            gameObject.SetActive(false);
        RoundViewer = FindObjectOfType<RoundEventViewer>();
        RoundViewer.AddListener(DeactivateBullet, 1);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void DeactivateBullet()
    {
        gameObject.SetActive(false);
    }
}