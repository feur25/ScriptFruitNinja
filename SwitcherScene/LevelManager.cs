using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string SceneName;
    public string AnotherSceneName;

    public static bool chooseMode = false;
    public static int difficultyMode = 1;

    public void SelectedMode(){
        if(AnotherSceneName == "GunScene"){
            chooseMode = true;
        }else{
            chooseMode = false;
        }
        SelectedScene();
    }
    public void SelectedSpecialsScene(string name){
        SceneManager.LoadScene(name);
    }

    public void SelectedScene(){
        SceneManager.LoadScene(SceneName);
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("saloperie!");
        if(other.gameObject.tag == "Player")
            SelectedMode();
    }

    public void Hub(){
        SceneManager.LoadScene("Hub");
    }
}
