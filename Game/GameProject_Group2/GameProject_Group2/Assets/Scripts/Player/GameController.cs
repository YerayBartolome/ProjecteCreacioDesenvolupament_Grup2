using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    GameObject spaceship, bullet;

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

    private float currentAngle, targetAngle;

    // Use this for initialization
    void Awake()
    {
        if (spaceship != null)
        {
            Debug.Log("WELCOME TO RANGER K-21");
            Debug.Log("Follow the Log messages to proceed.");
            Debug.Log("Use 'WASD' to move.");
            Debug.Log("See that turret? if you aproach to it, it will shoot you!");
            Debug.Log("You should go get your Spaceship first...");
            input = GetComponent<InputController>();
            spaceshipRb = spaceship.GetComponent<Rigidbody2D>();
            spaceshipRb.drag = spaceshipDrag;
            timeNextShoot = Time.time;
            currentAngle = Mathf.Atan2(spaceshipRb.velocity.y, spaceshipRb.velocity.x) * Mathf.Rad2Deg;
        }
    }

    void Update()
    {
        if (spaceship != null )
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
        rotation(spaceshipRb);
            
            
        
    }

    private void rotation(Rigidbody2D rb2D)
    {
        targetAngle = Mathf.Atan2(rb2D.velocity.y, rb2D.velocity.x) * Mathf.Rad2Deg;
        currentAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, turnSpeed);
        rb2D.MoveRotation(currentAngle);
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
        spaceshipRb.freezeRotation = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        spaceshipRb.freezeRotation = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        spaceshipRb.freezeRotation = false;
    }

}