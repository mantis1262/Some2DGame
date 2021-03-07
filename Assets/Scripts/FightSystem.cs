using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightSystem : MonoBehaviour
{

    public Text name1Text;
    public Text str1Text;
    public Text wep1Text;
    public Text dice1Text;


    public Text name2Text;
    public Text str2Text;
    public Text wep2Text;
    public Text dice2Text;

    const string STR =  "STR: ";
    const string WEP =  "Weapon: ";
    const string DICE = "Dice: ";



    public void SetPlayesFight(PlayerMovment char1, PlayerMovment char2)
    {
        gameObject.SetActive(true);

        name1Text.text = char1.name;
        name2Text.text = char2.name;

        str1Text.text = STR + char1.strenght.ToString();
        str2Text.text = STR + char2.strenght.ToString();

        int ran = Random.Range(0, 10);
        dice1Text.text = DICE + ran.ToString();

        int ran2 = Random.Range(0, 10);
        dice2Text.text = DICE + ran2.ToString();
    }

    public void SetMobFight(PlayerMovment char1, PlayerMovment char2)
    {
        gameObject.SetActive(true);

        name1Text.text = char1.name;
        name2Text.text = char2.name;

       // str1Text.text = STR + char1.strenght.ToString();
        //str2Text.text = STR + char2.strenght.ToString();

        int ran = Random.Range(0, 10);
        dice1Text.text = DICE + ran.ToString();

        int ran2 = Random.Range(0, 10);
        dice2Text.text = DICE + ran2.ToString();
    }

}
