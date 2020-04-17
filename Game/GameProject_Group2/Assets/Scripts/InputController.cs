using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalAxis, verticalAxis;
    
    void Start()
    {
        horizontalAxis = 0f;
        verticalAxis = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
    }
    public float HorizontalAxis
    {
        get{ return horizontalAxis;}
    }
    public float VerticalAxis
    {
        get { return verticalAxis; }
    }



}
