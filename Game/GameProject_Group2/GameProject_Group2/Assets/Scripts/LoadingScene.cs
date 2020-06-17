using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private Transform slider;
    [SerializeField] private GameObject text;
    [SerializeField] private float maxLocalScale = 2.452306f;
    [SerializeField] private float timeToAdvance, timePassed;
    [SerializeField] int sceneToLoad = 2;

    private void Start()
    {
        text.SetActive(false);
        timePassed = Time.time + timeToAdvance;
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        yield return null;
        AsyncOperation level = SceneManager.LoadSceneAsync(sceneToLoad);
        level.allowSceneActivation = false;
        
        while (!level.isDone || level.allowSceneActivation == false)
        {
            while (level.progress < 1)
            {
                slider.localScale = new Vector3(level.progress * maxLocalScale, slider.localScale.y, slider.localScale.z);
                yield return new WaitForEndOfFrame();
            }
            
            if (timePassed <= Time.time)
            {
                text.SetActive(true);
                if (Input.anyKey)
                {
                    level.allowSceneActivation = true;
                }
            } else
            {
                yield return null;
            }
        }
    }
}
