using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroy : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Item fruit)) {
            Debug.Log("hello!");
            if(LevelManager.difficultyMode == 3){
                PlayerController._CurrentLife -= 1;
            }
            Destroy(collision.gameObject);
        }
    }

}
