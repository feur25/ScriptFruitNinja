using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WidgetUpdate : MonoBehaviour
{
    public TMP_Text textScoreBoard;
    public TMP_Text textSpellActivated;
    public Image[] image;


    public void UpdatedScore(int score)
    {
        string _scoreText = score.ToString();
        textScoreBoard.SetText(_scoreText);
         
    }
    public void UpdatedSpell(string spell){
        textSpellActivated.SetText(spell);
    }

    public void UpdatedCurrentLife(int CurrentLife){
        int counter = 2;
        if(CurrentLife < 3){
            while(counter + 1 != CurrentLife){
               image[counter].color = Color.red; 
               counter--;
            }
        }
    }
}
