using UnityEngine;

public class RotationHelper
{
    private Transform transform;
    public RotationHelper(Transform transform)
    {
        this.transform = transform;
    }
    
    public Quaternion GetRotation()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var v2 = ray.origin - transform.position;
        var rotation = Quaternion.LookRotation(v2, Vector3.forward);
        return rotation;
    }
}