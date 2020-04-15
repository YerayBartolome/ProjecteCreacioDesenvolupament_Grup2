using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Vector2 velocity;
    [SerializeField]
    float smoothTimeX = 0;
    [SerializeField]
    float smoothTimeY = 0;
    [SerializeField]
    GameObject target;

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);    
    
    }

}
