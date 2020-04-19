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

    void Start()
    {
        input = gameControl.GetComponent<InputController>();
    }

    void FixedUpdate()
    {
        Vector3 mousePosition = input.MousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 2f));
        aimPoint.transform.position = worldMousePosition;
    }

}
