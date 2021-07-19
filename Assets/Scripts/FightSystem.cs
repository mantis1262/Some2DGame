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

    int ValueAll1 = 0;
    int ValueAll2 = 0;

    PlayerMovment char1;
    PlayerMovment char2;
    Mobs mob;



    public void SetPlayesFight(PlayerMovment char1, PlayerMovment char2)
    {
        this.char1 = char1;
        this.char2 = char2;

        gameObject.SetActive(true);

        name1Text.text = char1.name;
        name2Text.text = char2.name;

        str1Text.text = STR + char1.strenght.ToString();
        str2Text.text = STR + char2.strenght.ToString();

        int weapon1pow = Random.Range(char1.equipWeapon.MinPower, char1.equipWeapon.MaxPower);
        int weapon2pow = Random.Range(char2.equipWeapon.MinPower, char2.equipWeapon.MaxPower);

        wep1Text.text = WEP + weapon1pow.ToString();
        wep2Text.text = WEP + weapon2pow.ToString();

        int ran = Random.Range(0, 10);
        dice1Text.text = DICE + ran.ToString();

        int ran2 = Random.Range(0, 10);
        dice2Text.text = DICE + ran2.ToString();

        ValueAll1 += char1.strenght + weapon1pow + ran;
        ValueAll2 += char2.strenght + weapon2pow + ran2;

        if(ValueAll1 > ValueAll2)
        {
            char2.stun = true;
        } else if(ValueAll2 > ValueAll1)
        {
            char1.stun = true;

        }

    }

    public void SetMobFight(PlayerMovment char1, Mobs char2)
    {
        this.char1 = char1;
        this.mob = char2;
        gameObject.SetActive(true);

        name1Text.text = char1.name;
        name2Text.text = char2.name;

        str1Text.text = STR + char1.strenght.ToString();
        str2Text.text = STR + char2.STR.ToString();

        int weapon1pow = Random.Range(char1.equipWeapon.MinPower, char1.equipWeapon.MaxPower);
        wep1Text.text = WEP + weapon1pow.ToString();

        int ran = Random.Range(0, 10);
        dice1Text.text = DICE + ran.ToString();

        int ran2 = Random.Range(0, char2.maxDice);
        dice2Text.text = DICE + ran2.ToString();

        ValueAll1 += char1.strenght + ran;
        ValueAll2 += char2.STR + ran2;

        if (ValueAll1 > ValueAll2)
        {
            Destroy(char2.gameObject);
        }
        else if (ValueAll2 > ValueAll1)
        {
            char1.stun = true;
            char1.currentEnergy = 0;

        }
    }


    public void CloseFight()
    {
        this.gameObject.SetActive(false);
        ValueAll1 = 0;
        ValueAll2 = 0;
        char1.fight = false;
        if (char2 != null)
        {
            char2.fight = false;
            char2 = null;
        }
        if (mob != null)
        {
            mob = null;
        }
    }
}
