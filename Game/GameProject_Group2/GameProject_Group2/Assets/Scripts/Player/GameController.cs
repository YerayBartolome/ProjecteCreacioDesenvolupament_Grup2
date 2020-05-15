﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    GameObject bullet;

    Rigidbody2D spaceshipRb;

    public static bool playerNearSpaceship;

    public float spaceshipForceMultiplier = 50f;
    public float spaceshipSpeedLimit = 50f;
    public float spaceshipDrag = 10f;
    public float turnSpeed = 10f;

    private float turnSpeedFix, speed;

    public float ShootFrequency = 1f;
    public Transform shootPoint1;
    public Transform shootPoint2;

    private float timeNextShoot;
    private bool cannon1 = false;

    private InputController input;
    private float currentAngle;

    // Use this for initialization
    void Awake()
    {
        turnSpeedFix = turnSpeed;
        Debug.Log("WELCOME TO RANGER K-21\nFollow the Log messages to proceed.\n" +
                   "Use 'WASD' to move.\nSee that turret? if you aproach to it, it will shoot you!\n" +
                   "You should go get your Spaceship first...");
        input = GetComponent<InputController>();
        spaceshipRb = GetComponent<Rigidbody2D>();
        spaceshipRb.drag = spaceshipDrag;
        timeNextShoot = Time.time;
        currentAngle = Mathf.Atan2(spaceshipRb.velocity.y, spaceshipRb.velocity.x) * Mathf.Rad2Deg;
        speed = 0;

    }

    void Update()
    {

        if (input.MouseRightClick)
        {
            Shoot();
        }


    }

    void FixedUpdate()
    {

        if (spaceshipRb.velocity.magnitude < spaceshipSpeedLimit)
        {
            spaceshipRb.AddForce(new Vector2(input.HorizontalAxis, input.VerticalAxis) * spaceshipForceMultiplier);
        }
        else
        {
            spaceshipRb.velocity = spaceshipRb.velocity.normalized * spaceshipSpeedLimit;
        }
        rotation(Mathf.Atan2(spaceshipRb.velocity.y, spaceshipRb.velocity.x) * Mathf.Rad2Deg);



    }

    private void rotation(float targetAngle)
    {
        spaceshipRb.freezeRotation = false;
        if (spaceshipRb.rotation < -180) spaceshipRb.rotation = 180;
        if (spaceshipRb.rotation > 180) spaceshipRb.rotation = -180;

        float direction = 0;

        if (spaceshipRb.rotation > 90 && spaceshipRb.rotation <= 180)
        {
            if (input.VerticalAxis > 0)
            {
                if (input.HorizontalAxis > 0) { direction = -1; }
                else if (input.HorizontalAxis < 0)
                {
                    if (spaceshipRb.rotation > 136) { direction = -1; }//marge 1
                    else if (spaceshipRb.rotation < 134) { direction = +1; }//marge 1
                }
                else if (spaceshipRb.rotation > 91) { direction = -1; }//marge 1
            }
            else if (input.VerticalAxis < 0)
            {
                if (input.HorizontalAxis > 0)
                {
                    if (spaceshipRb.rotation > 135) { direction = +1; }
                    else if (spaceshipRb.rotation <= 135) { direction = -1; }
                }
                else if (input.HorizontalAxis < 0) { direction = +1; }
                else { direction = +1; }
            }
            else if (input.HorizontalAxis != 0)
            {
                if (input.HorizontalAxis > 0) { direction = -1; }
                else if (spaceshipRb.rotation < 180) { direction = +1; }
            }
        }
        else if (spaceshipRb.rotation > 0 && spaceshipRb.rotation <= 90)
        {
            if (input.VerticalAxis > 0)
            {
                if (input.HorizontalAxis > 0)
                {
                    if (spaceshipRb.rotation > 46) { direction = -1; }//marge 1
                    else if (spaceshipRb.rotation < 44) { direction = +1; }//marge 1
                }
                else if (input.HorizontalAxis < 0) { direction = +1; }
                else if (spaceshipRb.rotation < 89) { direction = +1; }//marge 1
            }
            else if (input.VerticalAxis < 0)
            {
                if (input.HorizontalAxis > 0) { direction = -1; }
                else if (input.HorizontalAxis < 0)
                {
                    if (spaceshipRb.rotation > 45) { direction = +1; }
                    else if (spaceshipRb.rotation <= 45) { direction = -1; }
                }
                else { direction = -1; }
            }
            else if (input.HorizontalAxis != 0)
            {
                if (input.HorizontalAxis < 0) { direction = +1; }
                else if (spaceshipRb.rotation > +1) { direction = -1; }//marge 1
            }
        }
        else if (spaceshipRb.rotation > -90 && spaceshipRb.rotation <= 0)
        {
            if (input.VerticalAxis > 0)
            {
                if (input.HorizontalAxis > 0) { direction = +1; }
                else if (input.HorizontalAxis < 0)
                {
                    if (spaceshipRb.rotation > -45) { direction = +1; }
                    else if (spaceshipRb.rotation <= -45) { direction = -1; }
                }
                else { direction = +1; }
            }
            else if (input.VerticalAxis < 0)
            {
                if (input.HorizontalAxis > 0)
                {
                    if (spaceshipRb.rotation > -44) { direction = -1; }//marge 1
                    else if (spaceshipRb.rotation < -46) { direction = +1; }//marge 1
                }
                else if (input.HorizontalAxis < 0) { direction = -1; }
                else if (spaceshipRb.rotation > -89) { direction = -1; }//marge 1
            }
            else if (input.HorizontalAxis != 0)
            {
                if (input.HorizontalAxis < 0) { direction = -1; }
                else if (spaceshipRb.rotation < -1) { direction = +1; }//marge 1
            }
        }
        else if (spaceshipRb.rotation <= -90 && spaceshipRb.rotation >= -180)
        {
            if (input.VerticalAxis > 0)
            {
                if (input.HorizontalAxis > 0)
                {
                    if (spaceshipRb.rotation > -135) { direction = +1; }
                    else if (spaceshipRb.rotation <= -135) { direction = -1; }
                }
                else if (input.HorizontalAxis < 0) { direction = -1; }
                else { direction = -1; }
            }
            else if (input.VerticalAxis < 0)
            {
                if (input.HorizontalAxis > 0) { direction = +1; }
                else if (input.HorizontalAxis < 0)
                {
                    if (spaceshipRb.rotation > -134) { direction = -1; }//marge 1
                    else if (spaceshipRb.rotation < -136) { direction = +1; }//marge 1
                }
                else if (spaceshipRb.rotation < -91) { direction = +1; }//marge 1
            }
            else if (input.HorizontalAxis != 0)
            {
                if (input.HorizontalAxis > 0) { direction = +1; }
                else if (input.HorizontalAxis > -180) { direction = -1; }
            }
        }

        if (direction != 0) spaceshipRb.MoveRotation(spaceshipRb.rotation + direction * 3);
        else spaceshipRb.freezeRotation = true;
    }

    private void Shoot()
    {
        if (Time.time > timeNextShoot)
        {
            timeNextShoot = Time.time + (1 / ShootFrequency);
            if (cannon1)
            {
                Instantiate(bullet, shootPoint1.position, Quaternion.identity);
                cannon1 = !cannon1;
            }
            else
            {
                Instantiate(bullet, shootPoint2.position, Quaternion.identity);
                cannon1 = !cannon1;
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enter");

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("stay");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exit");
    }
}