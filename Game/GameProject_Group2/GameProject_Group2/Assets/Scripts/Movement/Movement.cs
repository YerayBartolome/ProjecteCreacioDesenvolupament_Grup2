using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float forceMultiplier = 10f;
    public float speedLimit = 20f;
    public float spaceShipDrag = 10f;
    private Rigidbody2D rb;
    private InputController input;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = spaceShipDrag;
        input = GetComponent<InputController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.magnitude < speedLimit)
        {
            rb.AddForce(new Vector2(input.HorizontalAxis, input.VerticalAxis) * forceMultiplier); //Añade fuerza
        }
        else { 
            rb.velocity = rb.velocity.normalized * speedLimit;
        }
        var angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
    }
     void Update()
    {
        if (rb.drag != spaceShipDrag) //Esto cambia el drag si lo cambiamos, solo tiene sentido en testing
        {                             // en cuanto encontremos el valor optimo hay que quitarlo
            rb.drag = spaceShipDrag;
        }
    }
}
