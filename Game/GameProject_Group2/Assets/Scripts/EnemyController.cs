using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    GameObject target;

    [SerializeField]
    bool MoveTowardsPlayer = false;
    private bool actuallyMove = false;

    [SerializeField]
    float moveSpeed = 5f;
    
    Rigidbody2D rgbd;

    Vector2 movement;

    public bool playerInRange;

    TurretBehavior turretBehavior;

    void Start()
    {
        rgbd = this.GetComponent<Rigidbody2D>();
        turretBehavior = GetComponentInChildren<TurretBehavior>();
    }

    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rgbd.rotation = angle;
        if (actuallyMove)
        {
            direction.Normalize();
            movement = direction;
        }
    }
    
    void FixedUpdate()
    {
        if (actuallyMove)
        {
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rgbd.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Spaceship"))
        {
            turretBehavior.Shooting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Spaceship"))
        {
            turretBehavior.Shooting = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && this.CompareTag("MeleeEnemy"))
        {
            Destroy(this);
        }
    }
}
