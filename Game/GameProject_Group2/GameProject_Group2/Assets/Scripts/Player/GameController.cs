using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] GameObject bullet;

    Rigidbody2D spaceshipRb;

    public static bool playerNearSpaceship;

    public float spaceshipForceMultiplier = 50f;
    public float spaceshipSpeedLimit = 50f;
    public float spaceshipDrag = 10f;
    float turnSpeed = 4f;

    private float turnSpeedFix, speed;

    public float ShootFrequency = 3f;
    public float reloadTime = 1f;
    public int maxTotalAmmo = 100;
    public int totalAmmo = 0;
    public int maxLoadedAmmo = 10;
    public int loadedAmmo = 0;
    public Text loadedAmmoDisplay;
    public Text totalAmmoDisplay;
    public GameObject reloadAnim;
    public bool isReloading;

    public Transform shootPoint1;
    public Transform shootPoint2;

    private float timeNextShoot;
    private bool cannon1 = false;

    private InputController input;
    private float currentAngle;

    // Use this for initialization
    void Awake()
    {
        reloadAnim.SetActive(false);
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

        if (input.MouseRightClick && (totalAmmo != 0 || loadedAmmo != 0))
        {
            Shoot();
        }

        loadedAmmoDisplay.text = loadedAmmo.ToString();
        totalAmmoDisplay.text = totalAmmo.ToString();

    }

    void FixedUpdate()
    {
        if (Time.time > timeNextShoot && isReloading) isReloading = false;
        reloadAnim.SetActive(isReloading);

        if (spaceshipRb.velocity.magnitude < spaceshipSpeedLimit)
        {
            spaceshipRb.AddForce(new Vector2(input.HorizontalAxis, input.VerticalAxis) * spaceshipForceMultiplier);
        }
        else
        {
            spaceshipRb.velocity = spaceshipRb.velocity.normalized * spaceshipSpeedLimit;
        }


        if (input.VerticalAxis != 0 || input.HorizontalAxis != 0)
        {
            float targetAngle = Mathf.Atan2(input.VerticalAxis, input.HorizontalAxis) * Mathf.Rad2Deg;
            currentAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, turnSpeed);
        }

        spaceshipRb.MoveRotation(currentAngle);
    }

    private void Shoot()
    {
        if (loadedAmmo <= 0)
        {
            GetComponent<AudioSource>().Play(0);
            timeNextShoot += reloadTime;
            while (totalAmmo > 0 && loadedAmmo < maxLoadedAmmo)
            {
                loadedAmmo++;
                totalAmmo--;
                isReloading = true;
            }
        }

        if (Time.time > timeNextShoot && !isReloading)
        {
            timeNextShoot = Time.time + (1 / ShootFrequency);
            if (cannon1)
            {
                Instantiate(bullet, shootPoint1.position, Quaternion.identity);
                loadedAmmo--;
                cannon1 = !cannon1;
            }
            else
            {
                Instantiate(bullet, shootPoint2.position, Quaternion.identity);
                loadedAmmo--;
                cannon1 = !cannon1;
            }

        }
    }
}