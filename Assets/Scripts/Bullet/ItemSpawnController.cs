using System.Collections;
using UnityEngine;
using Photon.Pun;

public class ItemSpawnController : MonoBehaviour
{
    [SerializeField] private GameObject[] Items = new GameObject[3];
    [SerializeField] private RoundEventViewer roundManager;
    private const float SpawnTime = 10f;
    private IEnumerator Spawnumerator;
    
    public void GameStart()
    {
        if (PhotonNetwork.IsMasterClient == false)
            return;
        Spawnumerator = Spawn();
        roundManager.AddListener(StartSpawnBulletItems, 0);
        roundManager.AddListener(EndSpawnBulletItems, 1);
    }

    private void StartSpawnBulletItems()
    {
        StartCoroutine(Spawnumerator);
    }
    
    private void EndSpawnBulletItems() 
    {
        StopCoroutine(Spawnumerator);
    }
    
    private IEnumerator Spawn()
    {
        int random = 0;
        while (true)
        { 
            random = random.Random(Items.Length);
            PhotonNetwork.Instantiate(Items[random].name, new Vector3().RandomScreenPosition(), Quaternion.identity);
            yield return new WaitForSeconds(SpawnTime);
        }
    }
}