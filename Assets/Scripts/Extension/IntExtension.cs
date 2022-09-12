using Photon.Pun;

public static class IntExtension
{
    public static int PlayerIndex(this int index)
    {
        return PhotonNetwork.CountOfPlayersInRooms % 2;
    }

    public static int Random(this int random, int minValue, int maxValue)
    {
        return UnityEngine.Random.Range(minValue, maxValue);
    }
    
    /// <summary>
    /// Int random function(value)
    /// </summary>
    /// <param name="Enter the maximum value to which you want to get random"></param>
    /// <returns>Return value from 0 to maxValue</returns>
    public static int Random(this int random, int maxValue)
    {
        return UnityEngine.Random.Range(0, maxValue);
    }
}