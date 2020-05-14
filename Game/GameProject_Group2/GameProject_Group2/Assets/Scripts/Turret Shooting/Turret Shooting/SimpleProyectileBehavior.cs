using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProyectileBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 birthPosition;
    private float timebirth;
    private bool deadBullet = false;
    private AudioSource audio;
    public float velocity = 5f;    
    public float limitDistance = 20f;
    public int damage = 1;
    private GameObject bulletmesh;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        birthPosition = rb.position;
        Vector2 heading = (Vector2)GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().position - rb.position;
        float distance = heading.magnitude;
        Vector2 direction = heading / distance;
        rb.velocity = direction * velocity;
        timebirth = Time.time;
        bulletmesh = transform.GetChild(1).gameObject;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (System.Math.Abs(Vector2.Distance(birthPosition, rb.position)) >= limitDistance)
        {
            Destroy(gameObject);
        }
        if ((Time.time - timebirth) >= audio.clip.length && deadBullet)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!deadBullet)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("Spaceship"))
            {
                HealthSystem health = collision.GetComponent<HealthSystem>();
                health.TakeDamage(damage);
                ExploteAnimation();
            }
            else if (collision.CompareTag("Wall"))
            {
                ExploteAnimation();
            }
        }
    }

    private void ExploteAnimation()
    {
        //Destroy(transform.GetChild(0).gameObject);
        rb.bodyType = RigidbodyType2D.Static;
        Destroy(bulletmesh);
        deadBullet = true;
    }
}
