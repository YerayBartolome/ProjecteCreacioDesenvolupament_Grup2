using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRestorer : MonoBehaviour
{
    public float shieldPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ShieldController>().RestoreShield(shieldPoints);
        }
    }
}
