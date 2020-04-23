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
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth = currentHealth-damage;
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth == 0 && !gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    public int getHealth()
    {
        return currentHealth;
    }
}
