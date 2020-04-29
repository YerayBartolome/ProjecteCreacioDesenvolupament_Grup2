﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject door;

    private ButtonAction buttonAction;

    private InputController input;

    // Start is called before the first frame update
    void Start()
    {
        buttonAction = door.GetComponent<ButtonAction>();
        input = GetComponent<InputController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (input.Interact)
            {
                buttonAction.Action();

            }
        }
    }
}
