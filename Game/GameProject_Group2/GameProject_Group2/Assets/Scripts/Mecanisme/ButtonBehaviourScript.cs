using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviourScript : MonoBehaviour
{

    [SerializeField]  private DoorBehavior door;
    [SerializeField]  private Material red, green;
    [SerializeField]  private Light redL, greenL;

    private InputController input;
    Renderer rend;

    private GameObject button;
    private void Awake()
    {
        input = GetComponent<InputController>();
        button = GetComponent<GameObject>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = red;
        redL.enabled = true;
        greenL.enabled = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !door.openned)
        {
            if (input.Interact)
            {
                door.Action();
                rend.sharedMaterial = green;
                redL.enabled = false;
                greenL.enabled = true;
            }
                
        }
    }
}
