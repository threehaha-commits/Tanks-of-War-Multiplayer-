using System.Collections;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Serialization;

public class ItemSpawner : MonoBehaviour
{
    private GameObject[] Items = new GameObject[3];
    [SerializeField] private RoundEventViewer roundManager;
    private float SpawnTime = 10f;
    private bool TurnCoroutine;
    private IEnumerator Spawnumerator;
    private ItemFactory Factory;
    
    private void Awake()
    {
        Factory = new ItemFactory(Items);
        Spawnumerator = Spawn(TurnCoroutine);
        if(gameObject.GetPhotonView().IsMine == false)
            Destroy(gameObject);
        roundManager.AddListener(StartSpawnBulletItems, 0);
        roundManager.AddListener(EndSpawnBulletItems, 1);
    }

    private void StartSpawnBulletItems()
    {
        TurnCoroutine = true;
        StartCoroutine(Spawnumerator);
    }

    private void EndSpawnBulletItems() 
    {
        TurnCoroutine = false;
        StopCoroutine(Spawnumerator);
    }
    
    private IEnumerator Spawn(bool inWork)
    {
        while(inWork)
        {
            Factory.Create();
            yield return new WaitForSeconds(SpawnTime);
        }
    }
}