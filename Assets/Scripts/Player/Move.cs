using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Move : MonoBehaviour
{
    private Rigidbody2D r2d;
    [SerializeField] private float Speed;
    [SerializeField] private float RotateSpeed;
    private Transform MyTransform;
    
    private void Start()
    {
        MyTransform = transform;
        r2d = GetComponent<Rigidbody2D>();
    }

    public void Moving(Quaternion rotation)
    {
        Quaternion rotate = Quaternion.Lerp(MyTransform.rotation, rotation, RotateSpeed * Time.fixedDeltaTime);
        r2d.velocity = MyTransform.up * Speed * Time.fixedDeltaTime;
        MyTransform.rotation = rotate;
    }
}