using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    private Vector3 position;

    public Vector3 Position { get => position; set => position = value; }

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        transform.position = Position;
    }
    
}
