using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosionController : MonoBehaviour
{

    public GameObject broken_mesh;

    public void Explode()
    {
        Instantiate(broken_mesh, transform.position, Quaternion.identity);
    }
}
