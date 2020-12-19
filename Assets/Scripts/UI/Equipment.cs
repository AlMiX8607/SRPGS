using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public GameObject EquipPanel;
    public GameObject PrefabSlot;


    private void Start()
    {
        ItemFill();
    }
    private void FixedUpdate()
    {
        ItemFill();
    }

    void ItemFill()
    {
        for (int i = 0; i <= 10; i++)
        {
            if (CharacterWindow.ch.Equipment[i] != null) 
        {
                if (CharacterWindow.ch.Equipment[i].DoubleWeapon && i == 0)
                {
                    EquipPanel.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(CharacterWindow.ch.Equipment[0].sprite);
                    EquipPanel.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(CharacterWindow.ch.Equipment[0].sprite);
                    switch (CharacterWindow.ch.Equipment[0].Element)
                    {
                        case 0:
                            EquipPanel.transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f);
                            EquipPanel.transform.GetChild(1).GetComponent<Image>().color = new Color(1f, 1f, 1f);
                            break;
                        case 1:
                            EquipPanel.transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 0.282353f, 0.1921569f);
                            EquipPanel.transform.GetChild(1).GetComponent<Image>().color = new Color(1f, 0.282353f, 0.1921569f);
                            break;
                        case 2:
                            EquipPanel.transform.GetChild(0).GetComponent<Image>().color = new Color(0.3176471f, 0.9607843f, 0.9607843f);
                            EquipPanel.transform.GetChild(1).GetComponent<Image>().color = new Color(0.3176471f, 0.9607843f, 0.9607843f);
                            break;
                        case 3:
                            EquipPanel.transform.GetChild(0).GetComponent<Image>().color = new Color(0.145098f, 0.7843137f, 0.1137255f);
                            EquipPanel.transform.GetChild(1).GetComponent<Image>().color = new Color(0.145098f, 0.7843137f, 0.1137255f);
                            break;
                        case 4:
                            EquipPanel.transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 0);
                            EquipPanel.transform.GetChild(1).GetComponent<Image>().color = new Color(1f, 1f, 0);
                            break;
                        case 5:
                            EquipPanel.transform.GetChild(0).GetComponent<Image>().color = new Color(0.9215686f, 1f, 0.4941176f);
                            EquipPanel.transform.GetChild(1).GetComponent<Image>().color = new Color(0.9215686f, 1f, 0.4941176f);
                            break;
                        case 6:
                            EquipPanel.transform.GetChild(0).GetComponent<Image>().color = new Color(0.7294118f, 0.05882353f, 0.4862745f);
                            EquipPanel.transform.GetChild(1).GetComponent<Image>().color = new Color(0.7294118f, 0.05882353f, 0.4862745f);
                            break;
                    }
                    i++;
                }
                else
                {
                    EquipPanel.transform.GetChild(i).GetComponent<Image>().sprite = Resources.Load<Sprite>(CharacterWindow.ch.Equipment[i].sprite);
                    switch (CharacterWindow.ch.Equipment[i].Element)
                    {
                        case 0:
                            EquipPanel.transform.GetChild(i).GetComponent<Image>().color = new Color(1f, 1f, 1f);
                            break;
                        case 1:
                            EquipPanel.transform.GetChild(i).GetComponent<Image>().color = new Color(1f, 0.282353f, 0.1921569f);
                            break;
                        case 2:
                            EquipPanel.transform.GetChild(i).GetComponent<Image>().color = new Color(0.3176471f, 0.9607843f, 0.9607843f);
                            break;
                        case 3:
                            EquipPanel.transform.GetChild(i).GetComponent<Image>().color = new Color(0.145098f, 0.7843137f, 0.1137255f);
                            break;
                        case 4:
                            EquipPanel.transform.GetChild(i).GetComponent<Image>().color = new Color(1f, 1f, 0);
                            break;
                        case 5:
                            EquipPanel.transform.GetChild(i).GetComponent<Image>().color = new Color(0.9215686f, 1f, 0.4941176f);
                            break;
                        case 6:
                            EquipPanel.transform.GetChild(i).GetComponent<Image>().color = new Color(0.7294118f, 0.05882353f, 0.4862745f);
                            break;
                    }
                }


        }
          else { EquipPanel.transform.GetChild(i).GetComponent<Image>().sprite = null; }
        }
    }

    public void ClickItem(int i)
    {
        if (i==1 && CharacterWindow.ch.Equipment[0].DoubleWeapon) i = 0;

        if (CharacterWindow.ch.Equipment[i]!=null)
        {
            if (CharacterWindow.ch.Equipment[i].DoubleWeapon)
            {
                EquipPanel.transform.GetChild(1).GetComponent<Image>().color = new Color(1f, 1f, 1f);
                i = 0;
            }
            GameObject slot = Instantiate(PrefabSlot, CharacterWindow.OpenInv.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0));
            Item item = new Item(CharacterWindow.ch.Equipment[i]);
            slot.GetComponent<InventorySlot>().item = item;
            StartGame.game.Inventory.Add(item);
            slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(CharacterWindow.ch.Equipment[i].sprite);
            CharacterWindow.ch.Equipment[i] = null;
            if(i==0 && CharacterWindow.ch.Equipment[1] != null)
            {
                CharacterWindow.ch.Equipment[0] = CharacterWindow.ch.Equipment[1];
                EquipPanel.transform.GetChild(1).GetComponent<Image>().color = new Color(1f, 1f, 1f);
                CharacterWindow.ch.Equipment[1] = null;
            }
            CharacterWindow.ch.UpdateCharacteristic();
            EquipPanel.transform.GetChild(i).GetComponent<Image>().color = new Color(1f, 1f, 1f);
        }
    }
}
