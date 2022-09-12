using UnityEngine;

public class PoolStarter : MonoBehaviour
{
    [SerializeField] private GameObject[] ItemsForPool;
    [SerializeField] private MonoBehaviour MonoForPool;
    private PoolCreator<GameObject> Pool;
    
    private void Start()
    {
        Pool = new PoolCreator<GameObject>(ItemsForPool);
        var items = Pool.GetObjectsFromPool();
        FieldAssigner.AssignValueToField(MonoForPool, typeof(Pool<GameObject>), new Pool<GameObject>(items));
    }
}