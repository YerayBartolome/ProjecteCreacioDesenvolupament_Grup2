using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;

    public HealthBar healthBar;

    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        audio = GetComponent<AudioSource>();
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
            if (audio != null) audio.Play(0);
            Destroy(gameObject);
        }
    }

    public void Heal(int hp)
    {
        if (currentHealth + hp >= maxHealth)
        {
            currentHealth = maxHealth;
        } 
        else
        {
            currentHealth = currentHealth + hp;
        }
    }

    public int getHealth()
    {
        return currentHealth;
    }
}
