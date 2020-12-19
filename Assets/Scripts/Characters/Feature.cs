using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Feature
{
    public string Description;
    public int id;
    public int rarity; //0-отрицательный эффект 1-обычное 2-редкое 3-мифическое 4-легендарное 5-Ангельское (Бонусы для льда, святости, электричества)/Дьявольское(для яда, огня, скверны) (Зависит от кармы)

    public float IncreaseAllDmg = 0;
    public float IncreaseElementsDmg = 0;
    public float IncreasePhysDmg = 0f; //Бонус для физ атаки      Физика - оглушение (пропуск хода)
    public float IncreaseFireDMG = 0f; //Бонус для огненной атаки     Огонь - поджог (Получение урона (больше яда))
    public float IncreaseIceDMG = 0f; //Бонус для ледяной атаки   Лёд - заморозка (не регенит ману+понижение урона)
    public float IncreasePoisonDMG = 0f; //Бонус для ядовитой атаки     Яд - Отравление (получение урона + понижение всех сопротивляемостей на 5%)
    public float IncreaseElectricDMG = 0f; //Бонус для электрической атаки    Электричество - Паралич (Определённый шанс не походить, если ходит получает урон)
    public float IncreaseHolyDMG = 0f; //Бонус для святой атаки     Святость(Свет) - Молчание (Нельзя юзать скиллы)
    public float IncreaseDefilementDMG = 0f; //Бонус для скверной атаки      Скверна(Тьма) - Безумие (Шанс сменить цель атаки на случайную)


    public float PhysResistance = 0f;//Сопротивление физ атакам
    public float FireResistance = 0f; //Сопротивление огненным атакам
    public float IceResistance = 0f; //Сопротивление ледяным атакам
    public float PoisonResistance = 0f; //Сопротивление ядовитым атакам
    public float ElectricResistance = 0f; //Сопротивление электрическим атакам
    public float HolyResistance = 0f; //Сопротивление святым атакам
    public float DefilementResistance = 0f; //Сопротивление скверным атакам





    public Feature(int id, int rarity) //Подаём айди и редкость
    {
        this.id = id;
        this.rarity = rarity;

        switch (id)
        {
            case 1:
                switch (rarity)
                {
                    case 0:
                        IncreasePhysDmg = (-Random.Range(5, 96)) / 100f;
                        break;
                    case 1:
                        IncreasePhysDmg = Random.Range(5, 16) / 100f;
                        break;
                    case 2:
                        IncreasePhysDmg = Random.Range(16, 31) / 100f;
                        break;
                    case 3:
                        IncreasePhysDmg = Random.Range(31, 51) / 100f;
                        break;
                    case 4:
                        IncreasePhysDmg = Random.Range(51, 76) / 100f;
                        break;
                    case 5:
                        IncreasePhysDmg = Random.Range(76, 101) / 100f;
                        KarmaSystem();
                        break;
                    }
                Description = "Повышает физическую атаку на " + IncreasePhysDmg.ToString();
                break;
        }
    }


    public void KarmaSystem()
    {
        if (StartGame.game.karma <= -100)
        {
            switch (Random.Range(0, 6))
            {
                case 0:
                    IncreaseFireDMG += 1f;
                    break;
                case 1:
                    IncreasePoisonDMG += 1f;
                    break;
                case 2:
                    IncreaseDefilementDMG += 1f;
                    break;
                case 3:
                    FireResistance += 0.5f;
                    break;
                case 4:
                    PoisonResistance += 0.5f;
                    break;
                case 5:
                    DefilementResistance += 0.5f;
                    break;
            }
            switch (Random.Range(0, 6))
            {
                case 0:
                    IncreaseIceDMG += -0.5f;
                    break;
                case 1:
                    IncreaseElectricDMG += -0.5f;
                    break;
                case 2:
                    IncreaseHolyDMG += -0.5f;
                    break;
                case 3:
                    IceResistance += -1f;
                    break;
                case 4:
                    ElectricResistance += -1f;
                    break;
                case 5:
                    HolyResistance += -1f;
                    break;
            }
        }
        else if (StartGame.game.karma>=100)
        {
            switch (Random.Range(0, 6))
            {
                case 0:
                    IncreaseIceDMG += 1f;
                    break;
                case 1:
                    IncreaseElectricDMG += 1f;
                    break;
                case 2:
                    IncreaseHolyDMG += 1f;
                    break;
                case 3:
                    IceResistance += 0.5f;
                    break;
                case 4:
                    ElectricResistance += 0.5f;
                    break;
                case 5:
                    HolyResistance += 0.5f;
                    break;
            }
            switch (Random.Range(0, 6))
            {
                case 0:
                    IncreaseFireDMG += -0.5f;
                    break;
                case 1:
                    IncreasePoisonDMG += -0.5f;
                    break;
                case 2:
                    IncreaseDefilementDMG += -0.5f;
                    break;
                case 3:
                    FireResistance += -1f;
                    break;
                case 4:
                    PoisonResistance += -1f;
                    break;
                case 5:
                    DefilementResistance += 1f;
                    break;
            }
        }
    }

    public static Feature RandomFeature()
    {
        int rare = 0;
        int k = 10 - StartGame.game.MainHero.lucky/30;
        if (k < 2) k = 2;
        int k1 = Random.Range(1, k);
        int k2 = Random.Range(1, k);
        int k3 = Random.Range(1, k);
        int k4 = Random.Range(1, k);
        int k5 = Random.Range(1, k);
        if (k1 == 1)
        {
            rare++;
        }
        if (k2 == 1)
        {
            rare++;
        }
        if (k3 == 1)
        {
            rare++;
        }
        if (k4 == 1)
        {
            rare++;
        }
        if (k5 == 1)
        {
            rare++;
        }

        return new Feature(Random.Range(1,2), rare);//Не забывать изменять
    }
}
