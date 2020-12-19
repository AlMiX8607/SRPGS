using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    FightChar[] HeroTeam = new FightChar[3], EnemyTeam = new FightChar[3];
    public Text NextTurn;
    public Image MainHeroImage, SecondHero1, SecondHero2;
    public Text MainHeroName, MainHeroHP, MainHeroMana, MainHeroLvl, MainHeroEXP, MainHeroEffect;
    public Text SecondHero1Name, SecondHero1HP, SecondHero1Mana, SecondHero1Lvl, SecondHero1Class, SecondHero1Effect;
    public Text SecondHero2Name, SecondHero2HP, SecondHero2Mana, SecondHero2Lvl, SecondHero2Class, SecondHero2Effect;

    public Image Enemy1Image, Enemy2Image, Enemy3Image;
    public Text Enemy1Name, Enemy1HP, Enemy1Mana, Enemy1Lvl, Enemy1Class, Enemy1Effect;
    public Text Enemy2Name, Enemy2HP, Enemy2Mana, Enemy2Lvl, Enemy2Class, Enemy2Effect;
    public Text Enemy3Name, Enemy3HP, Enemy3Mana, Enemy3Lvl, Enemy3Class, Enemy3Effect;

    public static bool isChangeTurn = false;

    public GameObject FightLayout;

    public GameObject EndBattle;

    public GameObject QuestionPanel;

    public Button Skill1Btn, Skill2Btn, Skill3Btn, Skill4Btn;

    public Image[] Rams;

    bool flagWin, flagLose, flagDraw, flagEnd;
    int countEnemys=0;
    float PowerEnemys;
    int lvlEnemyT=0, lvlHeroT=0;
    public static bool isPlayerTurn = false;
    List<FightChar> Turn=new List<FightChar>();
    public Button[] ButtonAttack;

   public static FightChar ActiveCharacter;
    void Start()
    {
        HeroTeam[0] = new FightChar(StartGame.game.MainTeam[0]);
        HeroTeam[1] = new FightChar(StartGame.game.MainTeam[1]);
        HeroTeam[2] = new FightChar(StartGame.game.MainTeam[2]);
        List<FightChar> temp= new List<FightChar>(); //Позже будет выборка по локации.
        foreach (CharacterInFight ch in StartGame.game.AllEnemys)
        {
            temp.Add(new FightChar(ch));
        }
        //Генерация врагов
        if(StartGame.flow.GetIntegerVariable("StoryBattle")!=0)
        {
            switch (StartGame.flow.GetIntegerVariable("StoryBattle"))
            {
                case 1:
                    EnemyTeam[0] = new FightChar(new CharacterInFight("Сектант",1,1,""));//Добавить спрайт
                    EnemyTeam[1] = new FightChar(new CharacterInFight("Сектант", 1, 1, ""));
                    EnemyTeam[2] = new FightChar(new CharacterInFight("Сектант", 1, 1, ""));
                    EnemyTeam[0].ch.health = 3;
                    EnemyTeam[0].ch.ActiveHealth = 3;
                    EnemyTeam[0].ch.mana = 0;
                    EnemyTeam[0].ch.ActiveMana = 0;
                    break;
            }
        }
        else
        for (int i = 0; i < 3; i++)
        {
            EnemyTeam[i] = temp[Random.Range(0, temp.Count)];
            temp.Remove(EnemyTeam[i]);
        }

        //Подсчёт переменных
        foreach (FightChar ch in HeroTeam)
        {
            lvlHeroT += ch.ch.lvl;
            Turn.Add(ch);
        }
        foreach (FightChar ch in EnemyTeam)
        {
            countEnemys++;
            lvlEnemyT += ch.ch.lvl;
            Turn.Add(ch);
        }
        PowerEnemys = lvlEnemyT / (float)lvlHeroT;
        SortList();

        ActiveCharacter = Turn[0];

        foreach (FightChar ch in HeroTeam)
        {
            if (ch==Turn[0])
            {
                isPlayerTurn = true;
            }
        }
        //Определение рамок
        HeroTeam[0].RamForFight = Rams[0];
        HeroTeam[1].RamForFight = Rams[1];
        HeroTeam[2].RamForFight = Rams[2];
        EnemyTeam[0].RamForFight = Rams[3];
        EnemyTeam[1].RamForFight = Rams[4];
        EnemyTeam[2].RamForFight = Rams[5];

        //Skill1Btn.gameObject.transform.GetChild(1).GetComponent<Image>().sprite= HeroTeam[1].skill1.sprite;

        string damag = "Урон", tank = "Щит", healler = "Целитель", flank = "Фланк", uni = "Универсал";
        //Заполнение информации на поле
        MainHeroImage.sprite = Resources.Load<Sprite>(HeroTeam[0].ch.sprite);
        MainHeroName.text = HeroTeam[0].ch.Name;
        MainHeroHP.text ="HP: "+ HeroTeam[0].ch.ActiveHealth.ToString()+"/"+HeroTeam[0].ch.health.ToString();
        MainHeroMana.text = "Mana: " + HeroTeam[0].ch.ActiveMana.ToString() + "/" + HeroTeam[0].ch.mana.ToString();
        MainHeroLvl.text = "LvL: " + HeroTeam[0].ch.lvl.ToString();
        MainHeroEXP.text = "EXP: " + HeroTeam[0].ch.exp.ToString() + "/" + HeroTeam[0].ch.NeedEXP.ToString();



        SecondHero1.sprite = Resources.Load<Sprite>(HeroTeam[1].ch.sprite);
        SecondHero1Name.text = HeroTeam[1].ch.Name;
        SecondHero1HP.text = "HP: " + HeroTeam[1].ch.ActiveHealth.ToString() + "/" + HeroTeam[1].ch.health.ToString();
        SecondHero1Mana.text = "Mana: " + HeroTeam[1].ch.ActiveMana.ToString() + "/" + HeroTeam[1].ch.mana.ToString();
        SecondHero1Lvl.text = "LvL: " + HeroTeam[1].ch.lvl.ToString();
        if (HeroTeam[1].ch.ch_class == 1)  
        {
            SecondHero1Class.text = "Class: "+damag;
        }
        else if (HeroTeam[1].ch.ch_class == 2)
        {
            SecondHero1Class.text = "Class: " + tank;
        }
        else if (HeroTeam[1].ch.ch_class == 3)
        {
            SecondHero1Class.text = "Class: " + healler;
        }
        else if (HeroTeam[1].ch.ch_class == 4)
        {
            SecondHero1Class.text = "Class: " + flank;
        }
        else if (HeroTeam[1].ch.ch_class == 5)
        {
            SecondHero1Class.text = "Class: " + uni;
        }


        SecondHero2.sprite = Resources.Load<Sprite>(HeroTeam[2].ch.sprite);
        SecondHero2Name.text = HeroTeam[2].ch.Name;
        SecondHero2HP.text = "HP: " + HeroTeam[2].ch.ActiveHealth.ToString() + "/" + HeroTeam[2].ch.health.ToString();
        SecondHero2Mana.text = "Mana: " + HeroTeam[2].ch.ActiveMana.ToString() + "/" + HeroTeam[2].ch.mana.ToString();
        SecondHero2Lvl.text = "LvL: " + HeroTeam[2].ch.lvl.ToString();
        if (HeroTeam[2].ch.ch_class == 1)
        {
            SecondHero2Class.text = "Class: " + damag;
        }
        else if (HeroTeam[2].ch.ch_class == 2)
        {
            SecondHero2Class.text = "Class: " + tank;
        }
        else if (HeroTeam[2].ch.ch_class == 3)
        {
            SecondHero2Class.text = "Class: " + healler;
        }
        else if (HeroTeam[2].ch.ch_class == 4)
        {
            SecondHero2Class.text = "Class: " + flank;
        }
        else if (HeroTeam[2].ch.ch_class == 5)
        {
            SecondHero2Class.text = "Class: " + uni;
        }




        Enemy1Image.sprite = Resources.Load<Sprite>(EnemyTeam[0].ch.sprite);
        Enemy1Name.text = EnemyTeam[0].ch.Name;
        Enemy1HP.text = "HP: " + EnemyTeam[0].ch.ActiveHealth.ToString() + "/" + EnemyTeam[0].ch.health.ToString();
        Enemy1Mana.text = "Mana: " + EnemyTeam[0].ch.ActiveMana.ToString() + "/" + EnemyTeam[0].ch.mana.ToString();
        Enemy1Lvl.text = "LvL: " + EnemyTeam[0].ch.lvl.ToString();
        if (EnemyTeam[0].ch.ch_class == 1)
        {
            Enemy1Class.text = "Class: " + damag;
        }
        else if (EnemyTeam[0].ch.ch_class == 2)
        {
            Enemy1Class.text = "Class: " + tank;
        }
        else if (EnemyTeam[0].ch.ch_class == 3)
        {
            Enemy1Class.text = "Class: " + healler;
        }
        else if (EnemyTeam[0].ch.ch_class == 4)
        {
            Enemy1Class.text = "Class: " + flank;
        }
        else if (EnemyTeam[0].ch.ch_class == 5)
        {
            Enemy1Class.text = "Class: " + uni;
        }
        if (countEnemys >= 2)
        {
            Enemy2Image.sprite = Resources.Load<Sprite>(EnemyTeam[1].ch.sprite);
            Enemy2Name.text = EnemyTeam[1].ch.Name;
            Enemy2HP.text = "HP: " + EnemyTeam[1].ch.ActiveHealth.ToString() + "/" + EnemyTeam[1].ch.health.ToString();
            Enemy2Mana.text = "Mana: " + EnemyTeam[1].ch.ActiveMana.ToString() + "/" + EnemyTeam[1].ch.mana.ToString();
            Enemy2Lvl.text = "LvL: " + EnemyTeam[1].ch.lvl.ToString();
            if (EnemyTeam[1].ch.ch_class == 1)
            {
                Enemy2Class.text = "Class: " + damag;
            }
            else if (EnemyTeam[1].ch.ch_class == 2)
            {
                Enemy2Class.text = "Class: " + tank;
            }
            else if (EnemyTeam[1].ch.ch_class == 3)
            {
                Enemy2Class.text = "Class: " + healler;
            }
            else if (EnemyTeam[1].ch.ch_class == 4)
            {
                Enemy2Class.text = "Class: " + flank;
            }
            else if (EnemyTeam[1].ch.ch_class == 5)
            {
                Enemy2Class.text = "Class: " + uni;
            }
        }
        if (countEnemys == 3)
        {
            Enemy3Image.sprite = Resources.Load<Sprite>(EnemyTeam[2].ch.sprite);
            Enemy3Name.text = EnemyTeam[2].ch.Name;
            Enemy3HP.text = "HP: " + EnemyTeam[2].ch.ActiveHealth.ToString() + "/" + EnemyTeam[2].ch.health.ToString();
            Enemy3Mana.text = "Mana: " + EnemyTeam[2].ch.ActiveMana.ToString() + "/" + EnemyTeam[2].ch.mana.ToString();
            Enemy3Lvl.text = "LvL: " + EnemyTeam[2].ch.lvl.ToString();
            if (EnemyTeam[2].ch.ch_class == 1)
            {
                Enemy3Class.text = "Class: " + damag;
            }
            else if (EnemyTeam[2].ch.ch_class == 2)
            {
                Enemy3Class.text = "Class: " + tank;
            }
            else if (EnemyTeam[2].ch.ch_class == 3)
            {
                Enemy3Class.text = "Class: " + healler;
            }
            else if (EnemyTeam[2].ch.ch_class == 4)
            {
                Enemy3Class.text = "Class: " + flank;
            }
            else if (EnemyTeam[2].ch.ch_class == 5)
            {
                Enemy3Class.text = "Class: " + uni;
            }
        }
    }

    void SortList() //Сортировка Turn[]
    {
        FightChar temp;
        for (int i = 0; i < Turn.Count; i++)
        {
            for (int j = i + 1; j < Turn.Count; j++)
            {
                if (Turn[i].ch.speed < Turn[j].ch.speed)
                {
                    temp = Turn[i];
                    Turn[i] = Turn[j];
                    Turn[j] = temp;
                }
            }
        }
    }


    bool Interectable=true;


    //Upd
    void Update()
    {
        if (!flagEnd)
        {
            //Скрытие кнопок
            if (!isPlayerTurn)
            {
                foreach (Button btn in ButtonAttack)
                {
                    btn.gameObject.SetActive(false);
                }
            }
            else
            {
                foreach (Button btn in ButtonAttack)
                {
                    btn.gameObject.SetActive(true);
                }
            }

            if (!isPlayerTurn && Interectable) StartCoroutine(EnemyAI()); //Запускать ИИ

            //Проверка на ничью
            bool AllDeath = true;
            foreach (FightChar ch in HeroTeam)
            {
                if (ch.ch.ActiveHealth > 0) { AllDeath = false; }
                else ch.ch.ActiveHealth = 0;
            }
            foreach (FightChar ch in EnemyTeam)
            {
                if (ch.ch.ActiveHealth > 0) { AllDeath = false; }
                else ch.ch.ActiveHealth = 0;
            }
            if (AllDeath) { flagDraw = true; }
            //Проверки на победу и проигрыш
            if (!flagDraw)
            {
                AllDeath = true;
                foreach (FightChar ch in HeroTeam)
                {
                    if (ch.ch.ActiveHealth > 0) { AllDeath = false; }
                }
                if (AllDeath)
                {
                    flagLose = true;
                }
                AllDeath = true;
                foreach (FightChar ch in EnemyTeam)
                {
                    if (ch.ch.ActiveHealth > 0) { AllDeath = false; }
                }
                if (AllDeath)
                {
                    flagWin = true;
                }
            }
            if (!flagEnd)
                EndFight();
            //Активный персонаж -- жёлтая рамка
            ActiveCharacter.RamForFight.color = new Color(255f, 255f, 255f, 255f);
            foreach (Image im in Rams)
            {
                if (target < 3) //Для убирания лишних рамок
                {
                    if ((im.color.Equals(new Color(255f, 0f, 130f, 255f)) && (!im.Equals(Rams[target + 3]) || !isPlayerTurn)) || (im.color.Equals(new Color(255f, 255f, 255f, 255f)) && !im.Equals(ActiveCharacter.RamForFight))) im.color = new Color(0f, 0f, 0f, 0f);
                }
                else //Для убирания лишних рамок
                {
                    if ((im.color.Equals(new Color(255f, 0f, 130f, 255f)) && (!im.Equals(Rams[target - 3]) || !isPlayerTurn)) || (im.color.Equals(new Color(255f, 255f, 255f, 255f)) && !im.Equals(ActiveCharacter.RamForFight))) im.color = new Color(0f, 0f, 0f, 0f);
                }
            }
            //Установка красных рамок целям
            if (target != -1)
            {
                if (target < 3)
                {
                    Rams[target + 3].color = new Color(255f, 0f, 130f, 255f);
                }
                else
                {
                    Rams[target - 3].color = new Color(255f, 0f, 130f, 255f);
                }
            }

            //Обновление списка живых
            List<FightChar> list = new List<FightChar>();
            foreach (FightChar cch in Turn)
            {
                if (cch.ch.ActiveHealth <= 0) list.Add(cch);
            }
            foreach (FightChar cch in list)
            {
                Turn.Remove(cch);
            }
            foreach (FightChar cch in HeroTeam)
            {
                if (cch == Turn[0])
                {
                    isPlayerTurn = true;
                }
            }

            //Заполнение информации на поле

            //Skills
            if (isPlayerTurn)
            {
                if (ActiveCharacter.ch.skill1 != null)
                {
                    Skill1Btn.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(ActiveCharacter.ch.skill1.sprite);
                    Skill1Btn.gameObject.transform.GetChild(0).GetComponent<Text>().text = ActiveCharacter.ch.skill1.Name;
                    Skill1Btn.gameObject.transform.GetChild(2).GetComponent<Text>().text = ActiveCharacter.ch.skill1.Description;
                }
                else
                {
                    Skill1Btn.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("lock");
                    Skill1Btn.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Недоступно";
                    Skill1Btn.gameObject.transform.GetChild(2).GetComponent<Text>().text = "Скилл не выбран";
                }
                if (ActiveCharacter.ch.skill2 != null)
                {
                    Skill2Btn.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(ActiveCharacter.ch.skill2.sprite);
                    Skill2Btn.gameObject.transform.GetChild(0).GetComponent<Text>().text = ActiveCharacter.ch.skill2.Name;
                    Skill2Btn.gameObject.transform.GetChild(2).GetComponent<Text>().text = ActiveCharacter.ch.skill2.Description;
                }
                else
                {
                    Skill2Btn.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("lock");
                    Skill2Btn.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Недоступно";
                    Skill2Btn.gameObject.transform.GetChild(2).GetComponent<Text>().text = "Скилл не выбран";
                }
                if (ActiveCharacter.ch.skill3 != null)
                {
                    Skill3Btn.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(ActiveCharacter.ch.skill3.sprite);
                    Skill3Btn.gameObject.transform.GetChild(0).GetComponent<Text>().text = ActiveCharacter.ch.skill3.Name;
                    Skill3Btn.gameObject.transform.GetChild(2).GetComponent<Text>().text = ActiveCharacter.ch.skill3.Description;
                }
                else
                {
                    Skill3Btn.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("lock");
                    Skill3Btn.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Недоступно";
                    Skill3Btn.gameObject.transform.GetChild(2).GetComponent<Text>().text = "Скилл не выбран";
                }
                if (ActiveCharacter.ch.skill4 != null)
                {
                    Skill4Btn.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(ActiveCharacter.ch.skill4.sprite);
                    Skill4Btn.gameObject.transform.GetChild(0).GetComponent<Text>().text = ActiveCharacter.ch.skill4.Name;
                    Skill4Btn.gameObject.transform.GetChild(2).GetComponent<Text>().text = ActiveCharacter.ch.skill4.Description;
                }
                else
                {
                    Skill4Btn.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("lock");
                    Skill4Btn.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Недоступно";
                    Skill4Btn.gameObject.transform.GetChild(2).GetComponent<Text>().text = "Скилл не выбран";
                }
            }
            //Прочее
            MainHeroHP.text = "HP: " + HeroTeam[0].ch.ActiveHealth.ToString() + "/" + HeroTeam[0].ch.health.ToString();
            MainHeroMana.text = "Mana: " + HeroTeam[0].ch.ActiveMana.ToString() + "/" + HeroTeam[0].ch.mana.ToString();

            SecondHero1HP.text = "HP: " + HeroTeam[1].ch.ActiveHealth.ToString() + "/" + HeroTeam[1].ch.health.ToString();
            SecondHero1Mana.text = "Mana: " + HeroTeam[1].ch.ActiveMana.ToString() + "/" + HeroTeam[1].ch.mana.ToString();

            SecondHero2HP.text = "HP: " + HeroTeam[2].ch.ActiveHealth.ToString() + "/" + HeroTeam[2].ch.health.ToString();
            SecondHero2Mana.text = "Mana: " + HeroTeam[2].ch.ActiveMana.ToString() + "/" + HeroTeam[2].ch.mana.ToString();

            Enemy1HP.text = "HP: " + EnemyTeam[0].ch.ActiveHealth.ToString() + "/" + EnemyTeam[0].ch.health.ToString();
            Enemy1Mana.text = "Mana: " + EnemyTeam[0].ch.ActiveMana.ToString() + "/" + EnemyTeam[0].ch.mana.ToString();

            if (countEnemys >= 2)
            {
                Enemy2HP.text = "HP: " + EnemyTeam[1].ch.ActiveHealth.ToString() + "/" + EnemyTeam[1].ch.health.ToString();
                Enemy2Mana.text = "Mana: " + EnemyTeam[1].ch.ActiveMana.ToString() + "/" + EnemyTeam[1].ch.mana.ToString();

            }
            if (countEnemys == 3)
            {
                Enemy3HP.text = "HP: " + EnemyTeam[2].ch.ActiveHealth.ToString() + "/" + EnemyTeam[2].ch.health.ToString();
                Enemy3Mana.text = "Mana: " + EnemyTeam[2].ch.ActiveMana.ToString() + "/" + EnemyTeam[2].ch.mana.ToString();

            }
            if (Turn.Count > 1)
                NextTurn.text = "Следующий ход:\n" + Turn[1].ch.Name;
        }
    }

    int GetTarget(FightChar ch) //Получение позиции персонажа на поле
    {
        int targ = 0;
        foreach(FightChar cha in EnemyTeam)
        {
            if (cha.Equals(ch)) return targ;
            targ++;
        }
        foreach (FightChar cha in HeroTeam)
        {
            if (cha.Equals(ch)) return targ;
            targ++;
        }
        return targ;
    }
    IEnumerator EnemyAI() //ИИ врага
    {
        if (!flagEnd)
        {
            Interectable = false;
            yield return new WaitForSeconds(1f);
            int castSkill = -1;
            //Распределение ИИ по классам
            if (ActiveCharacter.ch.ch_class == 1)
            {
                if (ActiveCharacter.ch.skill1 != null && ActiveCharacter.ch.ActiveMana >= ActiveCharacter.ch.skill1.Manacost &&
                    ActiveCharacter.ch.skill1.WaitingTurnCount <= ActiveCharacter.ch.skill1.ActiveTurnWait) { castSkill = 1; target = GetTarget(ActiveCharacter); }
                else
                {
                    target = Random.Range(3, 6);
                    while (HeroTeam[target - 3].ch.ActiveHealth <= 0) { target = Random.Range(3, 6); yield return null; }
                }
                yield return new WaitForSeconds(2f); //Потом рандомизировать выбор скилла для каста
                if (castSkill==1) { Skill1(); }
                else if (castSkill==2) { Skill2(); }
                else
                {
                    CommonAtk();
                }
            }
            else if (ActiveCharacter.ch.ch_class == 2)
            {
            //    if (ActiveCharacter.ch.skill1 != null && ActiveCharacter.ch.ActiveMana >= ActiveCharacter.ch.skill1.Manacost &&
             //       ActiveCharacter.ch.skill1.WaitingTurnCount <= ActiveCharacter.ch.skill1.ActiveTurnWait) { castSkill = 1; target = GetTarget(ActiveCharacter); }
             //   else
             //   {
                    target = Random.Range(3, 6);
                    while (HeroTeam[target - 3].ch.ActiveHealth <= 0) { target = Random.Range(3, 6); yield return null; }
             //   }
                yield return new WaitForSeconds(2f); //Потом рандомизировать выбор скилла для каста
                if (castSkill == 1) { Skill1(); }
                else if (castSkill == 2) { Skill2(); }
                else
                {
                    CommonAtk();
                }
            }
            else if (ActiveCharacter.ch.ch_class == 3)
            {
                if (ActiveCharacter.ch.skill1 != null && ActiveCharacter.ch.ActiveMana >= ActiveCharacter.ch.skill1.Manacost &&
                        ActiveCharacter.ch.skill1.WaitingTurnCount <= ActiveCharacter.ch.skill1.ActiveTurnWait) {
                    if (EnemyTeam[0].ch.ActiveHealth > 0 && EnemyTeam[0].ch.ActiveHealth < EnemyTeam[0].ch.health * 0.6) { target = 0; castSkill = 1; }
                    else if (EnemyTeam[1].ch.ActiveHealth > 0 && EnemyTeam[1].ch.ActiveHealth < EnemyTeam[1].ch.health * 0.6) { target = 1; castSkill = 1; }
                    else if (EnemyTeam[2].ch.ActiveHealth > 0 && EnemyTeam[2].ch.ActiveHealth < EnemyTeam[2].ch.health * 0.6) { target = 2; castSkill = 1; }
                    else
                    {
                        target = Random.Range(3, 6);
                        while (HeroTeam[target - 3].ch.ActiveHealth <= 0) { target = Random.Range(3, 6); yield return null; };
                    }
                }
                else
                {
                    target = Random.Range(3, 6);
                    while (HeroTeam[target - 3].ch.ActiveHealth <= 0) { target = Random.Range(3, 6); yield return null; };
                }
                yield return new WaitForSeconds(2f);
                if (castSkill==1) Skill1();
                else if (castSkill==2) { Skill2(); }
                else
                {
                    CommonAtk();
                }
            }
            else
            {
                yield return new WaitForSeconds(1f);
                StartCoroutine(ChangeTurnCorutine());
            }
        }
    }
    IEnumerator ChangeTurnCorutine() //Смена хода
    {
        isChangeTurn = true;
        if (!flagEnd)
        {
            if (ActiveCharacter.ch.skill1 != null && ActiveCharacter.ch.skill1.WaitingTurnCount > ActiveCharacter.ch.skill1.ActiveTurnWait) ActiveCharacter.ch.skill1.ActiveTurnWait += 1; //Перезарядка скилла 1
            if (ActiveCharacter.ch.ActiveMana < ActiveCharacter.ch.mana / 2f) //Восстанавливать ли ману
            {
                yield return new WaitForSeconds(1f);
                ActiveCharacter.ch.ActiveMana += ActiveCharacter.ch.SpeedManaRegen; 
            }
            if (ActiveCharacter.ch.ActiveMana > ActiveCharacter.ch.mana) ActiveCharacter.ch.ActiveMana = ActiveCharacter.ch.mana;
            target = -1;
            Interectable = true;
            //Смена на следующего персонажа
            FightChar ch = Turn[0];
            Turn.RemoveAt(0);
            Turn.Add(ch);
            isPlayerTurn = false;
            List<FightChar> list = new List<FightChar>();
            foreach (FightChar cch in Turn)
            {
                if (cch.ch.ActiveHealth <= 0) list.Add(cch);
            }
            foreach (FightChar cch in list)
            {
                Turn.Remove(cch);
            }
            foreach (FightChar cch in HeroTeam)
            {
                if (cch == Turn[0])
                {
                    isPlayerTurn = true;
                }
            }
            ActiveCharacter = Turn[0];
            isChangeTurn = false;
        }
    }

    public void EndFight() //Конец боя
    {
        if (flagDraw) 
        {
            StopAllCoroutines();
            flagEnd = true;
            NextTurn.text = "Ничья!";
            foreach (FightChar ch in HeroTeam) { ch.ch.exp += (int)((ch.ch.NeedEXP * countEnemys * PowerEnemys) / (ch.ch.lvl * 8)); ch.ch.LevelUp(); }

            MainHeroLvl.text = "LvL: " + HeroTeam[0].ch.lvl.ToString();
            MainHeroEXP.text = "EXP: " + HeroTeam[0].ch.exp.ToString() + "/" + HeroTeam[0].ch.NeedEXP.ToString();
            SecondHero1Lvl.text = "LvL: " + HeroTeam[1].ch.lvl.ToString();
            SecondHero1Class.text = "EXP: " + HeroTeam[1].ch.exp.ToString() + "/" + HeroTeam[1].ch.NeedEXP.ToString();
            SecondHero2Lvl.text = "LvL: " + HeroTeam[2].ch.lvl.ToString();
            SecondHero2Class.text = "EXP: " + HeroTeam[2].ch.exp.ToString() + "/" + HeroTeam[2].ch.NeedEXP.ToString();
            EndBattle.SetActive(true);
            StartGame.flow.SetIntegerVariable("StoryBattle", 0);
            StartGame.flow.SendFungusMessage("Draw");
            UpdateEnd();
            SaveLoad.Save();
        }
        else if (flagWin)
        {
            StopAllCoroutines();
            NextTurn.text = "Победа!";
            flagEnd = true;
            foreach (FightChar ch in HeroTeam) { if (ch.Equals(StartGame.game.MainHero)) { ch.ch.exp += (int)((ch.ch.NeedEXP * countEnemys * PowerEnemys) / (ch.ch.lvl * 4)); } else ch.ch.exp += (int)((ch.ch.NeedEXP *countEnemys*PowerEnemys) / (ch.ch.lvl *2)); ch.ch.LevelUp(); } //если общий уровень врагов выше, то коэф силы выше в столько же раз, тоже про ниже
            if(Random.Range(1, 101) < StartGame.game.ChanseGiveWeapon)
            {
                StartGame.game.GiveRandomItem();
            }
            MainHeroLvl.text = "LvL: " + HeroTeam[0].ch.lvl.ToString();
            MainHeroEXP.text = "EXP: " + HeroTeam[0].ch.exp.ToString() + "/" + HeroTeam[0].ch.NeedEXP.ToString();
            SecondHero1Lvl.text = "LvL: " + HeroTeam[1].ch.lvl.ToString();
            SecondHero1Class.text = "EXP: " + HeroTeam[1].ch.exp.ToString() + "/" + HeroTeam[1].ch.NeedEXP.ToString();
            SecondHero2Lvl.text = "LvL: " + HeroTeam[2].ch.lvl.ToString();
            SecondHero2Class.text = "EXP: " + HeroTeam[2].ch.exp.ToString() + "/" + HeroTeam[2].ch.NeedEXP.ToString();
            EndBattle.SetActive(true);
            StartGame.flow.SetIntegerVariable("StoryBattle", 0);
            StartGame.flow.SendFungusMessage("Win");
            UpdateEnd();
            SaveLoad.Save();        
        }
        else if (flagLose)
        {
            StopAllCoroutines();
            NextTurn.text = "Поражение!";
            flagEnd = true;
            foreach (FightChar ch in HeroTeam) { ch.ch.LevelUp(); }

            MainHeroLvl.text = "LvL: " + HeroTeam[0].ch.lvl.ToString();
            MainHeroEXP.text = "EXP: " + HeroTeam[0].ch.exp.ToString() + "/" + HeroTeam[0].ch.NeedEXP.ToString();
            SecondHero1Lvl.text = "LvL: " + HeroTeam[1].ch.lvl.ToString();
            SecondHero1Class.text = "EXP: " + HeroTeam[1].ch.exp.ToString() + "/" + HeroTeam[1].ch.NeedEXP.ToString();
            SecondHero2Lvl.text = "LvL: " + HeroTeam[2].ch.lvl.ToString();
            SecondHero2Class.text = "EXP: " + HeroTeam[2].ch.exp.ToString() + "/" + HeroTeam[2].ch.NeedEXP.ToString();
            EndBattle.SetActive(true);
            if (StartGame.flow.GetIntegerVariable("StoryBattle") != 0)
            {
                //Начать битву заново
            }
            else
            {
                StartGame.flow.SendFungusMessage("Lose");
                UpdateEnd();
                SaveLoad.Save();
            }
        }
    }

    public static int target=-1;

    public void UpdateEnd()
    {
        for (int i = 0; i < 3; i++)
        {
            HeroTeam[i].ch.ActiveHealth = HeroTeam[i].ch.health;
            HeroTeam[i].ch.ActiveMana = HeroTeam[i].ch.mana;
            if (HeroTeam[i].ch.skill1 != null)
                HeroTeam[i].ch.skill1.ActiveTurnWait = HeroTeam[i].ch.skill1.WaitingTurnCount;
            if (HeroTeam[i].ch.skill2 != null)
                HeroTeam[i].ch.skill2.ActiveTurnWait = HeroTeam[i].ch.skill3.WaitingTurnCount;
            if (HeroTeam[i].ch.skill3 != null)
                HeroTeam[i].ch.skill3.ActiveTurnWait = HeroTeam[i].ch.skill3.WaitingTurnCount;
            if (HeroTeam[i].ch.skill4 != null)
                HeroTeam[i].ch.skill4.ActiveTurnWait = HeroTeam[i].ch.skill4.WaitingTurnCount;
        }
    }
    public void CommonAtk() //Проверки для обычной атаки
    {
        if (!isChangeTurn)
        {
            if (target == -1) { print("Цель не выбрана"); }
            else
            {
                if (target < 3)
                {
                    if (!isPlayerTurn) print(ActiveCharacter.ch.Name + " атакует " + EnemyTeam[target].ch.Name + " обычной атакой");
                    ActiveCharacter.ch.CommonAtk(EnemyTeam[target].ch);
                    if(EnemyTeam[target].ch.ReserveChance>= Random.Range(0, 100))
                    {
                        EnemyTeam[target].ch.CommonAtk(ActiveCharacter.ch);
                    }
                }
                else if (target >= 3)
                {
                    if (!isPlayerTurn) print(ActiveCharacter.ch.Name + " атакует " + HeroTeam[target - 3].ch.Name + " обычной атакой");
                    ActiveCharacter.ch.CommonAtk(HeroTeam[target - 3].ch);
                    if (HeroTeam[target - 3].ch.ReserveChance >= Random.Range(0, 100))
                    {
                        HeroTeam[target - 3].ch.CommonAtk(ActiveCharacter.ch);
                    }
                }
                StartCoroutine(ChangeTurnCorutine());
            }
        }
    }
   public static bool QuestionFlag = false;
    int QuestNumber=0;
    public static Questions q;
    IEnumerator Question() //Корутина с окошком вопросов
    {
        q = StartGame.game.ForMainHeroQuestions[Random.Range(0, StartGame.game.ForMainHeroQuestions.Count)];
        q.RandomAnsw();
        if(q.Object==1) QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Математика";
        if (q.Object == 2) QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Русский";
        if (q.Object == 3) QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Физика";
        if (q.Object == 4) QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "English";
        if (q.Object == 5) QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Информатика";
        if (q.Object == 6) QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Общество";
        if (q.Object == 7) QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Химия";
        if (q.Object == 8) QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Биология";
        if (!q.OnImage) 
        { 
            QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject.SetActive(false); QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = q.TextQuestion;
            QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject.SetActive(false); QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().fontSize = q.ShriftSize;
        }
        else { QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject.SetActive(true); QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(5).GetComponent<Image>().sprite = Resources.Load<Sprite>(q.sprite); }
        for (int i=1; i<5; i++)
        QuestionPanel.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text = q.Answers[i-1];
        while (true)
        {
            yield return null;
            if (QuestionFlag)
            {
                if (QuestNumber == 1) Skill1();
                if (QuestNumber == 2) Skill2();
                if (QuestNumber == 3) Skill3();
                if (QuestNumber == 4) Skill4();
                QuestionPanel.SetActive(false);
                QuestionFlag = false;
                break;
            }
        }
    }
    //Скиллы
    public void Skill1()
    {
        if (!isChangeTurn)
        {
            if (target == -1) { print("Цель не выбрана"); }
            else if (ActiveCharacter.ch.skill1 == null) { print("Заблокировано"); }
            else if (ActiveCharacter.ch.skill1.OnlyMyself && target != GetTarget(ActiveCharacter)) { print("Неподходящая цель"); }
            else if (ActiveCharacter.ch.ActiveMana < ActiveCharacter.ch.skill1.Manacost) { print("Недостаточно маны"); }
            else if (ActiveCharacter.ch.skill1.WaitingTurnCount > ActiveCharacter.ch.skill1.ActiveTurnWait) { print("Идёт откат способности"); }
            else
            {
                if (!QuestionFlag && isPlayerTurn)
                {
                    QuestionPanel.SetActive(true);
                    StartCoroutine(Question());
                    QuestNumber = 1;
                }
                else
                {
                    if (target < 3)
                    {
                        if (!isPlayerTurn) print(ActiveCharacter.ch.Name + " использует способность " + ActiveCharacter.ch.skill1.Name + " на " + EnemyTeam[target].ch.Name);
                        ActiveCharacter.ch.skill1.CastSkill(ActiveCharacter.ch, EnemyTeam[target].ch, ActiveCharacter.ch.RightAnswer);
                        if (EnemyTeam[target].ch.ReserveChance >= Random.Range(0, 100))
                        {
                            EnemyTeam[target].ch.CommonAtk(ActiveCharacter.ch);
                        }
                    }
                    else if (target >= 3)
                    {
                        if (!isPlayerTurn) print(ActiveCharacter.ch.Name + " использует способность " + ActiveCharacter.ch.skill1.Name + " на " + HeroTeam[target - 3].ch.Name);
                        ActiveCharacter.ch.skill1.CastSkill(ActiveCharacter.ch, HeroTeam[target - 3].ch, ActiveCharacter.ch.RightAnswer);
                        if (HeroTeam[target - 3].ch.ReserveChance >= Random.Range(0, 100))
                        {
                            HeroTeam[target - 3].ch.CommonAtk(ActiveCharacter.ch);
                        }
                    }
                    ActiveCharacter.ch.skill1.ActiveTurnWait = -1;
                    print(ActiveCharacter.ch.IncreaseATK);
                    StartCoroutine(ChangeTurnCorutine());
                }
            }
        }
    }
    public void Skill2()
    {
        if (!isChangeTurn)
        {
            if (target == -1) { print("Цель не выбрана"); }
            else if (ActiveCharacter.ch.skill2 == null) { print("Заблокировано"); }
            else if (ActiveCharacter.ch.skill2.OnlyMyself && target != GetTarget(ActiveCharacter)) { print("Неподходящая цель"); }
            else if (ActiveCharacter.ch.ActiveMana < ActiveCharacter.ch.skill2.Manacost) { print("Недостаточно маны"); }
            else if (ActiveCharacter.ch.skill2.WaitingTurnCount > ActiveCharacter.ch.skill2.ActiveTurnWait) { print("Идёт откат способности"); }
            else
            {
                if (!QuestionFlag && isPlayerTurn)
                {
                    QuestionPanel.SetActive(true);
                    StartCoroutine(Question());
                    QuestNumber = 1;
                }
                else
                {
                    if (target < 3)
                    {
                        if (!isPlayerTurn) print(ActiveCharacter.ch.Name + " использует способность " + ActiveCharacter.ch.skill2.Name + " на " + EnemyTeam[target].ch.Name);
                        ActiveCharacter.ch.skill2.CastSkill(ActiveCharacter.ch, EnemyTeam[target].ch, ActiveCharacter.ch.RightAnswer);
                        if (EnemyTeam[target].ch.ReserveChance >= Random.Range(0, 100))
                        {
                            EnemyTeam[target].ch.CommonAtk(ActiveCharacter.ch);
                        }
                    }
                    else if (target >= 3)
                    {
                        if (!isPlayerTurn) print(ActiveCharacter.ch.Name + " использует способность " + ActiveCharacter.ch.skill2.Name + " на " + HeroTeam[target - 3].ch.Name);
                        ActiveCharacter.ch.skill2.CastSkill(ActiveCharacter.ch, HeroTeam[target - 3].ch, ActiveCharacter.ch.RightAnswer);
                        if (HeroTeam[target - 3].ch.ReserveChance >= Random.Range(0, 100))
                        {
                            HeroTeam[target - 3].ch.CommonAtk(ActiveCharacter.ch);
                        }
                    }
                    ActiveCharacter.ch.skill2.ActiveTurnWait = -1;
                    print(ActiveCharacter.ch.IncreaseATK);
                    StartCoroutine(ChangeTurnCorutine());
                }
            }
        }
    }
    public void Skill3()
    {
        if (!isChangeTurn)
        {
            if (target == -1) { print("Цель не выбрана"); }
            else if (ActiveCharacter.ch.skill3 == null) { print("Заблокировано"); }
            else if (ActiveCharacter.ch.skill3.OnlyMyself && target != GetTarget(ActiveCharacter)) { print("Неподходящая цель"); }
            else if (ActiveCharacter.ch.ActiveMana < ActiveCharacter.ch.skill3.Manacost) { print("Недостаточно маны"); }
            else if (ActiveCharacter.ch.skill3.WaitingTurnCount > ActiveCharacter.ch.skill3.ActiveTurnWait) { print("Идёт откат способности"); }
            else
            {
                if (!QuestionFlag && isPlayerTurn)
                {
                    QuestionPanel.SetActive(true);
                    StartCoroutine(Question());
                    QuestNumber = 1;
                }
                else
                {
                    if (target < 3)
                    {
                        if (!isPlayerTurn) print(ActiveCharacter.ch.Name + " использует способность " + ActiveCharacter.ch.skill3.Name + " на " + EnemyTeam[target].ch.Name);
                        ActiveCharacter.ch.skill3.CastSkill(ActiveCharacter.ch, EnemyTeam[target].ch, ActiveCharacter.ch.RightAnswer);
                        if (EnemyTeam[target].ch.ReserveChance >= Random.Range(0, 100))
                        {
                            EnemyTeam[target].ch.CommonAtk(ActiveCharacter.ch);
                        }
                    }
                    else if (target >= 3)
                    {
                        if (!isPlayerTurn) print(ActiveCharacter.ch.Name + " использует способность " + ActiveCharacter.ch.skill3.Name + " на " + HeroTeam[target - 3].ch.Name);
                        ActiveCharacter.ch.skill3.CastSkill(ActiveCharacter.ch, HeroTeam[target - 3].ch, ActiveCharacter.ch.RightAnswer);
                        if (HeroTeam[target - 3].ch.ReserveChance >= Random.Range(0, 100))
                        {
                            HeroTeam[target - 3].ch.CommonAtk(ActiveCharacter.ch);
                        }
                    }
                    ActiveCharacter.ch.skill3.ActiveTurnWait = -1;
                    print(ActiveCharacter.ch.IncreaseATK);
                    StartCoroutine(ChangeTurnCorutine());
                }
            }
        }
    }
    public void Skill4()
    {
        if (!isChangeTurn)
        {
            if (target == -1) { print("Цель не выбрана"); }
            else if (ActiveCharacter.ch.skill4 == null) { print("Заблокировано"); }
            else if (ActiveCharacter.ch.skill4.OnlyMyself && target != GetTarget(ActiveCharacter)) { print("Неподходящая цель"); }
            else if (ActiveCharacter.ch.ActiveMana < ActiveCharacter.ch.skill4.Manacost) { print("Недостаточно маны"); }
            else if (ActiveCharacter.ch.skill4.WaitingTurnCount > ActiveCharacter.ch.skill4.ActiveTurnWait) { print("Идёт откат способности"); }
            else
            {
                if (!QuestionFlag && isPlayerTurn)
                {
                    QuestionPanel.SetActive(true);
                    StartCoroutine(Question());
                    QuestNumber = 1;
                }
                else
                {
                    if (target < 3)
                    {
                        if (!isPlayerTurn) print(ActiveCharacter.ch.Name + " использует способность " + ActiveCharacter.ch.skill4.Name + " на " + EnemyTeam[target].ch.Name);
                        ActiveCharacter.ch.skill4.CastSkill(ActiveCharacter.ch, EnemyTeam[target].ch, ActiveCharacter.ch.RightAnswer);
                        if (EnemyTeam[target].ch.ReserveChance >= Random.Range(0, 100))
                        {
                            EnemyTeam[target].ch.CommonAtk(ActiveCharacter.ch);
                        }
                    }
                    else if (target >= 3)
                    {
                        if (!isPlayerTurn) print(ActiveCharacter.ch.Name + " использует способность " + ActiveCharacter.ch.skill4.Name + " на " + HeroTeam[target - 3].ch.Name);
                        ActiveCharacter.ch.skill4.CastSkill(ActiveCharacter.ch, HeroTeam[target - 3].ch, ActiveCharacter.ch.RightAnswer);
                        if (HeroTeam[target - 3].ch.ReserveChance >= Random.Range(0, 100))
                        {
                            HeroTeam[target - 3].ch.CommonAtk(ActiveCharacter.ch);
                        }
                    }
                    ActiveCharacter.ch.skill4.ActiveTurnWait = -1;
                    print(ActiveCharacter.ch.IncreaseATK);
                    StartCoroutine(ChangeTurnCorutine());
                }
            }
        }
    }

    public void Results()
    {
        ClickBtn.EnemyFill();
        StartGame.flow.SendFungusMessage("Back To Menu");
        Destroy(FightLayout);
    }
}
