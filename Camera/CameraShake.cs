using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CameraShake : Item
{
    public Transform cameraTransform;
    private Vector3 originalPosition;
    private float shakeDuration = 1f;
    private float shakeMagnitude = 0.1f;
    private float dampingSpeed = 1.0f;
    


    private void Awake()
    {
        
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
        originalPosition = cameraTransform.localPosition;
    }

    private void Update(){
        if(shake){
             StartCoroutine(ShakeCoroutine());
        }   
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeMagnitude;
            cameraTransform.localPosition = originalPosition + shakeOffset;

            elapsed += Time.deltaTime * dampingSpeed;

            yield return null;
        }

        cameraTransform.localPosition = originalPosition;
        shake = false;
    }
}
