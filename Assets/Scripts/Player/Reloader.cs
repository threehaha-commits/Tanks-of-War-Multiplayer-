using System.Threading.Tasks;
using UnityEngine;

public class Reloader
{ 
    private float ReloadTime = 0.18f;

    private int ReloadTimeInMilliseconds => Mathf.RoundToInt(ReloadTime * 1000);

    public bool IsReload { get; private set; } = false;
    
    public async void StartReload()
    {
        IsReload = true;
        await Task.Delay(ReloadTimeInMilliseconds);
        IsReload = false;
    }
}