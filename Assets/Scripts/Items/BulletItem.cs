using UnityEngine;

public interface IBulletIdentify
{
    GameObject Bullet { get;}
}

public class BulletItem : MonoBehaviour, IBulletIdentify
{
    GameObject IBulletIdentify.Bullet => BulletObject.Bullet;

    [SerializeField] private BulletScriptableObject BulletObject;
}