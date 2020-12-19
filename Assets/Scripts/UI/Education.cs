using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Education : MonoBehaviour
{
    void Start()
    {
        StartGame.game.CheckQuestions();
        transform.GetChild(0).GetChild(0).GetComponent<Toggle>().SetIsOnWithoutNotify(StartGame.game.MainHeroMath);
        transform.GetChild(0).GetChild(1).GetComponent<Toggle>().SetIsOnWithoutNotify(StartGame.game.MainHeroRussian);
        transform.GetChild(0).GetChild(2).GetComponent<Toggle>().SetIsOnWithoutNotify(StartGame.game.MainHeroPhysic);
        transform.GetChild(0).GetChild(3).GetComponent<Toggle>().SetIsOnWithoutNotify(StartGame.game.MainHeroEng);
        transform.GetChild(0).GetChild(4).GetComponent<Toggle>().SetIsOnWithoutNotify(StartGame.game.MainHeroInformatic);
        transform.GetChild(0).GetChild(5).GetComponent<Toggle>().SetIsOnWithoutNotify(StartGame.game.MainHeroSocial);
        transform.GetChild(0).GetChild(6).GetComponent<Toggle>().SetIsOnWithoutNotify(StartGame.game.MainHeroChemistry);
        transform.GetChild(0).GetChild(7).GetComponent<Toggle>().SetIsOnWithoutNotify(StartGame.game.MainHeroBiology);
    }
}
