using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBulletBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 birthPosition;
    public float velocity = 5f;
    public float limitDistance = 20f;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        birthPosition = rb.position;
        Vector2 heading = (Vector2)GameObject.FindWithTag("AimPoint").GetComponent<Transform>().position - rb.position;
        float distance = heading.magnitude;
        Vector2 direction = heading / distance;
        rb.velocity = direction * velocity;
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
        if (collision.CompareTag("Enemy"))
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

    private void ExploteAnimation()
    {
        Destroy(gameObject);
    }
}
