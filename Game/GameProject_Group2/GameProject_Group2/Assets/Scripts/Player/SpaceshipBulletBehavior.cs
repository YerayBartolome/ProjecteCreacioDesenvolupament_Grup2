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

    Vector3 m_StartPosition;
    Vector3 m_EndPosition;
    public Vector3 m_Aim;

    [SerializeField] GameObject shotParticles, hitParticles;



    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        birthPosition = rb.position;
        m_Aim = GameObject.FindWithTag("AimPoint").GetComponent<Transform>().position;
        //Vector2 heading =  birthPosition - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);//(Vector2)GameObject.FindWithTag("AimPoint").GetComponent<Transform>().position - rb.position;
        Vector2 heading = ((Vector2)m_Aim) - birthPosition;
        float distance = heading.magnitude;
        direction = heading / distance;

        /*var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);*/
        transform.forward = heading;
        //transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

        m_StartPosition =rb.position;
        m_EndPosition = m_Aim;// Camera.main.ScreenToWorldPoint(Input.mousePosition);

        m_StartPosition.z = 0.0f;
        m_EndPosition.z = 0.0f;
    }

    private void Start()
    {
        rb.velocity = direction * velocity;
        audio = GetComponent<AudioSource>();
        timebirth = Time.time;
        bulletmesh = transform.GetChild(1).gameObject;

        if(shotParticles != null)
        {
            var shotEfect = Instantiate(shotParticles, transform.position, Quaternion.identity);
            shotEfect.transform.forward = direction;
            var shotPS = shotEfect.GetComponent<ParticleSystem>();
            if(shotPS != null)
            {
                Destroy(shotEfect, shotPS.main.duration);
            }
            else
            {
                var shootPS = shotEfect.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(shotEfect, shootPS.main.duration);
            }
            
        }

    }
    void Update()
    {
        Debug.DrawLine(m_StartPosition, m_EndPosition, Color.magenta);
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
        deadBullet = true;

        if (hitParticles != null)
        {
            var hitEfect = Instantiate(hitParticles, transform.position, Quaternion.identity);
            hitEfect.transform.forward = direction;
            var hitPS = hitEfect.GetComponent<ParticleSystem>();
            if (hitPS != null)
            {
                Destroy(hitEfect, hitPS.main.duration);
            }
            else
            {
                var shootPS = hitEfect.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(hitEfect, shootPS.main.duration);
            }

        }


        Destroy(bulletmesh);
        
    }



}
