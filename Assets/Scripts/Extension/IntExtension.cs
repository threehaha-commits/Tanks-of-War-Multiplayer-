using Photon.Pun;

public static class IntExtension
{
    public static int PlayerIndex(this int index)
    {
        return PhotonNetwork.CountOfPlayersInRooms % 2;
    }
}