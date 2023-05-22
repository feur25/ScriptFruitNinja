using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class GlobalScore : MonoBehaviour
{

    public static int classicModeEasyScore = 0;
    public static int weaponModeEasyScore = 0;
    public static int classicModeNormalScore = 0;
    public static int weaponModeNormalScore = 0;
    public static int classicModeHardScore = 0;
    public static int weaponModeHardScore = 0;


    public TextMeshPro classicModeEasyScoreText;
    public TextMeshPro weaponModeEasyScoreText;
    public TextMeshPro classicModeNormalScoreText;
    public TextMeshPro weaponModeNormalScoreText;
    public TextMeshPro classicModeHardScoreText;
    public TextMeshPro weaponModeHardScoreText;

    string text;

    // Start is called before the first frame update
    void Start()
    {
        UpdatedWidget();
    }

    public void UpdatedWidget(){
        text = classicModeEasyScore > 0 ? classicModeEasyScore.ToString() : "Lock";
        classicModeEasyScoreText.SetText("Classic Easy Score : " + text);
        text = weaponModeEasyScore > 0 ? weaponModeEasyScore.ToString() : "Lock";
        weaponModeEasyScoreText.SetText("Weapon Easy Score : " + text);
        text = classicModeNormalScore > 0 ? classicModeNormalScore.ToString() : "Lock";
        classicModeNormalScoreText.SetText("Classic Normal Score : " + text);
        text = weaponModeNormalScore > 0 ? weaponModeNormalScore.ToString() : "Lock";
        weaponModeNormalScoreText.SetText("Weapon Normal Score : " + text);
        text = classicModeHardScore > 0 ? classicModeHardScore.ToString() : "Lock";
        classicModeHardScoreText.SetText("Classic Hard Score : " + text);
        text = weaponModeHardScore > 0 ? weaponModeHardScore.ToString() : "Lock";
        weaponModeHardScoreText.SetText("Weapon Hard Score : " + text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
