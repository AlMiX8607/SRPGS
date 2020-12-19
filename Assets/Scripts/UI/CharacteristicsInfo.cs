using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacteristicsInfo : MonoBehaviour
{
    public static int page = 1;
    void Start()
    {
        page = 1;
    }
    public void ChangePage(int NewPage)
    {
        page = NewPage;
    }
    private void FixedUpdate()
    {
        transform.GetChild(page - 1).gameObject.SetActive(true);
        for (int i = 0; i < 8; i++)
        {
           if(page-1!=i) transform.GetChild(i).gameObject.SetActive(false);
        }


        switch (page)
        {
            case 1:
                transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Уровень: " + (CharacterWindow.ch.lvl).ToString();
                transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Опыт: " + (CharacterWindow.ch.exp).ToString() + "/" + (CharacterWindow.ch.NeedEXP).ToString();
                transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "Здоровье: " + (CharacterWindow.ch.ActiveHealth).ToString() + "/" + (CharacterWindow.ch.health).ToString();
                transform.GetChild(0).GetChild(3).GetComponent<Text>().text = "Мана: " + (CharacterWindow.ch.ActiveMana).ToString() + "/" + (CharacterWindow.ch.mana).ToString();
                transform.GetChild(0).GetChild(4).GetComponent<Text>().text = "Скорость восстановления маны: +" + (CharacterWindow.ch.SpeedManaRegen).ToString() + " в ход";
                transform.GetChild(0).GetChild(5).GetComponent<Text>().text = "Удача: " + (CharacterWindow.ch.lucky).ToString();
                break;
            case 2:
                transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Сила: " + (CharacterWindow.ch.strength).ToString();
                transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "Ловкость: " + (CharacterWindow.ch.agility).ToString();
                transform.GetChild(1).GetChild(2).GetComponent<Text>().text = "Интеллект: " + (CharacterWindow.ch.intellect).ToString();
                transform.GetChild(1).GetChild(3).GetComponent<Text>().text = "Меткость: " + (CharacterWindow.ch.accuracy).ToString();
                transform.GetChild(1).GetChild(4).GetComponent<Text>().text = "Уклонение: " + (CharacterWindow.ch.dodge).ToString();
                transform.GetChild(1).GetChild(5).GetComponent<Text>().text = "Скорость: " + (CharacterWindow.ch.speed).ToString();
                break;
            case 3:
                transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Критический Урон: " + ((int)(CharacterWindow.ch.CritDamage * 100)).ToString() + "%";
                transform.GetChild(2).GetChild(1).GetComponent<Text>().text = "Шанс критической атаки: " + (CharacterWindow.ch.CriticalChance).ToString() + "%";
                transform.GetChild(2).GetChild(2).GetComponent<Text>().text = "Шанс ответной атаки: " + (CharacterWindow.ch.ReserveChance).ToString() + "%";
                transform.GetChild(2).GetChild(3).GetComponent<Text>().text = "Шанс двойной атаки: " + (CharacterWindow.ch.DoubleHit).ToString() + "%";
                transform.GetChild(2).GetChild(4).GetComponent<Text>().text = "Бонус физической атаки: +" + ((int)(CharacterWindow.ch.IncreaseATK - 1f) * 100).ToString() + "%";
                transform.GetChild(2).GetChild(5).GetComponent<Text>().text = "Сопротивляемость физическим атакам: " + ((int)(CharacterWindow.ch.Resistance) * 100).ToString() + "%";
                break;
            case 4:
                transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Бонус огненной атаки: +" + ((int)(CharacterWindow.ch.IncreaseFireDMG - 1f) * 100).ToString() + "%";
                transform.GetChild(3).GetChild(1).GetComponent<Text>().text = "Сопротивляемость Огню: " + ((int)(CharacterWindow.ch.FireResistance) * 100).ToString() + "%";
                transform.GetChild(3).GetChild(2).GetComponent<Text>().text = "Бонус ледяной атаки: +" + ((int)(CharacterWindow.ch.IncreaseIceDMG - 1f) * 100).ToString() + "%";
                transform.GetChild(3).GetChild(3).GetComponent<Text>().text = "Сопротивляемость Льду: " + ((int)(CharacterWindow.ch.IceResistance) * 100).ToString() + "%";
                transform.GetChild(3).GetChild(4).GetComponent<Text>().text = "Бонус ядовитой атаки: +" + ((int)(CharacterWindow.ch.IncreasePoisonDMG - 1f) * 100).ToString() + "%";
                transform.GetChild(3).GetChild(5).GetComponent<Text>().text = "Сопротивляемость Яду: " + ((int)(CharacterWindow.ch.PoisonResistance) * 100).ToString() + "%";
                break;
            case 5:
                transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "Бонус электрической атаки: +" + ((int)(CharacterWindow.ch.IncreaseElectricDMG - 1f) * 100).ToString() + "%";
                transform.GetChild(4).GetChild(1).GetComponent<Text>().text = "Сопротивляемость Электричеству: " + ((int)(CharacterWindow.ch.ElectricResistance) * 100).ToString() + "%";
                transform.GetChild(4).GetChild(2).GetComponent<Text>().text = "Бонус святой атаки: +" + ((int)(CharacterWindow.ch.IncreaseHolyDMG - 1f) * 100).ToString() + "%";
                transform.GetChild(4).GetChild(3).GetComponent<Text>().text = "Сопротивляемость Святости: " + ((int)(CharacterWindow.ch.HolyResistance) * 100).ToString() + "%";
                transform.GetChild(4).GetChild(4).GetComponent<Text>().text = "Бонус скверной атаки: +" + ((int)(CharacterWindow.ch.IncreaseDefilementDMG - 1f) * 100).ToString() + "%";
                transform.GetChild(4).GetChild(5).GetComponent<Text>().text = "Сопротивляемость Скверне: " + ((int)(CharacterWindow.ch.DefilementResistance) * 100).ToString() + "%";
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
        }
    }
}
