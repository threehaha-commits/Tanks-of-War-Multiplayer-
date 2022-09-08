using UnityEngine;

public interface IBulletIdentify
{
    GameObject Bullet { get; set; }
}

public class BulletItem : Item, IBulletIdentify
{
    GameObject IBulletIdentify.Bullet
    {
        get => BulletObject.Bullet;
        set => BulletObject.Bullet = value;
    }

    [SerializeField] private BulletScriptableObject BulletObject;
}