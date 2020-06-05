using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FirePropulsionController : MonoBehaviour
{

    [SerializeField] private VisualEffect thruster1, thruster2, thruster3;
    private InputController input;

    private void Start()
    {
        input = GetComponent<InputController>();

    }

    private void FixedUpdate()
    {
        if (input.HorizontalAxis != 0 || input.VerticalAxis != 0)
        {
            thruster1.Play();
            thruster2.Play();
            thruster3.Play();
        } else
        {
            thruster1.Stop();
            thruster2.Stop();
            thruster3.Stop();
        }
    }
}
