using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    GameObject player, spaceship;

    Rigidbody2D playerRb, spaceshipRb;

    bool inSpaceship;
    public static bool playerNearSpaceship;

    public float spaceshipForceMultiplier = 50f;
    public float spaceshipSpeedLimit = 50f;
    public float spaceshipDrag = 10f;

    public float playerForceMultiplier = 25f;
    public float playerSpeedLimit = 25f;
    public float playerDrag = 5f;

    private InputController input;

    // Use this for initialization
    void Awake()
    {
        input = GetComponent<InputController>();
        spaceshipRb = spaceship.GetComponent<Rigidbody2D>();
        playerRb = player.GetComponent<Rigidbody2D>();
        spaceshipRb.drag = spaceshipDrag;
        playerRb.drag = playerDrag;
    }

    void Update()
    {
        if (spaceshipRb.drag != spaceshipDrag || playerRb.drag != playerDrag) //Esto cambia el drag si lo cambiamos, solo tiene sentido en testing
        {                                                                     // en cuanto encontremos el valor optimo hay que quitarlo
            spaceshipRb.drag = spaceshipDrag;
            playerRb.drag = playerDrag;
        }
    }

    void FixedUpdate()
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

    public void EnterExitSpaceship()
    {
        if (!inSpaceship)
        {
            player.gameObject.SetActive(false);
            spaceshipRb.bodyType = RigidbodyType2D.Dynamic;
        }

        if (inSpaceship)
        {
            spaceshipRb.bodyType = RigidbodyType2D.Static;
            player.gameObject.SetActive(true);
            player.transform.position = new Vector2(spaceship.transform.position.x, spaceship.transform.position.y);
        }
        inSpaceship = !inSpaceship;
    }

    private void rotation(Rigidbody2D rb2D)
    {
        var angle = Mathf.Atan2(rb2D.velocity.y, rb2D.velocity.x) * Mathf.Rad2Deg;
        rb2D.MoveRotation(angle);
    }

}