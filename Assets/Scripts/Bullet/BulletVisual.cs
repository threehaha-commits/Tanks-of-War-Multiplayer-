using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletVisual
{
    private Image Image;

    public BulletVisual(Image image)
    {
        Image = image;
    }
    
    public void SetImage(Sprite sprite)
    {
        Image.sprite = sprite;
    }
}
