using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonController : MonoBehaviour
{

    [SerializeField]
    private GameObject aimPoint;

    [SerializeField]
    private GameObject gameControl;

    private InputController input;
    private Rigidbody2D rb;


    void Start()
    {
        input = gameControl.GetComponent<InputController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 mousePosition = input.MousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 9f));
        aimPoint.transform.position = worldMousePosition;

        Vector3 direction = aimPoint.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        transform.localPosition =new Vector3(0, 0, -0.5f);
    }

}