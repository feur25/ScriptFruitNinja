using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
public GameObject Restart;
    public GameObject Volume;
    public GameObject Quitter;
    public GameObject ModifierVolume;
    public GameObject Retour;
    public AudioSource[] audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Restart.SetActive(true);
            Volume.SetActive(true);
            Quitter.SetActive(true);
            audioSource[LevelManager.difficultyMode-1].Pause();
        }


    }
    public void ReStart()
    {
        Time.timeScale = 1;
        Restart.SetActive(false);
        Volume.SetActive(false);
        Quitter.SetActive(false);
        audioSource[LevelManager.difficultyMode-1].Play();
    }
    public void GoodBye()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
    public void Son()
    {
        ModifierVolume.SetActive(true);
        Retour.SetActive(true);
        Restart.SetActive(false);
        Volume.SetActive(false);
        Quitter.SetActive(false);
    }

    public void RetourEnArrière()
    {
        ModifierVolume.SetActive(false);
        Retour.SetActive(false);
        Restart.SetActive(true);
        Volume.SetActive(true);
        Quitter.SetActive(true);
    }
}
