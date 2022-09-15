using Photon.Pun;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    private int ScoreLeft;
    private int ScoreRight;
    [SerializeField] private PhotonView ViewFromRoundText;
    [SerializeField] private RoundEventViewer _roundEventViewer;

    private void Start()
    {
        _roundEventViewer.AddListener(ChangeTextToScreen, 0);
    }

    public void ChangeLeftScore()
    {
        ScoreLeft++;
    }

    public void ChangeRightScore()
    {
        ScoreRight++;
    }

    private void ChangeTextToScreen()
    {
        ViewFromRoundText.RPC("TextToScreen", RpcTarget.AllViaServer, ScoreLeft, ScoreRight);
    }
}