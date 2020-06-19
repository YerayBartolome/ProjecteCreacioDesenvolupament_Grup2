using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenBehaviour : MonoBehaviour
{ 
    [SerializeField] private GameObject interactMessage;
    [SerializeField] private GameObject textMessage;
    [SerializeField] private GameObject scenaryMessage;


    private float timeUntilSwap = 0f;
    private bool showTextMessage = false;
    public string text;

    private InputController input;
   

    private GameObject button;
    private void Awake()
    {
        input = GetComponent<InputController>();
        button = GetComponent<GameObject>();
      
        
        interactMessage.SetActive(false);
        textMessage.SetActive(false);
        scenaryMessage.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (showTextMessage)
            {
                textMessage.SetActive(true);
                scenaryMessage.SetActive(true);
                textMessage.GetComponent<Text>().text = text;
                scenaryMessage.GetComponent<Text>().text = text;
            }
            else interactMessage.SetActive(true);
            if (input.Interact && Time.time > timeUntilSwap) Swap();   
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactMessage.SetActive(false);
            textMessage.SetActive(false);
            scenaryMessage.SetActive(false);
        }
    }

    private void Swap()
    {
        showTextMessage = !showTextMessage;
        interactMessage.SetActive(false);
        textMessage.SetActive(false);
        scenaryMessage.SetActive(false);
        timeUntilSwap = Time.time + 0.5f;
        
    }
}
