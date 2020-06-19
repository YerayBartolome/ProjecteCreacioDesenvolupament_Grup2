using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Transform shootpoint;
    public Transform shootpoint2;
    public GameObject proyectile;
    private float shootFrequency = 1f;
    private bool shooting = false;
    private bool canonswap = true;
    private float nextshot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shooting && Time.time >= nextshot)
        {
            Shoot();
        }
    }

    public bool Shooting
    {
        get
        {
            return shooting;
        }
        set
        {
            shooting = value;
            nextshot = Time.time + (1 / shootFrequency); //tiempo actual mas periodo 
        }
    }

    private void Shoot()
    {
        if (canonswap)
        {
            Instantiate(proyectile, shootpoint.position, Quaternion.identity);
            nextshot = Time.time + (1 / shootFrequency);
        }
        else
        {
            Instantiate(proyectile, shootpoint2.position, Quaternion.identity);
            nextshot = Time.time + (1 / shootFrequency);
        }

        canonswap = !canonswap;
        
    }
}
