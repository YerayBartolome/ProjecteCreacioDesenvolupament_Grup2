using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBulletBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 birthPosition;
    private bool deadBullet = false;
    private float timebirth;
    private GameObject bulletmesh;
    public float velocity = 5f;
    public float limitDistance = 20f;
    public int damage = 1;
    private AudioSource audio;
    private Vector2 direction;
    


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        birthPosition = rb.position;
        Vector2 heading =  birthPosition - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);//(Vector2)GameObject.FindWithTag("AimPoint").GetComponent<Transform>().position - rb.position;
        float distance = heading.magnitude;
        direction = heading / distance;
        
        var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        

    }

    private void Start()
    {
        rb.velocity = direction * velocity;
        audio = GetComponent<AudioSource>();
        timebirth = Time.time;
        bulletmesh = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (System.Math.Abs(Vector2.Distance(birthPosition, rb.position)) >= limitDistance)
        {
            Destroy(gameObject);
        }
        if ((Time.time-timebirth)>=audio.clip.length && deadBullet)
        {
            Destroy(gameObject);
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!deadBullet)
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
    }

    private void ExploteAnimation()
    {
        //Destroy(transform.GetChild(0).gameObject);
        rb.bodyType = RigidbodyType2D.Static;
        Destroy(bulletmesh);
        deadBullet = true;
    }



}
