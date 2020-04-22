using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Debug.Log(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth = currentHealth-damage;

        healthBar.SetHealth(currentHealth);
    }
}
