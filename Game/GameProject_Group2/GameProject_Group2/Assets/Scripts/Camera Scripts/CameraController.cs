﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Vector2 velocity;
    [SerializeField]
    float smoothTimeX = 0;
    [SerializeField]
    float smoothTimeY = 0;
    [SerializeField]
    GameObject gameControl, spaceship, player;

    GameController gameController;

    private void Start()
    {
        gameController = gameControl.GetComponent<GameController>();
    }

    void FixedUpdate()
    {
        if (spaceship != null && player != null)
        {
            float posX, posY;
            if (gameController.inSpaceship)
            {
                posX = Mathf.SmoothDamp(transform.position.x, spaceship.transform.position.x, ref velocity.x, smoothTimeX);
                posY = Mathf.SmoothDamp(transform.position.y, spaceship.transform.position.y, ref velocity.y, smoothTimeY);
            }
            else
            {
                posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
                posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
            }
            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }

}
