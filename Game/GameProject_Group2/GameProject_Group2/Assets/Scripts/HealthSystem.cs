using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthSystem : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;

    public HealthBar healthBar;

    [SerializeField] GameObject explosionParticles;
    public EnemyExplosionController explosion;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        explosion = GetComponent<EnemyExplosionController>();
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
                    explosion.Explode();
                }
                else
                {
                    var exploosionPS = explosionEfect.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(explosionEfect, exploosionPS.main.duration);
                    Destroy(gameObject, explosionPS.main.duration);
                    explosion.Explode();
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
