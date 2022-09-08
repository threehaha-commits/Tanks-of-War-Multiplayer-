using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerInstaller : MonoInstaller//, IInitializable
{
    private Image Image;
    
    public override void InstallBindings()
    {
        //Container.Bind<PlayerInstaller>().FromInstance(this).AsSingle().NonLazy();
    }

    public void Initialize()
    {
        //Container.Bind<BulletVisual>().FromInstance(new BulletVisual(Image)).AsSingle();
    }
}