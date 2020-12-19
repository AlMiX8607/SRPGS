using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour //Заполняет все существующие вопросы в листы
{
    public static Game game;
    public static Flowchart flow;
    public GameObject CommandBtn;
    void Start()
    {
        flow = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        SaveLoad.savedGames.Add(new Game(0, "Нет данных"));
        SaveLoad.savedGames.Add(new Game(1, "Нет данных"));
        SaveLoad.savedGames.Add(new Game(2, "Нет данных"));
        SaveLoad.Load(); 
    }
    public void SetGGName() //Установка имени из переменной Фунгуса
    {
        game.MainHero.Name = flow.GetStringVariable("MainHeroName");
    }
    bool stopComand = false;
    private void Update()
    {
        if (flow.GetBooleanVariable("Save"))
        {
            SaveLoad.Save();
            flow.SetBooleanVariable("Save", false);
        }


        if (Input.GetKey(KeyCode.R) && !stopComand)
        {
            game.GiveRandomItem();
            stopComand = true;
            StartCoroutine(AgainComand());
        }
        if (Input.GetKey(KeyCode.T) && !stopComand)
        {
            game.GiveForTest();
            stopComand = true;
            StartCoroutine(AgainComand());
        }
    }
    public void RandomItem()
    {
        game.GiveRandomItem();
    }
    IEnumerator AgainComand()
    {
        yield return new WaitForSeconds(0.1f);
        stopComand = false;
    }

}
