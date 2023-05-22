using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Une réfèrence au fichier de widget pour éviter de le call a chaque update mais plutot a chaque mise a jour du score
    public WidgetUpdate _widget;
    
    //Variable Modulable dans le jeu
    public static int _CurrentLife = 3;
    public static int beforeLife = 3;

    GlobalScore scoreUpdate = new GlobalScore();

    public static int CurrentLife
    {
        get { return _CurrentLife; }
        set { _CurrentLife = value; }
    }

    private static int _CurrentPoint = 0;

    public static bool YouCanAddPoint = false;

    public static int CurrentPoint
    {
        get { return _CurrentPoint; }
        set { _CurrentPoint = value; }
    }
    
    private int _score;

    LevelManager levelSwitch = new LevelManager();

    public int ScorePoint(){
        return _CurrentPoint;
    }

    private void ResetAllEffect(){
        SpecialFruitScript.slowTime = false;
        SpecialFruitScript.doublePoints = false;
        SpecialFruitScript.halfPoints = false;
    }
    private void OnDisable() {
        if (_CurrentLife < 1) {
            Debug.Log("Game Over");
            Time.timeScale = 1f;
            ResetAllEffect();
            QuitGame();
        }
    }

    private void SwitchScoreBackup(){
        if(!LevelManager.chooseMode){
            switch (LevelManager.difficultyMode)
            {
                case 1 :
                    GlobalScore.classicModeEasyScore = GlobalScore.classicModeEasyScore < _CurrentPoint ? _CurrentPoint : GlobalScore.classicModeEasyScore;
                    break;
                case 2 :
                    GlobalScore.classicModeNormalScore = GlobalScore.classicModeNormalScore < _CurrentPoint ? _CurrentPoint : GlobalScore.classicModeNormalScore;
                    break;
                case 3 :
                    GlobalScore.classicModeHardScore = GlobalScore.classicModeHardScore < _CurrentPoint ? _CurrentPoint : GlobalScore.classicModeHardScore;
                    break;
                default:
                    Debug.Log("ah un bug a spawn");
                    break;
            }
        }else{
            switch (LevelManager.difficultyMode)
            {
                case 1 :
                    GlobalScore.weaponModeEasyScore = GlobalScore.weaponModeEasyScore < _CurrentPoint ? _CurrentPoint : GlobalScore.weaponModeEasyScore;
                    break;
                case 2 :
                    GlobalScore.weaponModeNormalScore = GlobalScore.weaponModeNormalScore < _CurrentPoint ? _CurrentPoint : GlobalScore.weaponModeNormalScore;
                    break;
                case 3 :
                    GlobalScore.weaponModeHardScore = GlobalScore.weaponModeHardScore < _CurrentPoint ? _CurrentPoint : GlobalScore.weaponModeHardScore;
                    break;
                default:
                    Debug.Log("ah un bug a spawn");
                    break;
            }
        }
    }


    private void ResetAllVariable(){
        _CurrentLife = 3;
        _CurrentPoint = 0;
        YouCanAddPoint = false;
        beforeLife = 3;
    }
    
    public void QuitGame(){
        SwitchScoreBackup();
        ResetAllVariable();
        SceneManager.LoadScene("Hub");

        // #if UNITY_EDITOR
        //     UnityEditor.EditorApplication.isPlaying = false;
        // #endif
        // Application.Quit();
    }

    void Update()
    {
        if(_CurrentLife < beforeLife){
            beforeLife = _CurrentLife;
            _widget?.UpdatedCurrentLife(_CurrentLife);
        }
        if(YouCanAddPoint){
            _widget?.UpdatedScore(_CurrentPoint);
            YouCanAddPoint = false;
        }
            
    }
}