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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 v2 = ray.origin - transform.position;
        Quaternion rotation = Quaternion.LookRotation(v2, Vector3.forward);
        return rotation;
    }
}