using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PoolCreator<T> where T : Object
{
    private const int PoolItemCount = 15;
    private List<T> Items = new List<T>();
    
    public PoolCreator(T[] poolObject)
    {
        CreateNewPoolObjects(poolObject);
    }

    private void CreateNewPoolObjects(T[] poolObject)
    {
        for(int i = 0; i < poolObject.Length; i++)
        {
            for (int j = 0; j < PoolItemCount; j++)
            {
                var item = PhotonNetwork.Instantiate(poolObject[i].name, Vector3.zero, Quaternion.identity);
                item.name = poolObject[i].name;
                item.SetActive(false);
                Items.Add(item as T);
            }
        }
    }

    public T[] GetObjectsFromPool()
    {
        return Items.ToArray();
    }
}