using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.3f;
    
    private Vector3 initialPositon;

    private void Start()
    {
        initialPositon = transform.position;  
    }
    public void Play()
    {
        StartCoroutine(Shake());
    }
    // Random.insideUnitCircle => Sets the position to be somewhere inside a circle
    //                            with radius 5 and the center at zero

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        
        while(elapsedTime<shakeDuration)
        {
            transform.position = initialPositon + (Vector3) Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();

        }
        transform.position = initialPositon;
    }

}
