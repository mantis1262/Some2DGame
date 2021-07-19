using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{

    [SerializeField] private PlayerMovment[] players;
    [SerializeField] private int turnNumber = 0;
    [SerializeField] private Text turnNumberText;

    public int currentPlayer;

    public void EndTurn()
    {
        PlayerMovment player = players[currentPlayer];
        player.hasTurn = false;
        player.camera.gameObject.SetActive(false);
        player.fog.gameObject.SetActive(false);
        player.stun = false;
        if (player.currentQuest != null)
            player.currentQuest.EndTurn();

        currentPlayer++;
        if (currentPlayer >= players.Length)
        {
            currentPlayer = 0;
            turnNumber++;
            turnNumberText.text = "Turn: " + turnNumber;
        }

        player = players[currentPlayer];
        player.hasTurn = true;
        player.camera.gameObject.SetActive(true);
        player.fog.gameObject.SetActive(true);
        player.currentEnergy = players[currentPlayer].maxEnergy;
        if (player.currentQuest != null)
            player.currentQuest.StartTurn();
        if (player.stun == true)
            player.currentEnergy = 0;
        player.energy.text = "Energy: " + player.currentEnergy + "/" + player.maxEnergy;





    }
}
