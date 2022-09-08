using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private RoundEventViewer _roundEventViewer;
    [SerializeField] private RoundText _roundText;
    [SerializeField] private ScoreViewer _scoreViewer;
    
    public override void InstallBindings()
    {
        //Container.Bind<RoundEventViewer>().FromInstance(_roundEventViewer).AsSingle();
        //Container.Bind<RoundText>().FromInstance(_roundText).AsSingle();
        //Container.Bind<ScoreViewer>().FromInstance(_scoreViewer).AsSingle();
    }
}