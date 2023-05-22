using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGroundMusic : MonoBehaviour
{


    public AudioSource[] music;

    void Awake()
    {
        Debug.Log(LevelManager.difficultyMode);
        music[LevelManager.difficultyMode-1].loop = true;
        music[LevelManager.difficultyMode-1]?.Play();
    }
}
