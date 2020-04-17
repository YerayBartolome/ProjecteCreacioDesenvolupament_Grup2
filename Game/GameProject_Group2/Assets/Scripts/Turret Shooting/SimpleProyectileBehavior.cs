using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProyectileBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 birthPosition;
    public float velocity = 5f;    
    public float limitDistance = 20f;
    public float Damage = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        birthPosition = rb.position;
        Vector2 direcction = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().position - rb.position;
        rb.velocity = direcction * velocity;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (System.Math.Abs(Vector2.Distance(birthPosition, rb.position)) >= limitDistance)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Deal dmg to player
            ExploteAnimation();
        }
        else if (collision.CompareTag("Wall"))
        {
            ExploteAnimation();
        }
    }

    private void ExploteAnimation()
    {
        Destroy(gameObject);
    }
}
