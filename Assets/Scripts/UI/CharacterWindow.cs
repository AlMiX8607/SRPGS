using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterWindow : MonoBehaviour
{
    public GameObject Equipment;
    public GameObject CharacterInfo;
    public GameObject prefabInv;
    public static CharacterInFight ch;
    public GameObject Close;
    public GameObject EquipPanel;
    public static bool isEquipment=false;
    void Start()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(StartGame.game.MainTeam[0].sprite);
        transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>(StartGame.game.MainTeam[1].sprite);
        transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>(StartGame.game.MainTeam[2].sprite);
        transform.GetChild(1).GetComponent<Text>().text = StartGame.game.MainTeam[0].Name + "\nУровень: " + StartGame.game.MainTeam[0].lvl;
        transform.GetChild(3).GetComponent<Text>().text = StartGame.game.MainTeam[1].Name + "\nУровень: " + StartGame.game.MainTeam[1].lvl;
        transform.GetChild(5).GetComponent<Text>().text = StartGame.game.MainTeam[2].Name + "\nУровень: " + StartGame.game.MainTeam[2].lvl;
    }

    void FixedUpdate()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(StartGame.game.MainTeam[0].sprite);
        transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>(StartGame.game.MainTeam[1].sprite);
        transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>(StartGame.game.MainTeam[2].sprite);
        transform.GetChild(1).GetComponent<Text>().text = StartGame.game.MainTeam[0].Name + "\nУровень: " + StartGame.game.MainTeam[0].lvl;
        transform.GetChild(3).GetComponent<Text>().text = StartGame.game.MainTeam[1].Name + "\nУровень: " + StartGame.game.MainTeam[1].lvl;
        transform.GetChild(5).GetComponent<Text>().text = StartGame.game.MainTeam[2].Name + "\nУровень: " + StartGame.game.MainTeam[2].lvl;
    }

    public void OnCharacterClick(int id)
    {
        CharacterInfo.SetActive(true);
        ch = StartGame.game.MainTeam[id];
        CharacterInfo.transform.GetChild(0).GetComponent<Text>().text = ch.Name;
        CharacterInfo.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(ch.sprite);

        //Skills
        if (ch.skill1 != null)
        {
            CharacterInfo.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ch.skill1.sprite);
            CharacterInfo.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<Text>().text = ch.skill1.Name;
            CharacterInfo.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Text>().text = ch.skill1.Description;
        }
        else
        {
           CharacterInfo.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("lock");
           CharacterInfo.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<Text>().text = "Недоступно";
           CharacterInfo.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Text>().text = "Скилл не открыт";
        }
        if (ch.skill2 != null)
        {
            CharacterInfo.transform.GetChild(3).GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>(ch.skill2.sprite);
            CharacterInfo.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<Text>().text = ch.skill2.Name;
            CharacterInfo.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<Text>().text = ch.skill2.Description;
        }
        else
        {
            CharacterInfo.transform.GetChild(3).GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("lock");
            CharacterInfo.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<Text>().text = "Недоступно";
            CharacterInfo.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<Text>().text = "Скилл не открыт";
        }
        if (ch.skill3 != null)
        {
            CharacterInfo.transform.GetChild(3).GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>(ch.skill3.sprite);
            CharacterInfo.transform.GetChild(3).GetChild(5).GetChild(0).GetComponent<Text>().text = ch.skill3.Name;
            CharacterInfo.transform.GetChild(3).GetChild(5).GetChild(1).GetComponent<Text>().text = ch.skill3.Description;
        }
        else
        {
            CharacterInfo.transform.GetChild(3).GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>("lock");
            CharacterInfo.transform.GetChild(3).GetChild(5).GetChild(0).GetComponent<Text>().text = "Недоступно";
            CharacterInfo.transform.GetChild(3).GetChild(5).GetChild(1).GetComponent<Text>().text = "Скилл не открыт";
        }
        if (ch.skill4 != null)
        {
            CharacterInfo.transform.GetChild(3).GetChild(6).GetComponent<Image>().sprite = Resources.Load<Sprite>(ch.skill4.sprite);
            CharacterInfo.transform.GetChild(3).GetChild(7).GetChild(0).GetComponent<Text>().text = ch.skill4.Name;
            CharacterInfo.transform.GetChild(3).GetChild(7).GetChild(1).GetComponent<Text>().text = ch.skill4.Description;
        }
        else
        {
            CharacterInfo.transform.GetChild(3).GetChild(6).GetComponent<Image>().sprite = Resources.Load<Sprite>("lock");
            CharacterInfo.transform.GetChild(3).GetChild(7).GetChild(0).GetComponent<Text>().text = "Недоступно";
            CharacterInfo.transform.GetChild(3).GetChild(7).GetChild(1).GetComponent<Text>().text = "Скилл не открыт";
        }
    }


    public void Back()
    {
        StartGame.flow.SendFungusMessage("Back CharacterInfo");
    }
    public void CloseInfo()
    {
        CharacterInfo.SetActive(false);
        CharacteristicsInfo.page = 1;
    }
    public static GameObject OpenInv;
    public void CloseEquipment()
    {
        isEquipment = false;
        for (int i=0; i<=10; i++)
        {
            EquipPanel.transform.GetChild(i).GetComponent<Image>().color = new Color(1f, 1f, 1f);
        }
        Close.SetActive(false);
        Equipment.SetActive(false);
        Destroy(OpenInv);
    }
    public void OpenEquipment()
    {
        isEquipment = true;
        Close.SetActive(true);
        Equipment.SetActive(true);
        OpenInv = Instantiate(prefabInv, Equipment.transform);
    }
}
