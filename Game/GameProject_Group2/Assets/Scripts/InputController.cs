using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalAxis, verticalAxis;
    private bool interact, enterExitSpaceship;

    void Start()
    {
        horizontalAxis = 0f;
        verticalAxis = 0f;
        interact = false;
        enterExitSpaceship = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        interact = Input.GetKeyDown("e");
        enterExitSpaceship = Input.GetKeyDown("f");
    }
    public float HorizontalAxis
    {
        get{ return horizontalAxis;}
    }
    public float VerticalAxis
    {
        get { return verticalAxis; }
    }
    public bool Interact
    {
        get { return interact; }
    }
    public bool EnterExit
    {
        get { return enterExitSpaceship; }
    }



}
