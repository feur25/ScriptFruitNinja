using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialFruitScript : MonoBehaviour
{
    public static bool slowTime = false;
    public static bool doublePoints = false;
    public static bool halfPoints = false;
    public static bool weaponCheat = false;

    public static float slowMotionFactor = 0.2f;

    Bullet getBullet = new Bullet();
    ProjectileWeapon1 getWeapon = new ProjectileWeapon1();

    private void SelectedEffectMode(){
        int randomNum = Random.Range(1, 25);
        if(LevelManager.chooseMode){
            if(randomNum == 5){
                getBullet.ScaleIncreaseResolution();
            }
            if(randomNum == 21){
                weaponCheat = true;
                getWeapon.BestWeaponEffect();
            }
        }
        if(!LevelManager.chooseMode){
            if(randomNum == 12){
                slowTime = true;
                Time.timeScale = slowMotionFactor;
            }
        }
        if(randomNum == 7){
            doublePoints = true;
        }else if(randomNum == 9){
            halfPoints = true;
        }
    }


    public void OnSpecialFruitHit()
    {
        SelectedEffectMode();
    }
}
