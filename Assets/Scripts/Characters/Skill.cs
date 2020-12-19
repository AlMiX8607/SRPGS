using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
   public int id;
   public int Manacost;
   public string Name, Description;
   public int WaitingTurnCount; //Ходов для перезарядки
   public int ActiveTurnWait; //Текущее кол-во ходов, которое уже идёт перезарядка
   public string sprite; //Спрайт умения
   public int Type; //Тип умения (стихия) 0-физические, 1-огненные, 5-свет
    public bool OnlyMyself=false;

    public Skill(int id, CharacterInFight owner)  //Конструктор
    {
        this.id = id;
        switch (id)
        {
            case 1:
                Name= "Исцеление";
                Description = "Исцелить цель на 30% от максимального здоровья";
                Type = 5;
                Manacost =(int)(owner.mana*0.3);
                if (Manacost == 0) Manacost = 1;
                WaitingTurnCount = 1;
                ActiveTurnWait = WaitingTurnCount;
                sprite = "id_1";
                break;
            case 2:
                Name = "Усиление";
                Description = "Повысить атаку применившего на 50%";
                Type = 1;
                Manacost = (int)(owner.mana * 0.3);
                if (Manacost == 0) Manacost = 1;
                WaitingTurnCount = 1;
                ActiveTurnWait = WaitingTurnCount;
                sprite ="id_1";
                OnlyMyself = true;
                break;
        }
    }

    public void CastSkill(CharacterInFight Caster, CharacterInFight target, bool Question) //Использование скилла
    {
        float dmg = 0;
        int heal=0;
        float IncreaseAttack=0;
        float DownAttack = 0;
        switch (id)
        {
            case 1: //Исцеление
                heal = (int)(target.health * 0.3);
                if (Fight.isPlayerTurn)
                {
                    if (Question) { heal += heal / 2;}
                    else { heal -= heal / 2; }
                }
                if (heal == 0) heal = 1;
                break;
            case 2: //Усиление
                IncreaseAttack = 0.5f;
                target = Caster;
                if (Fight.isPlayerTurn)
                {
                    if (Question) { IncreaseAttack += IncreaseAttack / 2; }
                    else { IncreaseAttack -= IncreaseAttack / 2; }
                }
                break;
        }
        //Damage
        if (Type == 0) { dmg = (1 - target.Resistance) * (dmg * Caster.IncreaseATK); }
        if (Type == 1) { dmg = (1 - target.FireResistance) * (dmg * Caster.IncreaseFireDMG); }
        if (Type == 2) { dmg = (1 - target.IceResistance) * (dmg * Caster.IncreaseIceDMG); }
        if (Type == 3) { dmg = (1 - target.PoisonResistance) * (dmg * Caster.IncreasePoisonDMG); }
        if (Type == 4) { dmg = (1 - target.ElectricResistance) * (dmg * Caster.IncreaseElectricDMG); }
        if (Type == 5) { dmg = (1 - target.HolyResistance) * (dmg * Caster.IncreaseHolyDMG); }
        if (Type == 6) { dmg = (1 - target.DefilementResistance) * (dmg * Caster.IncreaseDefilementDMG); }
        if (dmg < 0) dmg = 0;
        target.ActiveHealth -= (int)dmg;
        if (target.ActiveHealth < 0) target.ActiveHealth = 0;

        //Heal
        if (target.ActiveHealth > 0) target.ActiveHealth += heal;
        if (target.ActiveHealth > target.health) target.ActiveHealth = target.health;
        Caster.ActiveMana -= Manacost;

        //Update ATK
        target.IncreaseATK += IncreaseAttack;
        target.IncreaseATK -= DownAttack;
    }
}
