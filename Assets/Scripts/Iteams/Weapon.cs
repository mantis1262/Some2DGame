using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : Iteam
{
    public int MinPower;   
    public int MaxPower;
    public Text nameText;
    public Text powerText;

    public void Start()
    {
        nameText.text = name;
        powerText.text = MinPower + " - " + MaxPower;
    }

}
