using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Behavior : MonoBehaviour
{
    public Vector2 origin;
    public Vector2 other;
    public float velocity;
    public float shootRange = 5f;
    public GameObject bullet;

    private bool toOrigin = false;
    private bool chasing = false;
    private Rigidbody2D rb;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!chasing)
        {
            if (toOrigin)
            {
                if (rb.position != origin)
                {
                    MoveTo(origin);
                }
            }
            else
            {
                if (rb.position != other)
                {
                    MoveTo(other);
                }
            }
        }
        else
        {
            if (target == null)
            {
                chasing = false;
            }
            else
            {
                var distance = (target.GetComponent<Rigidbody2D>().position - rb.position).magnitude;
                if (distance <= shootRange)
                {
                    rb.velocity = new Vector2(0, 0);
                    Instantiate(bullet, transform.position, Quaternion.identity);
                }
                else MoveTo(target.GetComponent<Rigidbody2D>().position);
            }
        }
        
    }

    private void MoveTo(Vector2 target)
    {

        if ((target - rb.position).magnitude < 1)
        {
            rb.position = target;
        }
        else
        {
            rb.velocity = (target - rb.position / (target - rb.position).magnitude) * velocity;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chasing = true;
            target = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chasing = false;
            target = null;
        }
    }
}
