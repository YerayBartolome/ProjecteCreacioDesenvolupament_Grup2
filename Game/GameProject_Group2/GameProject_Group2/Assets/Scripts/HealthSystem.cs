using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthSystem : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;

    public HealthBar healthBar;

    [SerializeField] GameObject explosionParticles;

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
        if (currentHealth <= 0 && !gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            if (explosionParticles != null)
            {
                var explosionEfect = Instantiate(explosionParticles, transform.position, Quaternion.identity);
                //shotEfect.transform.forward = direction;
                var explosionPS = explosionEfect.GetComponent<ParticleSystem>();
                if (explosionPS != null)
                {
                    Destroy(explosionEfect, explosionPS.main.duration);
                    Destroy(gameObject, explosionPS.main.duration);
                }
                else
                {
                    var exploosionPS = explosionEfect.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(explosionEfect, exploosionPS.main.duration);
                    Destroy(gameObject, explosionPS.main.duration);
                }
            }
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

    public int getMaxHealth()
    {
        return maxHealth;
    }
}
