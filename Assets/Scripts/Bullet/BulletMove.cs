using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private readonly float Speed = 700f;
    private Rigidbody2D r2d;
    private Transform MyTransform;

    private void Start()
    {
        MyTransform = transform;
        r2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        r2d.velocity = MyTransform.forward * Speed * Time.fixedDeltaTime;
    }
}