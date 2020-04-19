using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalAxis, verticalAxis;
    private bool interact, enterExitSpaceship, mouseRightClick;
    //private Vector3 mousePosition;  
    private Vector2 mousePosition; 

    void Start()
    {
        horizontalAxis = 0f;
        verticalAxis = 0f;
        interact = false;
        enterExitSpaceship = false;
        mouseRightClick = false;
        mousePosition = new Vector2(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        interact = Input.GetKeyDown("e");
        enterExitSpaceship = Input.GetKeyDown("f");
        mouseRightClick = Input.GetMouseButtonDown(0);
        //mousePosition = Input.mousePosition;
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
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
    public bool MouseRightClick
    {
        get { return mouseRightClick; }
    }
    /*
     public Vector3 MousePosition
    {
        get { return mousePosition; }
    }
    */
    public Vector2 MousePosition
    {
        get { return mousePosition; }
    }

}
