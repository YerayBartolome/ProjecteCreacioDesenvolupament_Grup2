using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalAxis, verticalAxis;
    private bool interact, reload, enterExitSpaceship, mouseRightClick, shield;
    private Vector3 mousePosition;  
     

    void Start()
    {
        horizontalAxis = 0f;
        verticalAxis = 0f;
        interact = false;
        reload = false;
        enterExitSpaceship = false;
        mouseRightClick = false;
        shield = false;
        mousePosition = new Vector2(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        interact = Input.GetKey(KeyCode.E);
        reload = Input.GetKey(KeyCode.R);
        enterExitSpaceship = Input.GetKeyDown("f");
        mouseRightClick = Input.GetMouseButton(0);
        shield = Input.GetKey(KeyCode.Space);
        mousePosition = Input.mousePosition;
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
    public bool Reload
    {
        get { return reload; }
    }
    public bool EnterExit
    {
        get { return enterExitSpaceship; }
    }
    public bool MouseRightClick
    {
        get { return mouseRightClick; }
    }
    public bool Shield
    {
        get { return shield; }
    }
    public Vector3 MousePosition
    {
        get { return mousePosition; }
    }

}
