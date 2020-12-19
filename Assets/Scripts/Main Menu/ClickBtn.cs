using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBtn : MonoBehaviour
{
    public GameObject OptionWindow;
    public GameObject SlotWindow;
    public GameObject StartGames;
    public Flowchart flow;
    public int slot;
    public Text name1, name2, name3;
    bool NewGame=false;
    public void ClickPlay()
    {
        NewGame = false;
        SaveLoad.Load();
        SlotWindow.SetActive(true);
        name1.text = SaveLoad.savedGames[0].MainHero.Name;
        name2.text = SaveLoad.savedGames[1].MainHero.Name;
        name3.text = SaveLoad.savedGames[2].MainHero.Name;
    }
    public void ClickSlot()
    {
        if (StartGames.GetComponent<ClickBtn>().NewGame) {
                StartGame.game = new Game(slot);
                StartGame.game.Start = true;
                //Questions
                for (int i = 1; i < 81; i++)
                {
                    Questions q = new Questions(i);
                    if (q.Object == 1) StartGame.game.MathQuestions.Add(q);
                    if (q.Object == 2) StartGame.game.RussianQuestions.Add(q);
                    if (q.Object == 3) StartGame.game.PhysicQuestions.Add(q);
                    if (q.Object == 4) StartGame.game.EngQuestions.Add(q);
                    if (q.Object == 5) StartGame.game.InformaticQuestions.Add(q);
                    if (q.Object == 6) StartGame.game.SocialQuestions.Add(q);
                    if (q.Object == 7) StartGame.game.ChemistryQuestions.Add(q);
                    if (q.Object == 8) StartGame.game.BiologyQuestions.Add(q);
                }
                StartGame.game.CheckQuestions();

            //Enemy
            EnemyFill();
                flow.SendFungusMessage("New Game Start");
        }
        else
        {
            if (SaveLoad.savedGames[slot].Start)
            {
                StartGame.game = SaveLoad.savedGames[slot];
                flow.SendFungusMessage("Continue");
                StartGame.game.CheckQuestions();
            }
            else { SlotWindow.SetActive(false); }
        }
    }
    public static void EnemyFill()
    {
        StartGame.game.AllEnemys.Clear();
        Dictionary<Item, float> drop_list = new Dictionary<Item, float>();
        int[] mas = new int[4];
        mas[0] = 1;
        int[] raremas = new int[4];
        raremas[0] = 0;
        drop_list.Add(new Item(new Weapon("Дропнутый меч", 1, 3, 0,0, false, null, 10, 0, mas,raremas,"id_1"), 100, 0), 0.5f); //Дропать лучше ресурсы, не экипировку
        CharacterInFight enemy = new CharacterInFight("Герой-отступник", 1, 2, drop_list, "tankart");
        StartGame.game.AllEnemys.Add(enemy);
        //drop_list = new Dictionary<Item, float>();  mas=new int[4];
        enemy = new CharacterInFight("Вражина недобрая", 1, 1, drop_list, "raycoon");
        enemy.skill1 = new Skill(2, enemy);
        StartGame.game.AllEnemys.Add(enemy);
        enemy = new CharacterInFight("Сбежавший Гарри", 1, 3, drop_list, "mageart");
        enemy.skill1 = new Skill(1, enemy);
        StartGame.game.AllEnemys.Add(enemy);
    }
        public void ClickNewGame()
    {
            SaveLoad.Load();
            SlotWindow.SetActive(true);
            name1.text = SaveLoad.savedGames[0].MainHero.Name;
            name2.text = SaveLoad.savedGames[1].MainHero.Name;
            name3.text = SaveLoad.savedGames[2].MainHero.Name;
            NewGame = true;
    }
    
    public void CloseGameSlot()
    {
        SlotWindow.SetActive(false);
    }
    public void MathChangeValue()
    {
        StartGame.game.MainHeroMath = !StartGame.game.MainHeroMath;
    }
    public void RussionChangeValue()
    {
        StartGame.game.MainHeroRussian = !StartGame.game.MainHeroRussian;
    }
    public void PhysicChangeValue()
    {
        StartGame.game.MainHeroPhysic = !StartGame.game.MainHeroPhysic;
    }
    public void EngChangeValue()
    {
        StartGame.game.MainHeroEng = !StartGame.game.MainHeroEng;
    }
    public void InformaticChangeValue()
    {
        StartGame.game.MainHeroInformatic = !StartGame.game.MainHeroInformatic;
    }
    public void SocialChangeValue()
    {
        StartGame.game.MainHeroSocial = !StartGame.game.MainHeroSocial;
    }
    public void ChemistryChangeValue()
    {
        StartGame.game.MainHeroChemistry = !StartGame.game.MainHeroChemistry;
    }
    public void BiologyChangeValue()
    {
        StartGame.game.MainHeroBiology = !StartGame.game.MainHeroBiology;
    }
    public void ClickOptions()
    {
      StartGame.game.CheckQuestions();
      flow.SendFungusMessage("Back Education");
    }
}
