using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    GameObject player, spaceship, bullet;

    Rigidbody2D playerRb, spaceshipRb;

    public bool inSpaceship;
    public static bool playerNearSpaceship;

    public float spaceshipForceMultiplier = 50f;
    public float spaceshipSpeedLimit = 50f;
    public float spaceshipDrag = 10f;
    public float turnSpeed = 0.1f;

    public float playerForceMultiplier = 25f;
    public float playerSpeedLimit = 25f;
    public float playerDrag = 5f;

    public float ShootFrequency = 1f;
    public Transform shootPoint;
    private float timeNextShoot;

    private InputController input;

    private float currentAngle, targetAngle;

    private bool shouldRotate = true;

    // Use this for initialization
    void Awake()
    {
        if (spaceship != null && player != null)
        {
            Debug.Log("WELCOME TO RANGER K-21");
            Debug.Log("Follow the Log messages to proceed.");
            Debug.Log("Use 'WASD' to move.");
            Debug.Log("See that turret? if you aproach to it, it will shoot you!");
            Debug.Log("You should go get your Spaceship first...");
            input = GetComponent<InputController>();
            spaceshipRb = spaceship.GetComponent<Rigidbody2D>();
            playerRb = player.GetComponent<Rigidbody2D>();
            spaceshipRb.drag = spaceshipDrag;
            playerRb.drag = playerDrag;
            timeNextShoot = Time.time;
            currentAngle = Mathf.Atan2(spaceshipRb.velocity.y, spaceshipRb.velocity.x) * Mathf.Rad2Deg;
        }
    }

    void Update()
    {
        if (spaceship != null && player != null)
        {
            if (spaceshipRb.drag != spaceshipDrag || playerRb.drag != playerDrag) //Esto cambia el drag si lo cambiamos, solo tiene sentido en testing
            {                                                                     // en cuanto encontremos el valor optimo hay que quitarlo
                spaceshipRb.drag = spaceshipDrag;
                playerRb.drag = playerDrag;
            }
            if (inSpaceship)
            {
                if (input.MouseRightClick)
                {
                    Shoot();
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (spaceship != null && player != null)
        {
            if (inSpaceship)
            {
                if (input.EnterExit)
                {
                    EnterExitSpaceship();
                }
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
            else
            {
                if (playerNearSpaceship && input.EnterExit)
                {
                    EnterExitSpaceship();
                }
                if (playerRb.velocity.magnitude < playerSpeedLimit)
                {
                    playerRb.AddForce(new Vector2(input.HorizontalAxis, input.VerticalAxis) * playerForceMultiplier);
                }
                else
                {
                    playerRb.velocity = playerRb.velocity.normalized * playerSpeedLimit;
                }
                rotation(playerRb);
            }
        }
    }

    public void EnterExitSpaceship()
    {
        if (!inSpaceship)
        {
            player.gameObject.SetActive(false);
            spaceship.tag = "Player";
            spaceshipRb.bodyType = RigidbodyType2D.Dynamic;
        }

        if (inSpaceship)
        {
            spaceshipRb.bodyType = RigidbodyType2D.Static;
            player.gameObject.SetActive(true);
            spaceship.tag = "Spaceship";
            player.transform.position = new Vector2(spaceship.transform.position.x, spaceship.transform.position.y);
        }
        inSpaceship = !inSpaceship;
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