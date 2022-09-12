using Photon.Pun;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Health Health;
    private RoundEventViewer _roundManager;
    private ScoreViewer _scoreViewer;
    
    public bool IsDeath
    {
        get
        {
            if (Health.Hp <= 0)
                return true;
            return false;
        }
    }

    private void Start()
    {
        _scoreViewer = FindObjectOfType<ScoreViewer>();
        _roundManager = FindObjectOfType<RoundEventViewer>();
        Health = GetComponent<Health>();
    }
    
    [PunRPC]
    private void DeathCharapter(int Group)
    {
        gameObject.SetActive(false);
        if (Group == 1)
            _scoreViewer.ChangeLeftScore();
        else
            _scoreViewer.ChangeRightScore();
        Health.Hp = 100;
        _roundManager.FinishRound();
    }
}