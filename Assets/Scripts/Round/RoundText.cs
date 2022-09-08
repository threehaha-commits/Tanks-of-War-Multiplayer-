using System;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class RoundText : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    
    [PunRPC]
    private void ChangeTimeLeft(int timeLeft)
    {
        Text.text = $"Start in: {timeLeft}";
    }

    [PunRPC]
    private void TextToScreen(int scoreLeft, int scoreRight) 
    {
        Text.text = $"Round score: {scoreLeft} / {scoreRight}";
    }

    [PunRPC]
    private void RoundHasStarted()
    {
        Text.text = "Fight!";
    }
}