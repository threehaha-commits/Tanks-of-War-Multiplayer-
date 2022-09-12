using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Button[] Buttons;
    [SerializeField] private RoundEventViewer _roundManager;
    [SerializeField] private Image BulletImage;
    [SerializeField] private BulletItem StartBulletItem;
    [SerializeField] private ItemSpawnController _itemSpawnController;
    private IBulletIdentify BulletIdentify => StartBulletItem.GetComponent<IBulletIdentify>();
    private PlayerFabric _PlayerFabric;
    
    private void Start()
    {
        _PlayerFabric = new PlayerFabric(Player);
    }

    public void SpawnPlayer()
    {
        Buttons[0].gameObject.SetActive(false);
        PhotonView playerPView = _PlayerFabric.Create();
        
        SetPlayerProperty(playerPView);

        Destroy(gameObject);
    }

    private void SetPlayerProperty(PhotonView playerPView)
    {
        playerPView.GetComponent<EnterTriggerItem>().Image = new BulletVisual(BulletImage);
        playerPView.GetComponent<PlayerPosition>()._roundManager = _roundManager;
        playerPView.GetComponent<Fire>().BulletIdentify = BulletIdentify;
        _itemSpawnController.GameStart();
    }
}