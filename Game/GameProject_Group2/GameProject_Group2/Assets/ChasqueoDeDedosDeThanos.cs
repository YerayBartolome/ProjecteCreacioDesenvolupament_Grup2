using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasqueoDeDedosDeThanos : MonoBehaviour
{
    public float  secondsbeforeEnd = 5;
    float timeToEnd;
    // Start is called before the first frame update
    void Start()
    {
        timeToEnd = Time.time+secondsbeforeEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timeToEnd){
            SceneManager.LoadScene("Main Menu");
        }

    }
}
