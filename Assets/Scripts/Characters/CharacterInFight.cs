using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[Serializable]
public class CharacterInFight
{
    public string sprite;
    //public Image RamForFight;
    public int health = 0;
    public int ActiveHealth = 0;
    public int lvl;
    public float exp;
    public float NeedEXP=10; //Сколько нужно опыта для следующего уровня
    public int mana;//Общее кол-во маны
    public int ActiveMana; //Мана на данный момент
    public string Name;
   // public int MagicShield = 0; //Позже для кинетической/магической брони
   // public int ActiveMagicShield = 0;
    public int speed = 0; // Определение очерёдности хода
    public float accuracy=0; //Меткость Ловкость+Интеллект
    public float dodge = 0; //Уклонение Ловкость+Сила       Шанс уклониться = 1 - Меткость атакующего / ( Меткость атакующего + (Уклонение цели / 4) ^ 0.8 )
    public float CriticalChance = 0; //Критический шанс обычной атаки Интеллект+Ловкость Max=45%
    //Для спелов у каждого свой шанс крита
    public float ReserveChance = 0; //Ловкость + Сила Max=30%
    public float DoubleHit = 0; //Сила + Интеллект Max=10%
    public int strength = 0;
    public int agility = 0;
    public int intellect = 0;
    public int lucky = 0; 
    public float CritDamage=2f;//Множитель крит атаки (без бонусов)
    public int SpeedManaRegen; //Скорость восстановления маны
    public int FreePoint; //Очки для распределения на характеристики

    public bool RightAnswer; //Для битвы, правильный ли ответ

    public float HITRATE;//(вероятность попадания)
    public float DODGE;//(уклонение)

    //Для врагов:
    public int ch_class; //1-дамаг 2-танк 3-хил 4-фланк(различные отравления, маскировки и подобное) 5-универсал
    public  Dictionary<Item, float> loot; //Предмет и шанс его выпадения
    //MISS(шанс промаха) = (уклонение_цели - ваш_хитрейт + 10)%
    //!!!  Добавить проверки на шанс уклонения 5%<=x<=80%

    public Skill skill1, skill2, skill3, skill4; //Скиллы в слотах
    public List<Skill> SkillList=new List<Skill>(); //Возможные скиллы

    public float IncreaseATK = 1f; //Бонус для физ атаки      Физика - оглушение (пропуск хода)
    public float IncreaseFireDMG = 1f; //Бонус для огненной атаки     Огонь - поджог (Получение урона (больше яда))
    public float IncreaseIceDMG = 1f; //Бонус для ледяной атаки   Лёд - заморозка (не регенит ману+понижение урона)
    public float IncreasePoisonDMG = 1f; //Бонус для ядовитой атаки     Яд - Отравление (получение урона + понижение всех сопротивляемостей на 5%)
    public float IncreaseElectricDMG = 1f; //Бонус для электрической атаки    Электричество - Паралич (Определённый шанс не походить, если ходит получает урон)
    public float IncreaseHolyDMG = 1f; //Бонус для святой атаки     Святость(Свет) - Молчание (Нельзя юзать скиллы)
    public float IncreaseDefilementDMG = 1f; //Бонус для скверной атаки      Скверна(Тьма) - Безумие (Шанс сменить цель атаки на случайную)


    public float Resistance = 0f;//Сопротивление физ атакам
    public float FireResistance = 0f; //Сопротивление огненным атакам
    public float IceResistance = 0f; //Сопротивление ледяным атакам
    public float PoisonResistance = 0f; //Сопротивление ядовитым атакам
    public float ElectricResistance = 0f; //Сопротивление электрическим атакам
    public float HolyResistance = 0f; //Сопротивление святым атакам
    public float DefilementResistance = 0f; //Сопротивление скверным атакам

    public List<Feature> Features = new List<Feature>(); 

    //Weapons
 //Оружие с разной стихией носить вместе незя
 //Носить оружие только во 2 руке незя, если снял с первой, то из второго слота перекидывает на первый
    /*   Equipment[0] = Weapon1;
       Equipment[1] = Weapon2;
       Equipment[2] = Book;
       Equipment[3] = Helmet;
       Equipment[4] = Armor;
       Equipment[5] = Leggings;
       Equipment[6] = Gloves;
       Equipment[7] = Belt;
       Equipment[8] = Boots;
       Equipment[9] = Adornment1;
       Equipment[10] = Adornment2; */
    public Weapon[] Equipment = new Weapon[11];


    public CharacterInFight(string Name, int lvl, string sprite)
    {
        this.Name = Name;
        this.sprite = sprite;
        this.lvl = lvl;
        MathCharacteristic();
    }
    public CharacterInFight(string Name, int lvl, int Class, string sprite)
    {
        this.Name = Name;
        ch_class = Class;
        this.sprite = sprite;
        this.lvl = lvl;
        MathCharacteristic();
    }
    public CharacterInFight(string Name, int lvl, int Class, Dictionary<Item, float> loot, string sprite)
    {
        this.Name = Name;
        this.loot = loot;
        ch_class = Class;
        this.sprite = sprite;
        this.lvl = lvl;
        MathCharacteristic();
    }




    public void UpdateCharacteristic()
    {
        Features.Clear();
            foreach (Weapon wp in Equipment)
        {
            if (wp != null)
            {
                foreach (Feature ft in wp.FeaturesWeapon)
                {
                    Features.Add(ft);
                }
            }
        }


        health = lvl * 5;
        health += strength / 4;

        mana = lvl * 3;
        SpeedManaRegen = intellect / 5;
        mana += SpeedManaRegen;
        if (SpeedManaRegen < 1) SpeedManaRegen = 1;



        speed = agility;

        dodge = strength + agility * 1.2f;
        accuracy = agility + intellect * 1.2f;
        //Resistance = intellect + strength * 1.2f;


        CriticalChance = (agility + intellect + lucky / 10f) / 15f;
        CriticalChance = (int)(CriticalChance * 100) / 100f;
        ReserveChance = (strength + agility + lucky / 10f) / 15f;
        ReserveChance = (int)(ReserveChance * 100) / 100f;
        DoubleHit = (strength + intellect + lucky / 10f) / 30f;
        DoubleHit = (int)(DoubleHit * 100) / 100f;
        if (ReserveChance < 1) ReserveChance = 1f;
        if (CriticalChance < 1) CriticalChance = 1f;
        if (DoubleHit < 0.5) DoubleHit = 0.5f;
        if (ReserveChance > 35) ReserveChance = 35;
        if (CriticalChance > 35) CriticalChance = 35;
        if (DoubleHit > 15) DoubleHit = 15;

        DODGE = dodge + lvl * 2 + 5;

        HITRATE = accuracy + lvl * 2 + 5;


        foreach(Feature ft in Features)
        {
            //Здесь будем добавлять в бонусные переменные, не забыть их обнулять перед этим
        }
    }

    public void LevelUp() //Проверка на повышение уровня
    {
        if (exp >= NeedEXP)
        {
            lvl++;
            FreePoint += 5;
            NewLvl();
            exp -= NeedEXP;
            NeedEXP *= 1.5f;
            NeedEXP = (int)NeedEXP;
        }
    }
    public void NewLvl() //Повышение уровня + пересчёт характеристик
    {
        if (FreePoint >= 2)
        {
            int luckyAdd = UnityEngine.Random.Range(0, 3);
            FreePoint -= luckyAdd;
            lucky += luckyAdd;
        }
        while (FreePoint > 0)
        {
            int characteristic = UnityEngine.Random.Range(0, 3);
            if (characteristic == 0) strength++;
            if (characteristic == 1) agility++;
            if (characteristic == 2) intellect++;
            FreePoint--;
        }
        UpdateCharacteristic();

        ActiveHealth = health;
        ActiveMana = mana;
    }
        public void MathCharacteristic() //Установка определённого уровня (но при этом все характеристики распределяются рандомно снова)
    {
        for (int i = 1; i <= lvl; i++)
        {
            if (i != 1)
            {
                NeedEXP *= 1.5f;
                NeedEXP = (int)NeedEXP;
            }
            int point = 5;
            int luckyAdd = UnityEngine.Random.Range(0, 3);
            point -= luckyAdd;
            lucky += luckyAdd;
            while (point > 0)
            {
                int characteristic = UnityEngine.Random.Range(0, 3);
                if (characteristic == 0) strength++;
                if (characteristic == 1) agility++;
                if (characteristic == 2) intellect++;
                point--;
            }
        }
        UpdateCharacteristic();
        ActiveHealth = health;
        ActiveMana = mana;
/*
        //hero.ActiveMagicShield = hero.MagicShield;
        print(Name);
        print("Здоровье: " + ActiveHealth + "/" + health);
        print("Мана: " + ActiveMana + "/" + mana);
        //print("Магический щит: " + hero.ActiveMagicShield + "/" + hero.MagicShield);
        print("Сила: " + strength);
        print("Ловкость: " + agility);
        print("Интеллект: " + intellect);
        print("Удача: " + lucky);
        print("Скорость: " + speed);
        print("Ваше уклонение: " + dodge);
        print("Ваша меткость: " + accuracy);
        print("Ваше сопротивление: " + resistance);
        print("Ваш шанс нанести критический удар: " + CriticalChance + "%");
        print("Ваш шанс нанести ответный удар: " + ReserveChance + "%");
        print("Ваш шанс двойной атаки: " + DoubleHit + "%");


        print("Ваш шанс уклониться и Хитрейт: " + DODGE+" "+ HITRATE);

        print("Шанс уклониться против такой же меткости " + (DODGE - HITRATE + 10) +"%");
        print("Шанс уклониться против меткости выше" + (DODGE - (HITRATE+30) + 10) + "%");
        print("Шанс уклониться против меткости ниже" + (DODGE - (HITRATE-30)+ 10) + "%");*/
    }




    bool FDoubleHit = false; //Двойной ли удар
    bool Miss = false; //Промахнулся ли
    public void CommonAtk(CharacterInFight enemy) //Обычная атака
    {
            float Damage=0;
            bool isWeaponed = (Equipment[0] != null) || (Equipment[1] != null);


            if (isWeaponed)
            {
                if (Equipment[0] != null) Damage += UnityEngine.Random.Range(Equipment[0].MIN_Damage, Equipment[0].MAX_Damage);
                if (Equipment[1] != null) Damage += UnityEngine.Random.Range(Equipment[1].MIN_Damage, Equipment[1].MAX_Damage);
            }
        else { Damage = 1; }
            Damage += strength / 5;
            if (CheckMiss(enemy))
            {
                //print("Промах");
                Miss = true;
            }
            else if (CheckCriticalHit())
            {
               // print("Критическое попадание!");
                Damage = (int)(Damage * CritDamage);
            }
        if (!Miss)
        {
            if (isWeaponed) 
            {
                if (Equipment[0].Element == 0) { Damage = (1 - enemy.Resistance) * (Damage * IncreaseATK); }
                if (Equipment[0].Element == 1) { Damage = (1 - enemy.FireResistance) * (Damage * IncreaseFireDMG); }
                if (Equipment[0].Element == 2) { Damage = (1 - enemy.IceResistance) * (Damage * IncreaseIceDMG); }
                if (Equipment[0].Element == 3) { Damage = (1 - enemy.PoisonResistance) * (Damage * IncreasePoisonDMG); }
                if (Equipment[0].Element == 4) { Damage = (1 - enemy.ElectricResistance) * (Damage * IncreaseElectricDMG); }
                if (Equipment[0].Element == 5) { Damage = (1 - enemy.HolyResistance) * (Damage * IncreaseHolyDMG); }
                if (Equipment[0].Element == 6) { Damage = (1 - enemy.DefilementResistance) * (Damage * IncreaseDefilementDMG); }
                if (Damage < 0) Damage = 0;
            }
            else if(IncreaseATK>0) Damage *= IncreaseATK;
            else if (IncreaseATK<=0) Damage = 0;

            enemy.ActiveHealth -= (int)Damage;
        }
        else Miss = false;

            if (!FDoubleHit)
            {
                if (CheckDoubleHit())
                {
                    //print("Второй удар!");
                    FDoubleHit = true;
                    CommonAtk(enemy);
                }
            }
            else { FDoubleHit = false;}
    }
    //Скиллы
    public void Skill1(CharacterInFight enemy)
    {
        skill1.CastSkill(this, enemy, RightAnswer);
    }
    public void Skill2(CharacterInFight enemy)
    {
        skill2.CastSkill(this, enemy, RightAnswer);
    }
    public void Skill3(CharacterInFight enemy)
    {
        skill3.CastSkill(this, enemy, RightAnswer);
    }
    public void Skill4(CharacterInFight enemy)
    {
        skill4.CastSkill(this, enemy, RightAnswer);
    }
    //Проверки на шансы
    public bool CheckCriticalHit()
    {
        if (UnityEngine.Random.Range(0, 100) < CriticalChance)
            return true;
        return false;
    }
    public bool CheckMiss(CharacterInFight defender)
    {
        int MissChanse = (int)(defender.DODGE - HITRATE + 10);
        if (MissChanse < 5) MissChanse = 5;
        if (MissChanse > 80) MissChanse = 80;
        if (UnityEngine.Random.Range(0, 100) < MissChanse)
            return true;
        return false;
    }
    public bool CheckDoubleHit()
    {
        if (UnityEngine.Random.Range(0, 100) < DoubleHit)
            return true;
        return false;
    }
}
