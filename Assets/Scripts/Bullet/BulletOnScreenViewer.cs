using UnityEngine;

public class BulletOnScreenViewer : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}