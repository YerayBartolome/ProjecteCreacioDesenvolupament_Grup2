using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveDamage : MonoBehaviour
{
    public float explotionDistance = 30f;
    public int damage = 20;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] crates = GameObject.FindGameObjectsWithTag("Crates");
        check(player);
       foreach(GameObject e in enemies)
       {
            check(e);
       }
       foreach(GameObject c in crates)
        {
            check(c);
        }
    }

    private void check(GameObject other )
    {
        var playerPosition = other.transform.position;
        var enemyPosition = transform.position;
        var distance = ((Vector2)playerPosition - (Vector2)enemyPosition).magnitude;
        var direction = ((Vector2)playerPosition - (Vector2)enemyPosition) / distance;
        Explode(distance, other);
    }

    void Explode(float distance, GameObject o)
    {
        Debug.Log("Explode");
        if (distance < explotionDistance)
        {
            try
            {
                o.GetComponent<HealthSystem>().TakeDamage(damage);
            } catch { }
            try
            {
                o.GetComponent<BarrelBehaviour>().currentHealth -= damage;
            } catch { }
            Debug.Log("Dmg deal");
 
        }

    }
}
