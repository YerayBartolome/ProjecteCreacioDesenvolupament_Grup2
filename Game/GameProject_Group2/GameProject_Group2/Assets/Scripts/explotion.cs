using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explotion : MonoBehaviour
{
    public float minForce = 0;
    public float maxForce = 5;
    public float explosionRadius;
    public float destroyDelay = 5;

    [SerializeField] GameObject explosionParticles;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in transform)
        {
            var rb = t.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(Random.Range(minForce,maxForce), transform.position, explosionRadius);
            }
            Destroy(t.gameObject, destroyDelay);
        }
        var explosionEfect = Instantiate(explosionParticles, transform.position, Quaternion.identity);
    }

   
}
