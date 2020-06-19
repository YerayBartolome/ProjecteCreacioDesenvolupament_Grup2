using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    public GameObject[] drop;
    public GameObject explotionObj;
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
            GameObject obj1 = Instantiate(explotionObj);

            int index = rnd.Next(drop.Length);

            GameObject obj2 = Instantiate(drop[0], transform);
            Destroy(gameObject);
        }
        
    }
}
