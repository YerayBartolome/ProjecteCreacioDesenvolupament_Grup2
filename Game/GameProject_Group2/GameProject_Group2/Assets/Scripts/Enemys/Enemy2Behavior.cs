using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Behavior : MonoBehaviour
{
    public Vector2 origin;
    public Vector2 other;
    public float velocity;
    public float shootRange = 10f;
    public GameObject bullet;
    public float shootFrequency = 1f;
    public float chasingDistance = 20f;

    private bool toOrigin = false;
    public bool chasing = false;
    private Rigidbody2D rb;
    private Rigidbody2D targetRigidbody;
    private float timeToShoot;
    
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        rb = GetComponent<Rigidbody2D>();
        timeToShoot = Time.time;
        targetRigidbody= GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        GameObject child = transform.GetChild(0).gameObject;
        other = child.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(rb.position, targetRigidbody.position)< chasingDistance)
        {
            chasing = true;
        }
        else
        {
            chasing = false;
        }
        if (!chasing)
        {
            if (toOrigin)
            {
                if (rb.position != origin)
                {
                    
                    MoveTo(origin);
                }
                else
                {
                    toOrigin = !toOrigin;
                }
            }
            else
            {
                if (rb.position != other)
                {
                    MoveTo(other);
                }
                else
                {
                    toOrigin = !toOrigin;
                }
            }
        }
        else
        {
            if (targetRigidbody == null)
            {
                chasing = false;
            }
            else
            {
                var distance = (targetRigidbody.position - rb.position).magnitude;
                if (distance <= shootRange)
                {
                    rb.velocity = new Vector2(0, 0);
                    if (Time.time>= timeToShoot)
                    {
                        Instantiate(bullet, transform.position, Quaternion.identity);
                        timeToShoot = Time.time + (1 / shootFrequency);
                    }
                    
                    
                }
                else MoveTo(targetRigidbody.position);
            }
        }
    }

    private void MoveTo(Vector2 target)
    {
        rb.MovePosition(Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target, velocity));
        Vector2 direction = target - (Vector2)transform.position;
               
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }



   
}
