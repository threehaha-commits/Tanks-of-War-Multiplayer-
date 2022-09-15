using UnityEngine;
using Photon.Pun;

public class TestTank : MonoBehaviour
{
    private void Update()
    {
        if (PhotonNetwork.CountOfPlayersInRooms == 2)
        {
            gameObject.SetActive(false);
        }
    }
}
