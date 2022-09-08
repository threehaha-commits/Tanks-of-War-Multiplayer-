using UnityEngine;
using Photon.Pun;

public class Health : MonoBehaviour
{
    private int Group => _playerGroup.Group;

    [SerializeField] private int Hp = 100;
    private PhotonView photonView;
    private RoundEventViewer _roundManager;
    private ScoreViewer _scoreViewer;
    private PlayerGroup _playerGroup { get; set; }
    
    private void Start()
    {
        _scoreViewer = FindObjectOfType<ScoreViewer>();
        _roundManager = FindObjectOfType<RoundEventViewer>();
        photonView = gameObject.GetPhotonView();
        _playerGroup = GetComponent<PlayerGroup>();
    }
    
    public void ApplyDamage(int Damage)
    {
        Hp -= Damage;
        if (Hp <= 0)
        {
            photonView?.RPC("Death", RpcTarget.AllViaServer, Group);
        }
    }

    [PunRPC]
    private void Death(int Group)
    {
        gameObject.SetActive(false);
        if (Group == 1)
            _scoreViewer.ChangeLeftScore();
        else
            _scoreViewer.ChangeRightScore();
        Hp = 100;
        _roundManager.FinishRound();
    }
}