using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    List<Iteam> iteams;
   public void OpenInventory()
    {
        this.gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
       this.gameObject.SetActive(false);
    }

}
