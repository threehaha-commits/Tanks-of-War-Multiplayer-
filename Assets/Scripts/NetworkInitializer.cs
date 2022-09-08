using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkInitializer : MonoBehaviourPunCallbacks
{
    private const byte MaxPlayerRoom = 2;
    private const string gameVersion = "1";
    private GameInitializer Initializer;
    [SerializeField] private RoundEventViewer _roundEventViewer;
    
    private void Awake()
    {
        Initializer = GetComponent<GameInitializer>();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = gameVersion;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayerRoom });
    }

    public override void OnJoinedRoom()
    {
        Initializer.SpawnPlayer();
        if(PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            _roundEventViewer.StartGame();
        Destroy(this);
    }
}