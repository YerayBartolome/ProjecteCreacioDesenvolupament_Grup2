using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool started_PreMenu = false;
    bool started_Menu = false;
    bool deployed = false;
    private float timeToShow;
    private float timeToFade;

    public float secondsUntilMenu = 6;
    public float secondsforfade = 2;
    public GameObject[] premenu;
    public GameObject[] menu;
    public GameObject credits;
    public GameObject controls;
    public GameObject fadeIn;
    private bool shouldPlay = false;

    private void Start()
    {
        timeToShow = secondsUntilMenu + Time.time;
        timeToFade = secondsforfade + Time.time;

        //StartCoroutine(LoadAsyncOperation());

    }

    public bool ShouldPlay()
    {
        return shouldPlay;
    }

    /*
    IEnumerator LoadAsyncOperation()
    {
        yield return null;
        AsyncOperation level = SceneManager.LoadSceneAsync(1);
        level.allowSceneActivation = false;

        while (!level.isDone || !shouldPlay)
        {
            yield return null;
        }
        if (ShouldPlay())
        {
            level.allowSceneActivation = true;
        }
    }
    */

    private void Update()
    {
        if (!deployed)
        {
            float currentTime = Time.time;
            if (currentTime >= timeToFade) fadeIn.active = false;
            if (currentTime > timeToShow) started_PreMenu = true;

            if (started_PreMenu && !started_Menu)
            {
                foreach (GameObject obj in premenu)
                {
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
                deployed = true;
            }
        }
        
    }
    public void PlayGame()
    {
        shouldPlay = true;
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        foreach (GameObject obj in menu)
        {
            obj.SetActive(false);
        }
        credits.SetActive(true);
    }

    public void ShowControls()
    {
        foreach (GameObject obj in menu)
        {
            obj.SetActive(false);
        }
        controls.SetActive(true);
    }

    public void ShowMenu()
    {
        credits.SetActive(false);
        controls.SetActive(false);
        foreach (GameObject obj in menu)
        {
            obj.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
