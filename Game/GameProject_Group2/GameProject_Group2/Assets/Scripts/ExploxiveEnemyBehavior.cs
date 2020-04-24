using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploxiveEnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private GameObject player;
    private bool exploting = false;

    public float detectionDistance = 10f;
    public float explotionTriggerDistance = 2f;
    public float explotionDistance = 2f;
    public float velocity = 3f;
    public float explotionTimer = 5f; //Tiempo en sec desde la activacion hasta la explosion
    public int damage;

    private AudioSource audio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var playerPosition = player.transform.position;
        var enemyPosition = rb.position;
        var distance = ((Vector2)playerPosition - enemyPosition).magnitude;
        var direction = ((Vector2)playerPosition - enemyPosition)/ distance;

        if (distance < detectionDistance)
        {
            rb.velocity = direction * velocity;

            if (distance < explotionDistance&& !exploting)
            {

                exploting = true;

            }
        }
        if (exploting)
        {
            if (Time.time >= explotionTimer)
            {
                Explode(distance);
            }
        }

    }

    void Update()
    {
        if (exploting)
        {
            //Red animation
        }

    }

    void Explode(float distance)
    {
        if (distance <= explotionDistance)
        {
            HealthSystem health = player.GetComponent<HealthSystem>();
            health.TakeDamage(damage);
        }
        audio.Play(0);
        Destroy(gameObject);
    }
}
