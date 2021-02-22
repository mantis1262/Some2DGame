using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{

    [SerializeField] private PlayerMovment[] players;
    public int currentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndTurn()
    {
        players[currentPlayer].hasTurn = false;
        players[currentPlayer].camera.gameObject.SetActive(false);
        players[currentPlayer].fog.gameObject.SetActive(false);

        currentPlayer++;
        if (currentPlayer >= players.Length)
            currentPlayer = 0;
        players[currentPlayer].hasTurn = true;
        players[currentPlayer].camera.gameObject.SetActive(true);
        players[currentPlayer].fog.gameObject.SetActive(true);
        players[currentPlayer].currentEnergy = players[currentPlayer].maxEnergy;
        players[currentPlayer].energy.text = "Energy: " + players[currentPlayer].currentEnergy + "/" + players[currentPlayer].maxEnergy;





    }
}
