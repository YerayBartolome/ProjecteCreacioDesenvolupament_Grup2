using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRestorer : MonoBehaviour
{
    [SerializeField]
    private int ammoRestore;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            GameController gameController = other.GetComponent<GameController>();
            if (gameController.totalAmmo + ammoRestore < gameController.maxTotalAmmo)
            {
                gameController.totalAmmo += ammoRestore;
            } else
            {
                gameController.totalAmmo = gameController.maxTotalAmmo;
            }
            Destroy(gameObject);
        }
    }
}
