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
    public float turnSpeed = 0.1f;

    public float ShootFrequency = 1f;
    public Transform shootPoint;
    private float timeNextShoot;

    private InputController input;
    private bool colision = false;
    private float currentAngle;

    // Use this for initialization
    void Awake()
    {
        
         Debug.Log("WELCOME TO RANGER K-21\nFollow the Log messages to proceed.\n" +
                    "Use 'WASD' to move.\nSee that turret? if you aproach to it, it will shoot you!\n" +
                    "You should go get your Spaceship first...");
         input = GetComponent<InputController>();
         spaceshipRb = gameObject.GetComponent<Rigidbody2D>();
         spaceshipRb.drag = spaceshipDrag;
         timeNextShoot = Time.time;
         currentAngle = Mathf.Atan2(spaceshipRb.velocity.y, spaceshipRb.velocity.x) * Mathf.Rad2Deg;
        
    }

    void Update()
    {
        
        if (spaceshipRb.drag != spaceshipDrag) //Esto cambia el drag si lo cambiamos, solo tiene sentido en testing
        {                                                                     // en cuanto encontremos el valor optimo hay que quitarlo
          spaceshipRb.drag = spaceshipDrag;         
        }
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
        if (!colision) rotation();
    
        
    }

    private void rotation()
    {   
        if(input.HorizontalAxis!=0 || input.VerticalAxis != 0)
        {
            
            
            //Debug.Log("Target: " + targetAngle + "Current: " + currentAngle);
            float targetAngle = Mathf.Atan2(spaceshipRb.velocity.y, spaceshipRb.velocity.x) * Mathf.Rad2Deg;
            currentAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, turnSpeed);
            spaceshipRb.MoveRotation(currentAngle);
        }       
    }

    private void Shoot()
    {
        if (Time.time > timeNextShoot)
        {
            timeNextShoot = Time.time + (1 / ShootFrequency);
            Instantiate(bullet, shootPoint.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        colision = true;
        spaceshipRb.freezeRotation = true;
        Debug.Log("Collision");
        spaceshipRb.AddForce(new Vector2(-input.HorizontalAxis, -input.VerticalAxis) * spaceshipForceMultiplier);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Target: " + input.VerticalAxis + " " + input.HorizontalAxis + "Current: " + currentAngle);

        if(currentAngle>0)
        {
            
        }
        else
        {

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colision = false;
        Debug.Log("Exit");
        spaceshipRb.freezeRotation = false;
    }
}