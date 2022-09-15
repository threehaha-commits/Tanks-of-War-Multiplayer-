using UnityEngine;

public class Pool<T>
{
    private T[] Items;
    
    public Pool(T[] items)
    {
        Items = items;
    }

    public T Get(T returnedObject)
    {
        return GetInactiveObjectFromPool(returnedObject);
    }

    private T GetInactiveObjectFromPool(T returnedObject)
    {
        var objectGameObject = returnedObject as GameObject;
        var objectName = objectGameObject.name;
        
        foreach (var item in Items)
        {
            var itemGameObject = item as GameObject;
            var itemName = itemGameObject.name;
            if(itemName != objectName)
                continue;
            
            var iterationItem = item as GameObject;
            if (iterationItem.activeInHierarchy == false)
            {
                iterationItem.SetActive(true);
                return item;
            }
        }

        return Items[0];
    }
}