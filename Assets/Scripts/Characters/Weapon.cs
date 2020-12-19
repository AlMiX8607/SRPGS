using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon //Класс, хранящий информацию об обмундировании (оружие, шлемы и прочее)
{
    public int MIN_Damage, MAX_Damage;
    //public int Armor; //Защита для не оружия
    public int type; //0-Одноручное оружие  1-двуручное 2-книга
    public string Name;
    public int cost;
    public int lvl;
    public int rare;
    public int Element; //0-Физика, 1-Огонь, 2-Лёд, 3-Яд, 4-Электричество, 5-Святость, 6-Скверна
    public Skill skill;
    public bool DoubleWeapon;
    public string sprite;
    public string ElementName;
    public string typeName;


    public List<Feature> FeaturesWeapon = new List<Feature>();

    //Особенности хранятся в листах, рандомно определяется тип, редкость и элемент предмета (или задаются)
    //Если выпали например Ботинки Мороза, то выбирается 1-2 особенности из списка "Особенности ботинок" и 1-2 из списка "Особенности Холода"
    //Редкость влияет на силу особенностей, сколько редкостей, столько и ступеней силы (например наносит не +20% урона, а +25%)
    //Могут выпасть также скиллы, они занимают слот особенности, но обязательно привязаны к элементу выпавшего предмета
    
    
    public static Weapon RandomGenerate(int type, int elem, bool random)
    {
        Weapon wp = new Weapon();
        wp.type = type;
        wp.Element = elem;
        if (random)
        {
            wp.type = UnityEngine.Random.Range(0, 10);
            wp.Element = UnityEngine.Random.Range(0, 7);
        }
        wp.Name = "";

        switch (wp.type)
        {
            case 0:
                wp.typeName = "Одноручное оружие";
                switch (UnityEngine.Random.Range(0, 8))
                {
                    case 0:
                        wp.Name += "Клинок ";
                        wp.sprite = "sword";
                        break;
                    case 1:
                        wp.Name += "Кинжал ";
                        wp.sprite = "dagger";
                        break;
                    case 2:
                        wp.Name += "Кистень ";
                        wp.sprite = "kisten";
                        break;
                    case 3:
                        wp.Name += "Секира ";
                        wp.sprite = "sekiro";
                        break;
                    case 4:
                        wp.Name += "Булава ";
                        wp.sprite = "bulava";
                        break;
                    case 5:
                        wp.Name += "Сабля ";
                        wp.sprite = "sablya";
                        break;
                    case 6:
                        wp.Name += "Кнут ";
                        wp.sprite = "knut";
                        break;
                    case 7:
                        wp.Name += "Палица ";
                        // wp.sprite = "baton";
                        wp.sprite = "palica";
                        break;
                }
                int LvlForMinRand = StartGame.game.MainHero.lvl / 3;
                if (LvlForMinRand == 0) LvlForMinRand = 1;
                wp.MIN_Damage = UnityEngine.Random.Range(LvlForMinRand, StartGame.game.MainHero.lvl + 1);
                wp.MAX_Damage = UnityEngine.Random.Range(wp.MIN_Damage, wp.MIN_Damage+StartGame.game.MainHero.lvl + 1);
                wp.lvl = StartGame.game.MainHero.lvl;
                break;
            case 1:
                wp.typeName = "Двуручное оружие";
                wp.DoubleWeapon = true;
                switch (UnityEngine.Random.Range(0, 7))
                {
                    case 0:
                        wp.Name += "Коса ";
                        wp.sprite = "kosa";
                        break;
                    case 1:
                        wp.Name += "Двуручный меч ";
                        wp.sprite = "berserk";
                        break;
                    case 2:
                        wp.Name += "Молот ";
                        wp.sprite = "molot";
                        break;
                    case 3:
                        wp.Name += "Катана ";
                        wp.sprite = "katana";
                        break;
                    case 4:
                        wp.Name += "Копьё ";
                        wp.sprite += "kopiy";
                        break;
                    case 5:
                        wp.Name += "Алебарда ";
                        wp.sprite += "alebard";
                        break;
                    case 6:
                        wp.Name += "Кусаригама ";
                        wp.sprite = "kusarigama";
                        break;
                }
                wp.MIN_Damage = UnityEngine.Random.Range(StartGame.game.MainHero.lvl, StartGame.game.MainHero.lvl*2 + 1);
                wp.MAX_Damage = UnityEngine.Random.Range(wp.MIN_Damage, wp.MIN_Damage+StartGame.game.MainHero.lvl*2 + 1);
                wp.lvl = StartGame.game.MainHero.lvl;
                break;
            case 2:
                wp.typeName = "Книга";
                switch (UnityEngine.Random.Range(0, 1))
                {
                    case 0:
                        wp.Name += "Книга ";
                        wp.sprite = "book";
                        break;
               /*     case 1:
                        wp.Name += "Учебник ";
                        break;
                    case 2:
                        wp.Name += "Сборник ";
                        wp.sprite = "sbornik";
                        break;
                    case 3:
                        wp.Name += "Атлас ";
                        wp.sprite = "atlas";
                        break; */
                }
                break;
            case 3:
                wp.typeName = "Шлем";
                switch (UnityEngine.Random.Range(0, 2))
                {
                    case 0:
                        wp.Name += "Шлем ";
                        wp.sprite = "helmet";
                        break;
                    case 1:
                        wp.Name += "Шляпа ";
                        wp.sprite = "hat";
                        break;
                }
                break;
            case 4:
                wp.typeName = "Доспех";
                switch (UnityEngine.Random.Range(0, 2))
                {
                    case 0:
                        wp.Name = "Доспех ";
                        wp.sprite = "armor";
                        break;

                    case 1:
                        wp.Name = "Куртка ";
                        wp.sprite = "armor2";
                        break;
                }
                break;
            case 5:
                wp.typeName = "Штаны";
                switch (UnityEngine.Random.Range(0, 2))
                {
                    case 0:
                        wp.Name += "Штаны ";
                        wp.sprite = "shtans";
                        break;
                    case 1:
                        wp.Name += "Поножи ";
                        wp.sprite = "legg";
                        break;
                }
                break;
            case 6:
                wp.typeName = "Перчатки";
                wp.Name += "Перчатки ";
                wp.sprite = "arm";
                break;
            case 7:
                wp.typeName = "Пояс";
                wp.Name += "Пояс ";
                wp.sprite = "belt";
                break;
            case 8:
                wp.typeName = "Сапоги";
                wp.Name += "Сапоги ";
                wp.sprite = "boots";
                break;
            case 9:
                wp.typeName = "Украшение";
                switch (UnityEngine.Random.Range(0, 5))
                {
                    case 0:
                        wp.Name += "Амулет ";
                        wp.sprite = "amulet";
                        break;
                    case 1:
                        wp.Name += "Кольцо ";
                        wp.sprite = "ring";
                        break;
                    case 2:
                        wp.Name += "Линзы ";
                        wp.sprite = "lins";
                        break;
                    case 3:
                        wp.Name += "Талисман ";
                        wp.sprite = "tal";
                        break;
                    case 4:
                        wp.Name += "Маска ";
                        wp.sprite = "mask";
                        break;
                }
                        break;
        }

        switch (wp.Element)
        {
            case 0:
                wp.ElementName = "Без элемента";
                switch (UnityEngine.Random.Range(0, 10))
                {//Обычный цвет FFFFFF
                    case 0:
                        wp.Name += "Медвежьей силы"; //Силы
                        break;
                    case 1:
                        wp.Name += "Обезьяней ловкости"; //Ловкости
                        break;
                    case 2:
                        wp.Name += "Совиной мудрости"; //Интеллекта
                        break;
                    case 3:
                        wp.Name += "Гепардовой скорости"; //Скорости
                        break;
                    case 4:
                        wp.Name += "Павлиньей удачи"; //Удачи
                        break;
                    case 5:
                        wp.Name += "Лабораторной крысы"; //Опыта
                        break;
                    case 6:
                        wp.Name += "Бычьего здоровья"; //Здоровья
                        break;
                    case 7:
                        wp.Name += "Орлиной зоркости"; //Меткости
                        break;
                    case 8:
                        wp.Name += "Змеиной изворотливости"; //Уклонения
                        break;
                    case 9:
                        wp.Name += "Волчьей смелости"; //Сопротивление доп. эффектам
                        break;
                }
                break;
            case 1: //Красный FF4831
                wp.ElementName = "Огонь";
                switch (UnityEngine.Random.Range(0, 4))
                {
                    case 0:
                        wp.Name += "Огня";
                        break;
                    case 1:
                        wp.Name += "Пламени";
                        break;
                    case 2:
                        wp.Name += "Жара";
                        break;
                    case 3:
                        wp.Name += "Пекла";
                        break;
                }
                break;
            case 2: //голубой  51F4F5
                wp.ElementName = "Лёд";
                switch (UnityEngine.Random.Range(0, 4))
                {
                    case 0:
                        wp.Name += "Льда";
                        break;
                    case 1:
                        wp.Name += "Мороза";
                        break;
                    case 2:
                        wp.Name += "Снега";
                        break;
                    case 3:
                        wp.Name += "Холода";
                        break;
                }
                break;
            case 3: //зелёный 25C81D
                wp.ElementName = "Яд";
                switch (UnityEngine.Random.Range(0, 4))
                {
                    case 0:
                        wp.Name += "Яда";
                        break;
                    case 1:
                        wp.Name += "Отравы";
                        break;
                    case 2:
                        wp.Name += "Токсина";
                        break;
                    case 3:
                        wp.Name += "Желчи";
                        break;
                }
                break;
            case 4: //жёлтый FFFF00
                wp.ElementName = "Электричество"; 
                switch (UnityEngine.Random.Range(0, 4))
                {
                    case 0:
                        wp.Name += "Электричества";
                        break;
                    case 1:
                        wp.Name += "Грома";
                        break;
                    case 2:
                        wp.Name += "Молний";
                        break;
                    case 3:
                        wp.Name += "Разряда";
                        break;
                }
                        break;
            case 5: //Не знаю EBFF7F
                wp.ElementName = "Святость";
                switch (UnityEngine.Random.Range(0, 4))
                {
                    case 0:
                        wp.Name += "Святости";
                        break;
                    case 1:
                        wp.Name += "Света";
                        break;
                    case 2:
                        wp.Name += "Божества";
                        break;
                    case 3:
                        wp.Name += "Молитвы";
                        break;
                }
                break;
            case 6://фиолетовый BA0F7C
                wp.ElementName = "Скверна";
                switch (UnityEngine.Random.Range(0, 6))
                {
                    case 0:
                        wp.Name += "Скверны";
                        break;
                    case 1:
                        wp.Name += "Ужаса";
                        break;
                    case 2:
                        wp.Name += "Тьмы";
                        break;
                    case 3:
                        wp.Name += "Безнадёги";
                        break;
                    case 4:
                        wp.Name += "Безумия";
                        break;
                    case 5:
                        wp.Name += "Отчаяния";
                        break;
                }
                break;
        }
        return wp;
    }
    public Weapon ()
    {
    }

    public Weapon(string name, int MinD, int MaxD, int Type, int element, bool Double, Skill Skill, int cost, int rare, int[] features, int[] featureRare, string sprite)//Оружие
    {        
        this.cost = cost;
        this.rare = rare;
        int i = 0;
        foreach(int id in features)
        {
            FeaturesWeapon.Add(new Feature(id, featureRare[i]));
            i++;
        }

        Name = name;
        type = Type;
        MIN_Damage = MinD;
        MAX_Damage = MaxD;
        Element=element;
        DoubleWeapon = Double;
       if(Skill!=null) skill = Skill;
        this.sprite = sprite;

        switch (Element)
        {
            case 0:
                ElementName = "Без элемента";
                break;
            case 1:
                ElementName = "Огонь";
                break;
            case 2:
                ElementName = "Лёд";
                break;
            case 3:
                ElementName = "Яд";
                break;
            case 4:
                ElementName = "Электричество";
                break;
            case 5:
                ElementName = "Святость";
                break;
            case 6:
                ElementName = "Скверна";
                break;
        }
        switch (type)
        {
            case 0:
                typeName = "Одноручное оружие";
                break;
            case 1:
                typeName = "Двуручное оружие";
                break;
            case 2:
                typeName = "Книга";
                break;
            case 3:
                typeName = "Шлем";
                break;
            case 4:
                typeName = "Доспех";
                break;
            case 5:
                typeName = "Штаны";
                break;
            case 6:
                typeName = "Перчатки";
                break;
            case 7:
                typeName = "Пояс";
                break;
            case 8:
                typeName = "Сапоги";
                break;
            case 9:
                typeName = "Украшение";
                break;
        }
    }


    public Weapon(string name, int Type, int element, Skill Skill, int cost, int rare, int[] features, int[] featureRare, string sprite)//Украшение(книга) со скиллом
    {
        this.cost = cost;
        this.rare = rare;
        int i = 0;
        foreach (int id in features)
        {
            FeaturesWeapon.Add(new Feature(id, featureRare[i]));
            i++;
        }

        Name = name;
        type = Type;
        Element = element;
       if(Skill!=null) skill = Skill;
        this.sprite = sprite;

        switch (Element)
        {
            case 0:
                ElementName = "Без элемента";
                break;
            case 1:
                ElementName = "Огонь";
                break;
            case 2:
                ElementName = "Лёд";
                break;
            case 3:
                ElementName = "Яд";
                break;
            case 4:
                ElementName = "Электричество";
                break;
            case 5:
                ElementName = "Святость";
                break;
            case 6:
                ElementName = "Скверна";
                break;
        }
        switch (type)
        {
            case 0:
                typeName = "Одноручное оружие";
                break;
            case 1:
                typeName = "Двуручное оружие";
                break;
            case 2:
                typeName = "Книга";
                break;
            case 3:
                typeName = "Шлем";
                break;
            case 4:
                typeName = "Доспех";
                break;
            case 5:
                typeName = "Штаны";
                break;
            case 6:
                typeName = "Перчатки";
                break;
            case 7:
                typeName = "Пояс";
                break;
            case 8:
                typeName = "Сапоги";
                break;
            case 9:
                typeName = "Украшение";
                break;
        }
    }
}
