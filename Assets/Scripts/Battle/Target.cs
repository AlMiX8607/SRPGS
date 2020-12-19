using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour  //Выбор цели атаки по клику
{
    public int target;
    public void CLick()
    {
     if(Fight.isPlayerTurn && !Fight.isChangeTurn)   Fight.target = target;
    }
    }
