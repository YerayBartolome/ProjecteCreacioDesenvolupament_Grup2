using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool started_PreMenu = false;
    bool started_Menu = false;
    private float timeToShow;
    private float timeToFade;

    public float secondsUntilMenu = 6;
    public float secondsforfade = 2;
    public GameObject[] premenu;
    public GameObject[] menu;
    public GameObject logo;
    public GameObject fadeIn;

    private void Start()
    {
        timeToShow = secondsUntilMenu + Time.time;
        timeToFade = secondsforfade + Time.time;

        

    }
    private void Update()
    {
        float currentTime = Time.time;
        if (currentTime >= timeToFade) fadeIn.active = false;
        if (currentTime > timeToShow) started_PreMenu = true;
        
        if (started_PreMenu&&!started_Menu)
        {
            logo.active = true;
            foreach(GameObject obj in premenu){
                obj.active = true;
            }
            if (Input.anyKey) started_Menu = true;
        }
        if (started_Menu)
        {
            foreach (GameObject obj in premenu)
            {
                obj.active = false;
            }
            foreach (GameObject obj in menu)
            {
                obj.active = true;
            }
        }
        
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
