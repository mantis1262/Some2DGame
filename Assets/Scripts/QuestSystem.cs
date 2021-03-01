using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour
{

    [SerializeField] GameObject questWindow;
    [SerializeField] Text questWindowTitle; 
    [SerializeField] Text questWindowNote; 
    public Quest questToView;
    public List<Quest> quests;
    public List<Quest> completedQuest;
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
        if (quests.Count == 0)
        {
            quests.AddRange(completedQuest);
            completedQuest.Clear();
        }

        this.player = player;
        int r = Random.Range(0, quests.Count);
        questToView = quests[r];
        questWindowTitle.text = questToView.title;
        questWindowNote.text = questToView.text;
        questWindow.SetActive(true);
    }

    public void AceptQuest()
    {
        player.currentQuest = questToView;
        questToView.active = true;
        quests.Remove(questToView);
        completedQuest.Add(questToView);
        questWindow.SetActive(false);
    }

}
