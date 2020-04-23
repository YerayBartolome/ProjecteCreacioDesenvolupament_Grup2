﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceshipInteraction : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            GameController.playerNearSpaceship = true;
            Debug.Log("Press 'f' to enter the Spaceship");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            GameController.playerNearSpaceship = false;
        }
    }

}
