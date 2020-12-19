using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Game
{
   public int slot;

    public int coins=0;
    public int karma=0;


    public List<Item> ShopList = new List<Item>();
    public List<Item> ShopRequired = new List<Item>();


    public List<Item> Inventory = new List<Item>();

    public int ChanseGiveWeapon=30;
   
    public CharacterInFight MainHero;
    public CharacterInFight Resort;
    public CharacterInFight Nativus;
    public CharacterInFight Argo;

    //public int FriendshipPointsResort;
    public int FriendshipPointsArgo=0;
    public int FriendshipPointsNativus=0;
    public int FriendshipPointsElfo=0;




    public CharacterInFight[] AllCharacters;

    public CharacterInFight[] MainTeam;
  
    public bool Start;

    public int MaxLvl = 1000;
    public List<CharacterInFight> AllEnemys = new List<CharacterInFight>();
    public List<Questions> ForMainHeroQuestions = new List<Questions>();
    public bool MainHeroMath = false;
    public List<Questions> MathQuestions = new List<Questions>();
    public bool MainHeroRussian = false;
    public List<Questions> RussianQuestions = new List<Questions>();
    public bool MainHeroPhysic = false;
    public List<Questions> PhysicQuestions = new List<Questions>();
    public bool MainHeroEng = false;
    public List<Questions> EngQuestions = new List<Questions>();
    public bool MainHeroInformatic = false;
    public List<Questions> InformaticQuestions = new List<Questions>();
    public bool MainHeroSocial = false;
    public List<Questions> SocialQuestions = new List<Questions>();
    public bool MainHeroChemistry = false;
    public List<Questions> ChemistryQuestions = new List<Questions>();
    public bool MainHeroBiology = false;
    public List<Questions> BiologyQuestions = new List<Questions>();


    public Dictionary<List<Feature>, List<bool>> FeatureTypeMap = new Dictionary<List<Feature>, List<bool>>(); //Словари с ключом -- списком особенностей (например для ботинок), а значением -- списком bool (какие из них открыты)
    public Dictionary<List<Feature>, List<bool>> FeatureElementMap = new Dictionary<List<Feature>, List<bool>>();

    public Game(int slot) //Старт новой игры
    {
        this.slot = slot;
        MainTeam = new CharacterInFight[3];
        MainHero = new CharacterInFight("Пробел", 1, "necro");

        Resort = new CharacterInFight("Ресорт", 1, 1, "resort");
        Nativus = new CharacterInFight("Нативус", 1, 5, "nativus");
        Argo = new CharacterInFight("Арго", 1, 4, "argo");
        Argo.skill1 = new Skill(1, Argo);
        AllCharacters = new CharacterInFight[2];
       // AllCharacters[0] = Resort;
        AllCharacters[0] = Nativus;
        AllCharacters[1] = Argo;

        MainTeam[0] = Resort;
        MainTeam[1] = Nativus;
        MainTeam[2] = Argo;

        coins = 0;
    }
    public Game(Game game, int slot) //Загрузка игры
    {
        this.slot = slot;
        FriendshipPointsArgo = game.FriendshipPointsArgo;
        FriendshipPointsNativus = game.FriendshipPointsNativus;
        FriendshipPointsElfo = game.FriendshipPointsElfo;
        FeatureTypeMap = game.FeatureTypeMap;
        FeatureElementMap = game.FeatureElementMap;
        coins = game.coins;
        karma = game.karma;
        ShopList = game.ShopList;
        ShopRequired = game.ShopRequired;
        ChanseGiveWeapon = game.ChanseGiveWeapon;
        Inventory = game.Inventory;
        Start = game.Start;
        MainHero = game.MainHero;
        Resort = game.Resort;
        Argo = game.Argo;
        Nativus = game.Nativus;
        MainTeam = game.MainTeam;
        MaxLvl = game.MaxLvl;
        AllEnemys = game.AllEnemys;
        ForMainHeroQuestions = game.ForMainHeroQuestions;
        MainHeroMath = game.MainHeroMath;
        MathQuestions = game.MathQuestions;
        MainHeroRussian = game.MainHeroRussian;
        RussianQuestions = game.RussianQuestions;
        MainHeroPhysic = game.MainHeroPhysic;
        PhysicQuestions = game.PhysicQuestions;
        MainHeroEng = game.MainHeroEng;
        EngQuestions = game.EngQuestions;
        MainHeroInformatic = game.MainHeroInformatic;
        InformaticQuestions = game.InformaticQuestions;
        MainHeroSocial = game.MainHeroSocial;
        SocialQuestions = game.SocialQuestions;
        MainHeroChemistry = game.MainHeroChemistry;
        ChemistryQuestions = game.ChemistryQuestions;
        MainHeroBiology = game.MainHeroBiology;
        BiologyQuestions = game.BiologyQuestions;
}
    public Game(int slot, string name)
    {
        this.slot = slot;
        MainHero = new CharacterInFight(name, 10, "necro");    
    }

    public void CheckQuestions()
    {
        StartGame.flow.SetBooleanVariable("OneObject", false);
        ForMainHeroQuestions.Clear();
        if (MainHeroMath)
        {
            StartGame.flow.SetBooleanVariable("OneObject", true);
            foreach (Questions q in MathQuestions)
                ForMainHeroQuestions.Add(q);
        }
        if (MainHeroRussian)
        {
            StartGame.flow.SetBooleanVariable("OneObject", true);
            foreach (Questions q in RussianQuestions)
                ForMainHeroQuestions.Add(q);
        }
        if (MainHeroPhysic)
        {
            StartGame.flow.SetBooleanVariable("OneObject", true);
            foreach (Questions q in PhysicQuestions)
                ForMainHeroQuestions.Add(q);
        }
        if (MainHeroEng)
        {
            StartGame.flow.SetBooleanVariable("OneObject", true);
            foreach (Questions q in EngQuestions)
                ForMainHeroQuestions.Add(q);
        }
        if (MainHeroInformatic)
        {
            StartGame.flow.SetBooleanVariable("OneObject", true);
            foreach (Questions q in InformaticQuestions)
                ForMainHeroQuestions.Add(q);
        }
        if (MainHeroSocial)
        {
            StartGame.flow.SetBooleanVariable("OneObject", true);
            foreach (Questions q in SocialQuestions)
                ForMainHeroQuestions.Add(q);
        }
        if (MainHeroChemistry)
        {
            StartGame.flow.SetBooleanVariable("OneObject", true);
            foreach (Questions q in ChemistryQuestions)
                ForMainHeroQuestions.Add(q);
        }
        if (MainHeroBiology)
        {
            StartGame.flow.SetBooleanVariable("OneObject", true);
            foreach (Questions q in BiologyQuestions)
                ForMainHeroQuestions.Add(q);
        }
    }

    public void GiveForTest()
    {/*
        int[] mas = new int[4];
        mas[0] = 1;
        mas[1] = 2;
        Inventory.Add(new Item(new Weapon("Меч Победоносца",1,3,0, 0, false, null, 10,0,mas, "sword"), 100, 0));
        Inventory.Add(new Item(new Weapon("Меч Цезарь",2,2, 0, 0, false, null, 10, 0, mas, "sword"), 100, 0));
        Inventory.Add(new Item(new Weapon("Дубина",3,5, 1, 0, true, "baton"), 100, 0));
        Inventory.Add(new Item(new Weapon("Инструкция", 2, 0, false, "book"), 100, 0));
        Inventory.Add(new Item(new Weapon("Рыцарский шлем", 3, 0, false, "helmet"), 100, 0));
        Inventory.Add(new Item(new Weapon("Доспех рыцаря", 4, 0, false, "armor"), 100, 0));
        Inventory.Add(new Item(new Weapon("Доспех разбойника", 4, 0, false, "armor2"), 100, 0));
        Inventory.Add(new Item(new Weapon("Штаны доблести", 5, 0, false, "legg"), 100, 0));
        Inventory.Add(new Item(new Weapon("Странные перчатки", 6, 6, false, "Glove"), 100, 0));
        Inventory.Add(new Item(new Weapon("Пояс хладнокровия", 7, 0, false, "belt"), 100, 0));
        Inventory.Add(new Item(new Weapon("Ботинки Соника", 8, 0, false, "boots"), 100, 0));
        Inventory.Add(new Item(new Weapon("Морской амулет", 9, 0, false, "amul"), 100, 0));
        Inventory.Add(new Item(new Weapon("Ледяной покров", 9, 2, false, "amul"), 100, 0));
        */
    }
    public void GiveRandomItem()
    {
        Inventory.Add(new Item(Weapon.RandomGenerate(1,1,true), 100, 0));
    }
}
