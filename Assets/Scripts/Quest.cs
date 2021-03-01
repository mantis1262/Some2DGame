using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Quest : MonoBehaviour
{

    public string title;
   [TextArea] public string text;
    public GameObject reward;
    public bool active = false;

    public abstract bool CheckQuest(PlayerMovment player);
    public abstract void CompletedQuest(PlayerMovment player);
}
