using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonController : MonoBehaviour
{

    [SerializeField]
    private GameObject aimPoint;

    [SerializeField]
    private GameObject Spaceship;

    [SerializeField]
    private Transform pivot;

    private InputController input;

    private Transform spaceshipTransform;

    [SerializeField]
    Camera camera;

    void Start()
    {
        input = Spaceship.GetComponent<InputController>();
        spaceshipTransform = Spaceship.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(pivot.position.x, pivot.position.y, transform.position.z);
        Vector3 mousePosition = input.MousePosition;
        Vector3 worldMousePosition = camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 9f));
        aimPoint.transform.position = worldMousePosition;

        Vector3 direction = aimPoint.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GetComponent<Rigidbody2D>().rotation = angle;
    }

}