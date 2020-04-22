using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviourScript : MonoBehaviour
{
    
    private ButtonAction ButtonAction;
    private InputController input;

    // Start is called before the first frame update
    void Start()
    {
        ButtonAction = GetComponent<ButtonAction>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (input.Interact)
            {
                ButtonAction.Action();

            }
        }
    }
}
