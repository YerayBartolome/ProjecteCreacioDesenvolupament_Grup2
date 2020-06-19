using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    
    public GameObject explotionObj;
    public GameObject[] drop;
    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {   
        if (currentHealth <= 0)
        {
            System.Random rnd = new System.Random();
            GameObject obj1 = Instantiate(explotionObj, transform.position, Quaternion.identity);
            int index = rnd.Next(drop.Length);
            GameObject obj2 = Instantiate(drop[index], transform.position, Quaternion.identity);
            //Debug.Log(transform.position);
            Destroy(gameObject);
        }
        
    }
}
