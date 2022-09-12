using System;
using Photon.Pun;
using UnityEngine;

public class BulletOnScreenViewer : MonoBehaviour
{
    private void Awake()
    {
        if (gameObject.GetPhotonView().IsMine == false)
            gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}