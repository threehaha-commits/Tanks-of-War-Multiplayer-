using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHelper
{
    private Transform transform;
    private const float RayDistance = 15f;

    public RaycastHelper(Transform transform)
    {
        this.transform = transform;
    }

    public RaycastHit2D GetHitFromForward()
    {
        var layer = 1 << 6;
        layer = ~layer;
        return Physics2D.Raycast(transform.position, transform.forward * RayDistance, Mathf.Infinity, layer);
    }

    public RaycastHit2D GetMouseHit() 
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), -Vector2.up);
    }
}