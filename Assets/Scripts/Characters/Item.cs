using System;

[Serializable]
public class Item 
{
   public Weapon weapon=null; 
   public int cost;
   public int rare;//1-мусор 2-ценность 3-ингридиент
   public string sprite;
    //Для доспехов/оружия 0-мусор 1-обычное 2-редкость 3-эпическое 4-легендарное 5-мифическое
    public Item(Weapon wp, int coins, int rare) //Создание оружия
    {
        weapon = wp;
        cost = coins;
        this.rare = rare;
        sprite = wp.sprite;
    }
    public Item(Weapon wp) //Создание оружия
    {
        weapon = wp;
        cost = wp.cost;
        rare = wp.rare;
        sprite = wp.sprite;
    }
}
