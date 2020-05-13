using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private DoorBehavior door;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !door.openned)
        {
            if (Input.GetKey(KeyCode.E))
                door.Action(); 
        }
    }
}
