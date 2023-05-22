using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    public float totalTime = 180f;
    private float currentTime;
    private TMP_Text timerText;


    PlayerController main = new PlayerController();

    private void Start()
    {
        timerText = GetComponent<TMP_Text>();
        currentTime = 0f;
        if(LevelManager.difficultyMode == 3){
            timerText.SetText("");
        }else{
            InvokeRepeating("AddTimer", 0f, 1f);
        }
    }
    private void SpawnRate(){
        if (Mathf.Approximately(currentTime % 8f, 0f) && SpawnManager.PourcentageSpawn < 87){
            SpawnManager.PourcentageSpawn *= 1.15f * LevelManager.difficultyMode;
        }
        if (Mathf.Approximately(currentTime % 8f, 0f) && SpawnManager.PourcentageSpawnBomb < 20) {
            SpawnManager.PourcentageSpawnBomb *= 1.15f * LevelManager.difficultyMode;
        }
        if (Mathf.Approximately(currentTime % 10f, 0f) && SpawnManager.PourcentageSpawnBomb > 1.15) {
            SpawnManager.maxTimeSpawn *= 0.95f * LevelManager.difficultyMode;
        }
    }

    private void Update(){
        SpawnRate();
        if(LevelManager.difficultyMode != 3){
            if (currentTime >= totalTime){
                EndTimer();
            }else{
                float timeRemaining = totalTime - currentTime;
                timerText.SetText(FormatTime(timeRemaining));
            }
        }

    }

    private void AddTimer(){
        currentTime++;
    }

    public void EndTimer()
    {
        timerText.text = "Temps écoulé !";
        main.QuitGame();
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}