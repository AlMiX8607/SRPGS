using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Questions
{
    public int ID;
    public int Object; //1-Math 2-Russian 3-Физика 4- Английский 5-Информатика 6-Общество 7-Химия 8-Биология
    public string TextQuestion; //Сам вопрос (2+2=?)
    public int ShriftSize=50;
    public List<string> Answers = new List<string>(); //Варианты ответа (4 штуки)
    public string RightAnswer; //Правильный ответ
    public bool OnImage;
    public string sprite;
    public Questions(int ID)
    {
        this.ID = ID;
        switch (ID)
        {
            case 1:
                Object = 8;
                OnImage = false;
                TextQuestion = "К какой ткани относится кровь?";
                Answers.Add("К нервной");
                Answers.Add("К сердечной");
                Answers.Add("К соединительной");
                Answers.Add("К поперечно-полосатой");
                RightAnswer = "К соединительной";
                RandomAnsw();
                break;
            case 2:
                Object = 8;
                OnImage = false;
                TextQuestion = "Из чего образовано серое вещество?";
                Answers.Add("Ретикулярная ткань");
                Answers.Add("Стволовые клетки");
                Answers.Add("Тела нейронов и дендриты");
                Answers.Add("Кровь");
                RightAnswer = "Тела нейронов и дендриты";
                RandomAnsw();
                break;
            case 3:
                Object = 8;
                OnImage = false;
                TextQuestion = "К какой ткани относится костная ткань?";
                Answers.Add("К жировой");
                Answers.Add("К нервной");
                Answers.Add("К однослойному эпителию");
                Answers.Add("К соединительной");
                RightAnswer = "К соединительной";
                RandomAnsw();
                break;
            case 4:
                Object = 8;
                OnImage = false;
                TextQuestion = "Какого вида нейронов НЕ существует?";
                Answers.Add("Стволовых");
                Answers.Add("Двигательных");
                Answers.Add("Вставочных");
                Answers.Add("Чувствительных");
                RightAnswer = "Стволовых";
                RandomAnsw();
                break;
            case 5:
                Object = 8;
                OnImage = false;
                TextQuestion = "Какая ткань образует железы?";
                Answers.Add("Сердечная");
                Answers.Add("Эпителиальная");
                Answers.Add("Хрящевая");
                Answers.Add("Ретикулярная");
                RightAnswer = "Эпителиальная";
                RandomAnsw();
                break;
            case 6:
                Object = 8;
                OnImage = false;
                TextQuestion = "Что относится к органам чувств?";
                Answers.Add("Эпифиз");
                Answers.Add("Глаз");
                Answers.Add("Желудок");
                Answers.Add("Зобная железа");
                RightAnswer = "Глаз";
                RandomAnsw();
                break;
            case 7:
                Object = 8;
                OnImage = false;
                TextQuestion = "В момент сокращения левого желудочка сердца …";
                Answers.Add("открывается двухстворчатый клапан");
                Answers.Add("закрываются полулунные клапаны");
                Answers.Add("закрывается двухстворчатый клапан");
                Answers.Add("положение двухстворчатого и полулунных клапанов не меняется");
                RightAnswer = "закрывается двухстворчатый клапан";
                RandomAnsw();
                break;
            case 8:
                Object = 8;
                OnImage = false;
                TextQuestion = "Если из крови удалить форменные элементы, то останется …";
                Answers.Add("сыворотка");
                Answers.Add("плазма");
                Answers.Add("лимфа");
                Answers.Add("физиологический раствор");
                RightAnswer = "плазма";
                RandomAnsw();
                break;
            case 9:
                Object = 8;
                OnImage = false;
                TextQuestion = "Что отсутствует в плазме крови?";
                Answers.Add("белки");
                Answers.Add("жиры");
                Answers.Add("углеводы");
                Answers.Add("нуклеиновые кислоты");
                RightAnswer = "нуклеиновые кислоты";
                RandomAnsw();
                break;
            case 10:
                Object = 1;
                OnImage = false;
                TextQuestion = "Какое из следующих выражений равно 25 * 5^n?";
                Answers.Add("5^(n + 2)");
                Answers.Add("5^(2n)");
                Answers.Add("125^n");
                Answers.Add("25^n");
                RightAnswer = "5^(n + 2)";
                RandomAnsw();
                break;
            case 11:
                Object = 1;
                OnImage = false;
                TextQuestion = "Укажите неравенство, которое не имеет решений.";
                Answers.Add("x²​ − 64 ≤ 0");
                Answers.Add("x²​ + 64 ≥ 0");
                Answers.Add("x² − 64 ≥ 0");
                Answers.Add("x² + 64 ≤ 0");
                RightAnswer = "x²​​ + 64 ≤ 0";
                RandomAnsw();
                break;
            case 12:
                Object = 1;
                OnImage = false;
                TextQuestion = "Какое из следующих утверждений верно?";
                Answers.Add("Через точку, не лежащую на данной прямой, можно провести прямую, перпендикулярную этой прямой.");
                Answers.Add("Если стороны одного четырёхугольника соответственно равны сторонам другого четырёхугольника, то такие четырёхугольники равны.");
                Answers.Add("Смежные углы равны");
                Answers.Add("Диагонали параллелограмма равны");
                RightAnswer = "Через точку, не лежащую на данной прямой, можно провести прямую, перпендикулярную этой прямой.";
                RandomAnsw();
                break;
            case 13:
                Object = 1;
                OnImage = false;
                TextQuestion = "Геометрическая прогрессия задана условием b₁ = −7, bₓ₊₁ = 3bₓ. Найдите сумму первых 5 её членов.";
                Answers.Add("847");
                Answers.Add("1029");
                Answers.Add("1047");
                Answers.Add("-847");
                RightAnswer = "-847";
                RandomAnsw();
                break;
            case 14:
                Object = 1;
                OnImage = false;
                TextQuestion = "Известно, что 0 < a < 1. Выберите наименьшее из чисел.";
                Answers.Add("a²");
                Answers.Add("a³");
                Answers.Add("-a");
                Answers.Add("1/a");
                RightAnswer = "-a";
                RandomAnsw();
                break;
            case 15:
                Object = 1;
                OnImage = false;
                TextQuestion = "Известно, что a - четное число. Какое из следующих чисел является нечётным.";
                Answers.Add("a²");
                Answers.Add("3a");
                Answers.Add("a + 3");
                Answers.Add("a(a + 1)");
                RightAnswer = "a + 3";
                RandomAnsw();
                break;
            case 16:
                Object = 1;
                OnImage = false;
                TextQuestion = "Решите неравенство 1,4x - 8 > 3x - 8.";
                Answers.Add("x < 0");
                Answers.Add("x > 0");
                Answers.Add("x > 10");
                Answers.Add("x < 10");
                RightAnswer = "x < 0";
                RandomAnsw();
                break;
            case 17:
                Object = 1;
                OnImage = false;
                TextQuestion = "Известно, что x1 и x2 - корни уравнения x² + 3x + n = 0. Чему равно значение x1 + x2.";
                Answers.Add("3");
                Answers.Add("-3");
                Answers.Add("n");
                Answers.Add("-n");
                RightAnswer = "-3";
                RandomAnsw();
                break;
            case 18:
                Object = 1;
                OnImage = false;
                TextQuestion = "Значение какого из выражений является числом рациональным?";
                Answers.Add("(√6 - 3)(√6 + 3)");
                Answers.Add("√3*√5");
                Answers.Add("(√6 - 3)²");
                Answers.Add("(√5)²/√10");
                RightAnswer = "(√6 - 3)(√6 + 3)";
                RandomAnsw();
                break;
            case 19:
                Object = 1;
                OnImage = false;
                TextQuestion = "Последовательность задана формулой cₓ = x² - 1. Какое из указанных чисел является членом этой последовательности?";
                Answers.Add("1");
                Answers.Add("3");
                Answers.Add("2");
                Answers.Add("4");
                RightAnswer = "3";
                RandomAnsw();
                break;
            case 20:
                Object = 2;
                OnImage = false;
                TextQuestion = "Укажите ту пару слов, где в обоих словах на месте пропуска пишется буква и";
                Answers.Add("лаур..ат, ком..тет");
                Answers.Add("арт..ллерия, об..лиск");
                Answers.Add("пр..вилегия, р..золюция");
                Answers.Add("арх..тектура, д..плом");
                RightAnswer = "арх..тектура, д..плом";
                RandomAnsw();
                break;
            case 21:
                Object = 2;
                OnImage = false;
                TextQuestion = "Укажите ту пару слов, где в обоих словах на месте пропуска пишется одна буква";
                Answers.Add("пье..а, иску..ный");
                Answers.Add("а..естат, кава..ерия");
                Answers.Add("конгре.., диску..ия");
                Answers.Add("бе..етристика, инте..ект");
                RightAnswer = "пье..а, иску..ный";
                RandomAnsw();
                break;
            case 22:
                Object = 2;
                OnImage = false;
                TextQuestion = "Укажите ту пару слов, где в обоих словах верно выделена буква, обозначающая ударный гласный звук";
                Answers.Add("красивЕе, повторИт");
                Answers.Add("срЕдства, облегчИть");
                Answers.Add("инАче, собрАла");
                Answers.Add("щАвель, включИм");
                RightAnswer = "срЕдства, облегчИть";
                RandomAnsw();
                break;
            case 23:
                Object = 2;
                OnImage = false;
                TextQuestion = "Какая группа слов является словосочетанием?";
                Answers.Add("довольно жарко");
                Answers.Add("машина нагружена");
                Answers.Add("через сутки");
                Answers.Add("кресло-качалка");
                RightAnswer = "довольно жарко";
                RandomAnsw();
                break;
            case 24:
                Object = 2;
                OnImage = false;
                TextQuestion = "Укажите ту пару слов, где в обоих словах на месте пропуска пишется буква Е";
                Answers.Add("св..детельство, пр.зидиум");
                Answers.Add("д..алог, ст..пендия");
                Answers.Add("ч..столюбивый, эп..лог");
                Answers.Add("ман..врировать, ид..ал");
                RightAnswer = "ман..врировать, ид..ал";
                RandomAnsw();
                break;
            case 25:
                Object = 2;
                OnImage = false;
                TextQuestion = "Укажите предложение с составным именным сказуемым";
                Answers.Add("Ты бы поговорил со мной.");
                Answers.Add("Всё стало вокруг голубым и зелёным");
                Answers.Add("Прошло несколько месяцев");
                Answers.Add("В клетке соловей перестал петь");
                RightAnswer = "Всё стало вокруг голубым и зелёным";
                RandomAnsw();
                break;
            case 26:
                Object = 2;
                OnImage = false;
                TextQuestion = "Какое предложение является неопределённо-личным?";
                Answers.Add("При сильном ветре выходить в море опасно.");
                Answers.Add("Идёшь, на меня похожий, глаза устремляя вниз.");
                Answers.Add("О любви в словах не говорят.");
                Answers.Add("Сад Капулетти.");
                RightAnswer = "О любви в словах не говорят.";
                RandomAnsw();
                break;
            case 27:
                Object = 2;
                OnImage = false;
                TextQuestion = "Укажите грамматически правильное продолжение предложения. Проводя реформы,";
                Answers.Add("им упорно сопротивлялись бояре.");
                Answers.Add("перестраивалась вся жизнь России.");
                Answers.Add("Пётр Первый опирался на опыт европейских стран.");
                Answers.Add("их нелегко было принять.");
                RightAnswer = "Пётр Первый опирался на опыт европейских стран.";
                RandomAnsw();
                break;
            case 28:
                Object = 2;
                OnImage = false;
                TextQuestion = "Укажите грамматически правильное продолжение предложения. Подняв занавеску,";
                Answers.Add("я открыл окно.");
                Answers.Add("она оказалась тяжёлой.");
                Answers.Add("солнце заглянуло в окно.");
                Answers.Add("в саду уже было светло.");
                RightAnswer = "я открыл окно.";
                RandomAnsw();
                break;
            case 29:
                Object = 2;
                OnImage = false;
                TextQuestion = "Укажите словосочетание.";
                Answers.Add("в течение урока");
                Answers.Add("я удаляюсь");
                Answers.Add("пошли вперёд");
                Answers.Add("согласно приказу");
                RightAnswer = "пошли вперёд";
                RandomAnsw();
                break;
            case 30:
                Object = 3;
                OnImage = false;
                TextQuestion = "Тело объёмом 20 см3 состоит из вещества плотностью 7,3 г/см3. Какова масса тела?";
                Answers.Add("2,74 кг");
                Answers.Add("146 г");
                Answers.Add("2,74 г");
                Answers.Add("0,146 г");
                RightAnswer = "146 г";
                RandomAnsw();
                break;
            case 31:
                Object = 3;
                OnImage = false;
                TextQuestion = "Тело сохраняет свои объём и форму. В каком агрегативном состоянии находится вещество, из которого состоит тело?";
                Answers.Add("может находиться в любом состоянии");
                Answers.Add("в твёрдом");
                Answers.Add("в газообразном");
                Answers.Add("в жидком");
                RightAnswer = "в твёрдом";
                RandomAnsw();
                break;
            case 32:
                Object = 3;
                OnImage = false;
                TextQuestion = "Что из перечисленного является физической величиной?";
                Answers.Add("серебро");
                Answers.Add("сила");
                Answers.Add("плавление");
                Answers.Add("секунда");
                RightAnswer = "сила";
                RandomAnsw();
                break;
            case 33:
                Object = 3;
                OnImage = false;
                TextQuestion = "Что из перечисленного относится к физическим явлениям?";
                Answers.Add("золото");
                Answers.Add("километр");
                Answers.Add("плавление");
                Answers.Add("молекула");
                RightAnswer = "плавление";
                RandomAnsw();
                break;
            case 34:
                Object = 3;
                OnImage = false;
                TextQuestion = "Количество теплоты - это...";
                Answers.Add("изменение внутренней энергии при излучении.");
                Answers.Add("энергия, которую тело получает или отдает при теплопередаче.");
                Answers.Add("работа, которая совершается при нагревании тела.");
                Answers.Add("энергия, получаемая телом при нагревании.");
                RightAnswer = "энергия, которую тело получает или отдает при теплопередаче.";
                RandomAnsw();
                break;
            case 35:
                Object = 3;
                OnImage = false;
                TextQuestion = "Вектор, соединяющий начальное положение тела с его последующим положением, называется";
                Answers.Add("путь");
                Answers.Add("перемещение");
                Answers.Add("траектория");
                Answers.Add("расстояние");
                RightAnswer = "перемещение";
                RandomAnsw();
                break;
            case 36:
                Object = 3;
                OnImage = false;
                TextQuestion = "Импульсом тела называется векторная физическая величина, равная произведению";
                Answers.Add("массы тела на его ускорение");
                Answers.Add("массы тела на его скорость");
                Answers.Add("массы тела на квадрат его скорости");
                Answers.Add("времени на ускорение");
                RightAnswer = "массы тела на его скорость";
                RandomAnsw();
                break;
            case 37:
                Object = 3;
                OnImage = false;
                TextQuestion = "Магнитное поле характеризуется векторной физической величиной, которая обозначается символом В и называется";
                Answers.Add("магнитной индуктивностью");
                Answers.Add("магнитной индукцией");
                Answers.Add("электромагнитной индукцией");
                Answers.Add("самоиндукцией");
                RightAnswer = "магнитной индукцией";
                RandomAnsw();
                break;
            case 38:
                Object = 3;
                OnImage = false;
                TextQuestion = "В одном кубическом метре содержится";
                Answers.Add("1000000 см³");
                Answers.Add("1000 см³");
                Answers.Add("100 см³");
                Answers.Add("10 дм³");
                RightAnswer = "1000000 см³";
                RandomAnsw();
                break;
            case 39:
                Object = 3;
                OnImage = false;
                TextQuestion = "На рычаг действует сила 4 Н. Чему равен момент этой силы, если плечо силы 0,05 м";
                Answers.Add("0,8 Н*м");
                Answers.Add("1,25 Н*м");
                Answers.Add("0,2 Н*м");
                Answers.Add("20 Н*м");
                RightAnswer = "0,2 Н*м";
                RandomAnsw();
                break;
            case 40:
                Object = 4;
                OnImage = false;
                TextQuestion = "Заполните пропуск. … you afraid of spiders? – Of course, no!";
                Answers.Add("Am");
                Answers.Add("Is");
                Answers.Add("Are");
                Answers.Add("Be");
                RightAnswer = "Are";
                RandomAnsw();
                break;
            case 41:
                Object = 4;
                OnImage = false;
                TextQuestion = "Заполните пропуск. I … French and German.";
                Answers.Add("am speaking");
                Answers.Add("spoke");
                Answers.Add("speak");
                Answers.Add("was speaking");
                RightAnswer = "speak";
                RandomAnsw();
                break;
            case 42:
                Object = 4;
                OnImage = false;
                TextQuestion = "Заполните пропуск. Call James! – He’s busy now. He … the car with his brother.";
                Answers.Add("is repairing");
                Answers.Add("repairs");
                Answers.Add("had repairing");
                Answers.Add("was repairing");
                RightAnswer = "is repairing ";
                RandomAnsw();
                break;
            case 43:
                Object = 4;
                OnImage = false;
                TextQuestion = "Заполните пропуск. It … sunny tomorrow. Let’s go hiking!";
                Answers.Add("is");
                Answers.Add("will be");
                Answers.Add("was");
                Answers.Add("are");
                RightAnswer = "will be";
                RandomAnsw();
                break;
            case 44:
                Object = 4;
                OnImage = false;
                TextQuestion = "Заполните пропуск. The situation was bad but it … worse.";
                Answers.Add("should be");
                Answers.Add("could have been");
                Answers.Add("would have been");
                Answers.Add("could");
                RightAnswer = "could have been";
                RandomAnsw();
                break;
            case 45:
                Object = 4;
                OnImage = false;
                TextQuestion = "Заполните пропуск. I recommend you to apologize. You … apologize.";
                Answers.Add("shall");
                Answers.Add("must");
                Answers.Add("would");
                Answers.Add("should");
                RightAnswer = "should";
                RandomAnsw();
                break;
            case 46:
                Object = 4;
                OnImage = false;
                TextQuestion = "Заполните пропуск. Where is Nick? He … be in his office.";
                Answers.Add("would");
                Answers.Add("ought to");
                Answers.Add("should");
                Answers.Add("might");
                RightAnswer = "might";
                RandomAnsw();
                break;
            case 47:
                Object = 4;
                OnImage = false;
                TextQuestion = "Заполните пропуск. This price is wrong. It … be $3.50, not $4.00.";
                Answers.Add("could");
                Answers.Add("should");
                Answers.Add("must");
                Answers.Add("would");
                RightAnswer = "should";
                RandomAnsw();
                break;
            case 48:
                Object = 4;
                OnImage = false;
                TextQuestion = "Заполните пропуск. A … is a travel made by water - sea or ocean.";
                Answers.Add("tour");
                Answers.Add("voyage");
                Answers.Add("travel");
                Answers.Add("journey");
                RightAnswer = "voyage";
                RandomAnsw();
                break;
            case 49:
                Object = 4;
                OnImage = false;
                TextQuestion = "Заполните пропуск. … was slow and sometimes very dangerous in old times.";
                Answers.Add("Voyage");
                Answers.Add("Journey");
                Answers.Add("Travel");
                Answers.Add("Trip");
                RightAnswer = "Travel";
                RandomAnsw();
                break;
            case 50:
                Object = 5;
                OnImage = false;
                TextQuestion = "Для какого из указанных значений числа Х истинно выражение: (Х > 2) И НЕ(Х > 3)?";
                Answers.Add("1");
                Answers.Add("4");
                Answers.Add("2");
                Answers.Add("3");
                RightAnswer = "3";
                RandomAnsw();
                break;
            case 51:
                Object = 5;
                OnImage = false;
                TextQuestion = "Переведите число 1011101 из двоичной системы счисления в десятичную систему счисления.";
                Answers.Add("85");
                Answers.Add("93");
                Answers.Add("90");
                Answers.Add("97");
                RightAnswer = "93";
                RandomAnsw();
                break;
            case 52:
                Object = 5;
                OnImage = false;
                TextQuestion = "Для какого из приведенных значений числа Х ЛОЖНО высказывание: НЕ(Х < 7) ИЛИ(Х < 6) ? ";
                Answers.Add("4");
                Answers.Add("5");
                Answers.Add("6");
                Answers.Add("7");
                RightAnswer = "6";
                RandomAnsw();
                break;
            case 53:
                Object = 5;
                OnImage = false;
                TextQuestion = "Ученик должен сидеть на расстояние от компьютера минимум …";
                Answers.Add("100-90 см");
                Answers.Add("60-50 см");
                Answers.Add("30-40 см");
                Answers.Add("70-80 см");
                RightAnswer = "60-50 см";
                RandomAnsw();
                break;
            case 54:
                Object = 5;
                OnImage = false;
                TextQuestion = "Что такое 1 байт";
                Answers.Add("1024 Кб");
                Answers.Add("8 бит");
                Answers.Add("10 Мб");
                Answers.Add("4 бит");
                RightAnswer = "8 бит";
                RandomAnsw();
                break;
            case 55:
                Object = 5;
                OnImage = false;
                TextQuestion = "Какое количество информации несёт двоичный код 11100011";
                Answers.Add("2 бита");
                Answers.Add("8 бит");
                Answers.Add("5 бит");
                Answers.Add("16 бит");
                RightAnswer = "8 бит";
                RandomAnsw();
                break;
            case 56:
                Object = 5;
                OnImage = false;
                TextQuestion = "В доме 16 этажей и 4 подъезда. Сколько информации несёт сообщение о том, что Илья живёт во 2 подъезде на третьем этаже.";
                Answers.Add("2 бита");
                Answers.Add("6 бит");
                Answers.Add("16 бит");
                Answers.Add("64 бита");
                RightAnswer = "6 бит";
                RandomAnsw();
                break;
            case 57:
                Object = 5;
                OnImage = false;
                TextQuestion = "Какова палитра цветов в системе цветопередачи CMYK";
                Answers.Add("голубой, пурпурный, жёлтый, чёрный");
                Answers.Add("красный, зелёный, синий, чёрный");
                Answers.Add("жёлтый, красный, зелёный, чёрный");
                Answers.Add("пурпурный, зелёный, красный, чёрный");
                RightAnswer = "голубой, пурпурный, жёлтый, чёрный";
                RandomAnsw();
                break;
            case 58:
                Object = 5;
                OnImage = false;
                TextQuestion = "Какое устройство НЕ находится в системном блоке?";
                Answers.Add("материнская плата");
                Answers.Add("дисковод");
                Answers.Add("жесткий диск");
                Answers.Add("клавиатура");
                RightAnswer = "клавиатура";
                RandomAnsw();
                break;
            case 59:
                Object = 5;
                OnImage = false;
                TextQuestion = "Сколько CD объёмом 600 Мбайт потребуется для размещения информации, полностью занимающей жёсткий диск ёмкостью 40 Гбайт?";
                Answers.Add("15");
                Answers.Add("67");
                Answers.Add("68");
                Answers.Add("69");
                RightAnswer = "69";
                RandomAnsw();
                break;
            case 60:
                Object = 6;
                OnImage = false;
                TextQuestion = "Что понимают под обществом?";
                Answers.Add("территорию, имеющую определённые границы");
                Answers.Add("социальную организацию страны");
                Answers.Add("объединение любителей старинных книг");
                Answers.Add("политическую организацию государства");
                RightAnswer = "социальную организацию страны";
                RandomAnsw();
                break;
            case 61:
                Object = 6;
                OnImage = false;
                TextQuestion = "Какие проблемы называются глобальными?";
                Answers.Add("сопровождаемые коренным изменением ценностей жизни");
                Answers.Add("связанные с проблемой выбора жизненного пути");
                Answers.Add("затрагивающие жизненно важные интересы человечества");
                Answers.Add("характеризующие нравственное совершенствование общества.");
                RightAnswer = "затрагивающие жизненно важные интересы человечества";
                RandomAnsw();
                break;
            case 62:
                Object = 6;
                OnImage = false;
                TextQuestion = "Назовите признак, который характеризует человека как личность?";
                Answers.Add("активная жизненная позиция");
                Answers.Add("физическое и психическое здоровье");
                Answers.Add("свойства темперамента");
                Answers.Add("особенности внешности");
                RightAnswer = "активная жизненная позиция";
                RandomAnsw();
                break;
            case 63:
                Object = 6;
                OnImage = false;
                TextQuestion = "Что отличает семью как малую группу?";
                Answers.Add("профессиональный рост");
                Answers.Add("общность быта");
                Answers.Add("выполнение общественных функций");
                Answers.Add("высокая политическая активность");
                RightAnswer = "общность быта";
                RandomAnsw();
                break;
            case 64:
                Object = 6;
                OnImage = false;
                TextQuestion = "Можно ли в России заключить брак раньше 18-ти лет?";
                Answers.Add("нет");
                Answers.Add("да, если будущая супруга беременна или родила");
                Answers.Add("да");
                Answers.Add("если есть разрешение родителей");
                RightAnswer = "да, если будущая супруга беременна или родила";
                RandomAnsw();
                break;
            case 65:
                Object = 6;
                OnImage = false;
                TextQuestion = "С какого момента человеку принадлежат его права?";
                Answers.Add("с совершеннолетия");
                Answers.Add("с рождения");
                Answers.Add("с получения гражданства");
                Answers.Add("после окончания вуза");
                RightAnswer = "с рождения";
                RandomAnsw();
                break;
            case 66:
                Object = 6;
                OnImage = false;
                TextQuestion = "К какой сфере общественной жизни относится работа органов здравоохранения?";
                Answers.Add("экономической");
                Answers.Add("политической");
                Answers.Add("социальной");
                Answers.Add("духовной");
                RightAnswer = "социальной";
                RandomAnsw();
                break;
            case 67:
                Object = 6;
                OnImage = false;
                TextQuestion = "Что относится к объектам нематериальной культуры?";
                Answers.Add("язык");
                Answers.Add("орудия труда");
                Answers.Add("кинофильм");
                Answers.Add("жилые дома");
                RightAnswer = "язык";
                RandomAnsw();
                break;
            case 68:
                Object = 6;
                OnImage = false;
                TextQuestion = "К характеристике уровня жизни не относит(-ят-)ся";
                Answers.Add("условия проживания");
                Answers.Add("уровень образования");
                Answers.Add("социальное обеспечение");
                Answers.Add("вероисповедание");
                RightAnswer = "вероисповедание";
                RandomAnsw();
                break;
            case 69:
                Object = 6;
                OnImage = false;
                TextQuestion = "Общность, культурные традиции которой объединяют членов данной группы и отличают ее от других групп:";
                Answers.Add("класс");
                Answers.Add("этническая группа");
                Answers.Add("профессиональная группа");
                Answers.Add("сословие");
                RightAnswer = "этническая группа";
                RandomAnsw();
                break;
            case 70:
                Object = 7;
                OnImage = false;
                TextQuestion = "Чему равен молярный объем газа? (при н. у.)";
                Answers.Add("42.4");
                Answers.Add("24.2");
                Answers.Add("44.2");
                Answers.Add("22.4");
                RightAnswer = "22.4";
                RandomAnsw();
                break;
            case 71:
                Object = 7;
                OnImage = false;
                TextQuestion = "У азота 7 электронов. Выберите правильное кол-во его электронных слоев.";
                Answers.Add("3");
                Answers.Add("2");
                Answers.Add("1");
                Answers.Add("4");
                RightAnswer = "2";
                RandomAnsw();
                break;
            case 72:
                Object = 7;
                OnImage = false;
                TextQuestion = "Выберите степень окисления хрома у молекулы H₂CrO₄";
                Answers.Add("5");
                Answers.Add("6");
                Answers.Add("3");
                Answers.Add("4");
                RightAnswer = "6";
                RandomAnsw();
                break;
            case 73:
                Object = 7;
                OnImage = false;
                TextQuestion = "Выберите правильный химический знак свинца";
                Answers.Add("Pb");
                Answers.Add("Fe");
                Answers.Add("F");
                Answers.Add("Cu");
                RightAnswer = "Pb";
                RandomAnsw();
                break;
            case 74:
                Object = 7;
                OnImage = false;
                TextQuestion = "Выберите среди атомов галоген";
                Answers.Add("H");
                Answers.Add("F");
                Answers.Add("Na");
                Answers.Add("Cu");
                RightAnswer = "F";
                RandomAnsw();
                break;
            case 75:
                Object = 7;
                OnImage = false;
                TextQuestion = "Чему равно число авогадро?";
                Answers.Add("6 * 10²³");
                Answers.Add("6,02 * 10²³");
                Answers.Add("2,06 * 10²³");
                Answers.Add("2 * 10²³");
                RightAnswer = "6,02 * 10²³";
                RandomAnsw();
                break;
            case 76:
                Object = 7;
                OnImage = false;
                TextQuestion = "Что такое простое вещество?";
                Answers.Add("Вещество , образованное химическими элементами");
                Answers.Add("Вещество, образованное атомами химических элементов");
                Answers.Add("Вещество, образованное атомами одного химического элемента");
                Answers.Add("Вещество, образованное атомами разных химических элементов.");
                RightAnswer = "Вещество, образованное атомами одного химического элемента";
                RandomAnsw();
                break;
            case 77:
                Object = 7;
                OnImage = false;
                TextQuestion = "Укажите сложное вещество";
                Answers.Add("Фосфор");
                Answers.Add("Крахмал");
                Answers.Add("Сера");
                Answers.Add("Медь.");
                RightAnswer = "Крахмал";
                RandomAnsw();
                break;
            case 78:
                Object = 7;
                OnImage = false;
                TextQuestion = "К сложным веществам относится каждое из двух веществ, формулы которых:";
                Answers.Add("O₂ и O₃");
                Answers.Add("NH₃ и H₂SO₄");
                Answers.Add("CuO и N₂");
                Answers.Add("Mg и NaOH");
                RightAnswer = "NH₃ и H₂SO₄";
                RandomAnsw();
                break;
            case 79:
                Object = 7;
                OnImage = false;
                TextQuestion = "Относительная молекулярная масса метана CH₄ равна:";
                Answers.Add("7");
                Answers.Add("13");
                Answers.Add("16");
                Answers.Add("10");
                RightAnswer = "16";
                RandomAnsw();
                break;
            case 80:
                Object = 8;
                OnImage = false;
                TextQuestion = "Какая ткань обладает свойствами сократимости и возбудимости?";
                Answers.Add("Мышечная");
                Answers.Add("Эпителиальная");
                Answers.Add("Меристема");
                Answers.Add("Нейроглия");
                RightAnswer = "Мышечная";
                RandomAnsw();
                break;
        }
    }
    public void RandomAnsw() //Рандомное перемешивание вариантов ответа
    {
        for (int i = 0; i < 200; i++)
        {
            int k1 = Random.Range(0,4);
            int k2;
            do
            {
                k2 = Random.Range(0,4);
            }
            while (k1 == k2);

            string temp;
            temp = Answers[k1];
            Answers[k1] = Answers[k2];
            Answers[k2] = temp;
        }
    }
}
