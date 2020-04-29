using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToWorld_Follower : MonoBehaviour
{
    [SerializeField]
    GameObject turret;

 

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(turret.transform.position.x, turret.transform.position.y, transform.position.z);
    }
}
