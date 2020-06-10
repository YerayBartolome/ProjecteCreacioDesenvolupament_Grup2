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
    public float explotionDistance = 30f;
    public float velocity = 3f;
    public float explotionTimer = 5f; //Tiempo en sec desde la activacion hasta la explosion
    public int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
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
            if (distance < explotionDistance && !exploting)
            {                
                exploting = true;
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
        if (distance < explotionDistance)
        {
            HealthSystem playerH = player.GetComponent<HealthSystem>();
            playerH.TakeDamage(damage);
            HealthSystem health = gameObject.GetComponent<HealthSystem>();
            health.TakeDamage(health.getMaxHealth()*2);            
        }
        
    }
}
