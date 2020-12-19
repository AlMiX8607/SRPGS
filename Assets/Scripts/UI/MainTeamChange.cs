using Fungus;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTeamChange : MonoBehaviour
{
    int target = -1;
    public static int targetChange = -1;
    public Flowchart flow;
    public GameObject prefab;
    public GameObject Parent;
    List<GameObject> images;
    public void ChangeClick()
    {
        if (target != -1)
        {
            images = new List<GameObject>();
            transform.GetChild(8).gameObject.SetActive(true);
            transform.GetChild(9).gameObject.SetActive(true);
            foreach (CharacterInFight ch in StartGame.game.AllCharacters)
            {
                GameObject obj = Instantiate(prefab, Parent.transform);
                obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(ch.sprite);
                images.Add(obj);
            }
        }
    }
    public void Target1() { target = 1; }
    public void Target2() { target = 2; }

    public void Accept()
    {
        if (target == 1)
        {
            if (!StartGame.game.MainTeam[2].Equals(StartGame.game.AllCharacters[targetChange]))
            {
                StartGame.game.MainTeam[target] = StartGame.game.AllCharacters[targetChange];
                foreach (GameObject obj in images)
                {
                    print(obj);
                    Destroy(obj);
                }
                transform.GetChild(8).gameObject.SetActive(false);
                transform.GetChild(9).gameObject.SetActive(false);
            }
            else
            {
             //Lean.
            }
        }
        else
        {
            if (!StartGame.game.MainTeam[1].Equals(StartGame.game.AllCharacters[targetChange]))
            {
                StartGame.game.MainTeam[target] = StartGame.game.AllCharacters[targetChange];
                foreach (GameObject obj in images)
                {
                    print(obj);
                    Destroy(obj);
                }
                transform.GetChild(8).gameObject.SetActive(false);
                transform.GetChild(9).gameObject.SetActive(false);
            }
        }
    }
    public void Back()
    {
        flow.SendFungusMessage("Back Main Team");
    }
    void FixedUpdate()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(StartGame.game.MainTeam[0].sprite);
        transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>(StartGame.game.MainTeam[1].sprite);
        transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>(StartGame.game.MainTeam[2].sprite);
        transform.GetChild(1).GetComponent<Text>().text= StartGame.game.MainTeam[0].Name+"\nУровень: "+ StartGame.game.MainTeam[0].lvl;
        transform.GetChild(3).GetComponent<Text>().text = StartGame.game.MainTeam[1].Name + "\nУровень: " + StartGame.game.MainTeam[1].lvl;
        transform.GetChild(5).GetComponent<Text>().text = StartGame.game.MainTeam[2].Name + "\nУровень: " + StartGame.game.MainTeam[2].lvl;
        if (target != 1) transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        else transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
        if (target != 2) transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
        else transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
    }
    private void Start()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(StartGame.game.MainTeam[0].sprite);
        transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>(StartGame.game.MainTeam[1].sprite);
        transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>(StartGame.game.MainTeam[2].sprite);
        transform.GetChild(1).GetComponent<Text>().text = StartGame.game.MainTeam[0].Name + "\nУровень: " + StartGame.game.MainTeam[0].lvl;
        transform.GetChild(3).GetComponent<Text>().text = StartGame.game.MainTeam[1].Name + "\nУровень: " + StartGame.game.MainTeam[1].lvl;
        transform.GetChild(5).GetComponent<Text>().text = StartGame.game.MainTeam[2].Name + "\nУровень: " + StartGame.game.MainTeam[2].lvl;
    }
}
