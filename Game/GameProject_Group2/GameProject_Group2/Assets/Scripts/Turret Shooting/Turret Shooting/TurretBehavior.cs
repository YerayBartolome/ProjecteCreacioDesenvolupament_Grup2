using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    public Transform shootpoint;
    public GameObject proyectile;
    private float shootFrequency = 1f;
    private bool shooting = false;
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
        Instantiate(proyectile, shootpoint.position, Quaternion.identity);
        nextshot = Time.time + (1 / shootFrequency);
    }
    
}
