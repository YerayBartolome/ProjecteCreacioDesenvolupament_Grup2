using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRestorer : MonoBehaviour
{
    public float shieldPoints;
    private bool used = false;

    private void FixedUpdate()
    {
        if (used && !gameObject.GetComponent<AudioSource>().isPlaying)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (!used && other.CompareTag("Player"))
        {
            other.GetComponent<ShieldController>().RestoreShield(shieldPoints);
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            gameObject.GetComponentInChildren<AudioSource>().Play(0);
            used = true;
        }
    }
}
