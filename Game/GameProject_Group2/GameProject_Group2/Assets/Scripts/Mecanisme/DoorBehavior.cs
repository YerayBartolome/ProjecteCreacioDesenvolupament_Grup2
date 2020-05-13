using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour//, ButtonAction
{
    public bool openned;
    public Vector2 initialPosition; // Setted to object intial postion 
    public Vector2 otherPosition;
    public float doorVelocity = 1f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = rb.position;
        openned = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void FixedUpdate() {
        openClose();
        Debug.Log(rb.position);
    }
 
    private void openClose()
    {
        if (!openned)
        {            
            if (rb.position != initialPosition) MoveTo(initialPosition);
        }
        else if (rb.position != otherPosition) MoveTo(otherPosition);

        
    }

    public void Action(){
        openned = !openned;
    }

    private void MoveTo(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target, doorVelocity);
    }

}
