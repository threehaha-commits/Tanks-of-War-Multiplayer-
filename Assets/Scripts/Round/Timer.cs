using System.Collections;
using Photon.Pun;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private RoundEventViewer Viewer;
    [SerializeField] private int TimeForStartRound = 5;
    private PhotonView View;
    [SerializeField] private PhotonView ViewFromRoundText;
    
    private void Start()
    {
        View = gameObject.GetPhotonView();
        Viewer.AddListener(EndRound, 1);
    }

    private void EndRound()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        int timeForStart = TimeForStartRound;
        while (timeForStart > 0)
        {
            yield return new WaitForSeconds(1f);
            timeForStart--;
            ViewFromRoundText.RPC("ChangeTimeLeft", RpcTarget.AllViaServer, timeForStart);
        }
        Viewer.BeginRound();
    }
}