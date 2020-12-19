using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Commands : MonoBehaviour
{
    public GameObject AllBackG;
    public GameObject AddFP_Panel;

    public List<string> FP_Phrases = new List<string>();
    public void CloseAllBackgrounds()
    {
        for (int i=0;i< AllBackG.transform.childCount; i++)
        {
            AllBackG.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (StartGame.flow.GetIntegerVariable("FPCharacter") != 0)
        {
            int i = StartGame.flow.GetIntegerVariable("FPCharacter");
            StartGame.flow.SetIntegerVariable("FPCharacter", 0);
            string name="";
            switch (i)
            {
                case 1:
                    StartGame.game.FriendshipPointsElfo++;
                    name = "Элфо";
                    break;
                case 2:
                    StartGame.game.FriendshipPointsArgo++;
                    name = "Арго";
                    break;
                case 3:
                    StartGame.game.FriendshipPointsNativus++;
                    name = "Нативус";
                    break;
            }
            AddFP_Panel.SetActive(true);
            string phrase = FP_Phrases[Random.Range(0, FP_Phrases.Count)];
            phrase = phrase.Replace("герой", name);
            AddFP_Panel.transform.GetChild(0).GetComponent<Text>().text = phrase;
            StartCoroutine(CloseFP_Panel());
        }
    }
    public void AddFP_Elfo()
    {
        StartGame.game.FriendshipPointsElfo++;
        AddFP_Panel.SetActive(true);
        string name = "Элфо";
        string phrase = FP_Phrases[Random.Range(0, FP_Phrases.Count)];
        phrase = phrase.Replace("герой", name);
        AddFP_Panel.transform.GetChild(0).GetComponent<Text>().text = phrase;
        StartCoroutine(CloseFP_Panel());
    }
    public void AddFP_Argo()
    {
        StartGame.game.FriendshipPointsArgo++;
        AddFP_Panel.SetActive(true);
        string name = "Арго";
        string phrase = FP_Phrases[Random.Range(0, FP_Phrases.Count)];
        phrase = phrase.Replace("герой",name);
        AddFP_Panel.transform.GetChild(0).GetComponent<Text>().text = phrase;
        StartCoroutine(CloseFP_Panel());
    }
    public void AddFP_Nativus()
    {
        StartGame.game.FriendshipPointsNativus++;
        AddFP_Panel.SetActive(true);
        string name = "Нативус";
        string phrase = FP_Phrases[Random.Range(0, FP_Phrases.Count)];
        phrase = phrase.Replace("герой", name);
        AddFP_Panel.transform.GetChild(0).GetComponent<Text>().text = phrase;
        StartCoroutine(CloseFP_Panel());
    }

    public void ShowQuest()
    {
        AddFP_Panel.SetActive(true);
        AddFP_Panel.transform.GetChild(0).GetComponent<Text>().text = StartGame.flow.GetStringVariable("QuestLog");
        StartCoroutine(CloseFP_Panel());
    }

    IEnumerator CloseFP_Panel()
    {
        yield return new WaitForSeconds(3f);
        AddFP_Panel.SetActive(false);
    }
    void Start()
    {
        CloseAllBackgrounds();
        FP_Phrases.Add("Ваша дружба с герой крепнет");
        FP_Phrases.Add("герой это запомнит");
        FP_Phrases.Add("герой это понравилось");
    }
}
