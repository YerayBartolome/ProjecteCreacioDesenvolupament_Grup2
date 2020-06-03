using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TurretController : MonoBehaviour
{
    Rigidbody2D rgbd;
    TurretBehavior turretBehavior;
    GameObject target;
    void Start()
    {
        rgbd = this.GetComponent<Rigidbody2D>();
        turretBehavior = GetComponentInChildren<TurretBehavior>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rgbd.rotation = angle;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Spaceship"))
        {
            turretBehavior.Shooting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Spaceship"))
        {
            turretBehavior.Shooting = false;
        }
    }
}