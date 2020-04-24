using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthLights : MonoBehaviour
{
    private HealthSystem health;
    public GameObject sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7;
    private AudioSource audio;

    void Awake()
    {
        health = GetComponent<HealthSystem>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int currentHealth = health.getHealth();
        Debug.Log(currentHealth);
        if (currentHealth >= 70)
        {
            sphere1.SetActive(true);
            sphere2.SetActive(true);
            sphere3.SetActive(true);
            sphere4.SetActive(true);
            sphere5.SetActive(true);
            sphere6.SetActive(true);
            sphere7.SetActive(false);
        }
        else if (currentHealth >= 60 && currentHealth < 70)
        {
            sphere1.SetActive(false);
            sphere2.SetActive(true);
            sphere3.SetActive(true);
            sphere4.SetActive(true);
            sphere5.SetActive(true);
            sphere6.SetActive(true);
            sphere7.SetActive(false);
        }
        else if (currentHealth >= 50 && currentHealth < 60)
        {
            sphere1.SetActive(false);
            sphere2.SetActive(false);
            sphere3.SetActive(true);
            sphere4.SetActive(true);
            sphere5.SetActive(true);
            sphere6.SetActive(true);
            sphere7.SetActive(false);
        }
        else if (currentHealth >= 40 && currentHealth < 50)
        {
            sphere1.SetActive(false);
            sphere2.SetActive(false);
            sphere3.SetActive(false);
            sphere4.SetActive(true);
            sphere5.SetActive(true);
            sphere6.SetActive(true);
            sphere7.SetActive(false);
        }
        else if (currentHealth >= 30 && currentHealth < 40)
        {
            sphere1.SetActive(false);
            sphere2.SetActive(false);
            sphere3.SetActive(false);
            sphere4.SetActive(false);
            sphere5.SetActive(true);
            sphere6.SetActive(true);
            sphere7.SetActive(false);
        }
        else if (currentHealth >= 20 && currentHealth < 30)
        {
            sphere1.SetActive(false);
            sphere2.SetActive(false);
            sphere3.SetActive(false);
            sphere4.SetActive(false);
            sphere5.SetActive(false);
            sphere6.SetActive(true);
            sphere7.SetActive(false);
        }
        else if (currentHealth > 0 && currentHealth < 20)
        {
            sphere1.SetActive(false);
            sphere2.SetActive(false);
            sphere3.SetActive(false);
            sphere4.SetActive(false);
            sphere5.SetActive(false);
            sphere6.SetActive(false);
            sphere7.SetActive(true);
        }
        else if (currentHealth <= 0) {
            audio.Play(0);
            Debug.Log("Reload Scene");
            SceneManager.LoadScene(0); }
        //pk aixo funcioni has de fer un build de les escenes, teoricament la 0 es la inicial/la unica que tenim nosaltres

    }
}
