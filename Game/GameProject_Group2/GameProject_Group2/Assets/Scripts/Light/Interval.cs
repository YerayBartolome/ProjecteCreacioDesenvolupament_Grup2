using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interval : MonoBehaviour
{
    
    [SerializeField] float maxLight, minLight, speed;
    [SerializeField] Light currentLight;

    void Update()
    {
        currentLight.intensity = Mathf.Lerp(minLight, maxLight, Mathf.PingPong(Time.time, speed));
    }
}
