using System.Linq;
using Photon.Pun;
using UnityEngine;

public class ItemFactory
{
    private GameObject[] Items;
    
    public ItemFactory(GameObject[] items)
    {
        Items = items.ToArray();
    }
    
    public void Create()
    {
        int random = Random.Range(0, Items.Length);
        PhotonNetwork.Instantiate(Items[random].name, new Vector3().RandomScreenPosition(), Quaternion.identity);
    }
}