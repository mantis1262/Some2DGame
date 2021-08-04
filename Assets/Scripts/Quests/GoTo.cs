using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTo : Quest
{

    public GameObject Aim;

    public override bool CheckQuest(PlayerMovment player)
    {
        if (player.transform.position == Aim.transform.position)
            return true;
        return false;
    }

    public override void CompletedQuest(PlayerMovment player)
    {
        player.inventory.Add(reward);
    }

    public override void EndTurn()
    {
        Aim.SetActive(false);
    }

    public override void StartTurn()
    {
        Aim.SetActive(true);
    }
}
