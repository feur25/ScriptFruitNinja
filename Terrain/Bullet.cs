using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;

    public float scale = 2.0f;

    public static bool modifyScale = false;

    public void ScaleIncreaseResolution()
    {
        Vector3  ball = bullet.transform.localScale;
        ball.x += 2f;
        ball.y += 2f;  
        ball.z += 2f;
        bullet.transform.localScale = ball;
        modifyScale = true;
    }

    public void ScaleDecreaseResolution(){
        Vector3  ball = bullet.transform.localScale;
        ball.x -= 2f;
        ball.y -= 2f;  
        ball.z -= 2f;
        bullet.transform.localScale = ball;
        modifyScale = false;
    }
}