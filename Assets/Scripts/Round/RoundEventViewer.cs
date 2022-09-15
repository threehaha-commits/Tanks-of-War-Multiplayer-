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
    
    /// <summary>
    /// Add your action to round action manager
    /// </summary>
    /// <param name="Group">0 - RoundStart, 1 - RoundEnd</param>
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