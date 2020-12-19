using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour
{
    public void ChangeTarget()
    {
        int i = 0;
        foreach (CharacterInFight ch in StartGame.game.AllCharacters) {
            if (GetComponent<Image>().sprite.Equals(Resources.Load<Sprite>(ch.sprite))) { MainTeamChange.targetChange = i; break; }
            i++;
        }
    }
}
