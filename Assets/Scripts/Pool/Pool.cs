using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Pool<T>
{
    private T[] Items;
    
    public Pool(T[] items)
    {
        Items = items;
    }

    public T Get(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        var item = GetInactiveObjectFromPool() as GameObject;
        item.transform.position = spawnPosition;
        item.transform.rotation = spawnRotation;
        item.SetActive(true);
        return GetInactiveObjectFromPool();
    }

    private T GetInactiveObjectFromPool()
    {
        foreach (var item in Items)
        {
            var i = item as GameObject;
            if (i.activeInHierarchy == false)
                return item;
        }

        return Items[5];
    }
}