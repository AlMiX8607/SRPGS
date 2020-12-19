using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    public GameObject PrefabSlot;
    public GameObject Items;
    public GameObject InventoryW;
    public static GameObject Info;
    public int ChildNum;

    public void Start()
    {
        Info = transform.GetChild(ChildNum).gameObject;
        foreach(Item item in StartGame.game.Inventory)
        {
           GameObject slot = Instantiate(PrefabSlot,Items.transform);
           slot.GetComponent<InventorySlot>().item = item;
        }
    }
    public void Close()
    {
        StartGame.flow.SendFungusMessage("Close Inventory");
        Destroy(InventoryW);
    }
}
