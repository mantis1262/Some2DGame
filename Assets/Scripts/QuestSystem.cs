using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{

    [SerializeField] GameObject questWindow;
    public Quest questToView;
    public PlayerMovment player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CloseQuestWinow()
    {
        questWindow.SetActive(false);
    }

    public void SetQuestWinow(PlayerMovment player)
    {
        this.player = player;
        questWindow.SetActive(true);
    }

    public void AceptQuest()
    {
        player.currentQuest = questToView;
        questWindow.SetActive(false);
    }

}
