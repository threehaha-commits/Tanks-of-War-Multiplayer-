using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class RoundEventViewer : MonoBehaviour
{
    private UnityAction RoundStart;
    private UnityAction RoundEnd;
    [SerializeField] private PhotonView ViewFromRoundText;
    
    public void StartGame()
    {
        gameObject.GetPhotonView().RPC("StartRoundForPlayers", RpcTarget.AllViaServer);
        ViewFromRoundText.RPC("RoundHasStarted", RpcTarget.AllViaServer);
    }

    [PunRPC]
    private void StartRoundForPlayers()
    {
        BeginRound();
    }
    
    public void AddListener(UnityAction action, int Group = 0)
    {
        if (Group == 0)
            RoundStart += action;
        else 
            RoundEnd += action;
    }
    
    public void FinishRound()
    {
        RoundEnd?.Invoke();
    }

    public void BeginRound()
    {
        RoundStart?.Invoke();
    }
}