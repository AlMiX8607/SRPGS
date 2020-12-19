using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBtn : MonoBehaviour
{
    public void CLICK() //Клик по варианту ответа
    {
        Text t = transform.GetChild(0).GetComponent<Text>();
        if (t.text.Equals(Fight.q.RightAnswer)) { print("Ваш ответ: " + t.text + " Верный ответ: " + Fight.q.RightAnswer); print("\nВерно"); Fight.ActiveCharacter.ch.RightAnswer = true; }
        else { print("Ваш ответ: " + t.text + " Верный ответ: " + Fight.q.RightAnswer); print("Неверно");  Fight.ActiveCharacter.ch.RightAnswer = false; }
        Fight.QuestionFlag = true;
    }
}
