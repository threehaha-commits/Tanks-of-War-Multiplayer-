using UnityEngine;

public static class Vector2Extension
{
    public static Vector3 MinScreenBorder(this Vector3 minBorder)
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
    }
    
    public static Vector3 MaxScreenBorder(this Vector3 maxBorder)
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
    }

    public static Vector3 RandomScreenPosition(this Vector3 randomPosition)
    {
        Vector2 min = new Vector3().MinScreenBorder();
        Vector2 max = new Vector3().MaxScreenBorder();
        var x = Random.Range(min.x, max.x);
        var y = Random.Range(min.y, max.y);
        return new Vector2(x, y);
    }
}