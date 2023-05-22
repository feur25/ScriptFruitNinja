using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public string name;

    public int difficulty = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            LevelManager.difficultyMode = difficulty;
            if(LevelManager.chooseMode){
                if(PickUpController.WeaponChoice){
                    SceneManager.LoadScene("ShootGunScene");
                }else{
                    SceneManager.LoadScene(name);
                }
            }else{
                SceneManager.LoadScene(name);
            }
    }
}