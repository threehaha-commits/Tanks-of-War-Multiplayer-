using Photon.Pun;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    private Health Health;
    private Death Death;
    private PhotonView View;
    private int Group => _playerGroup.Group;
    private PlayerGroup _playerGroup { get; set; }
    
    private void Start()
    {
        View = GetComponent<PhotonView>();
        Death = GetComponent<Death>();
        Health = GetComponent<Health>();
        _playerGroup = GetComponent<PlayerGroup>();
    }
    
    public void ApplyDamage(int damage)
    {
        Health.Hp -= damage;
        if (Death.IsDeath)
        {
            View?.RPC("DeathCharapter", RpcTarget.AllViaServer, Group);
        }
    }
}