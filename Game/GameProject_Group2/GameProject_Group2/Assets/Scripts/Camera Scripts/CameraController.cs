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
    GameObject spaceship;

    Plane m_SpaceshipPlane;
    Camera m_Caamera;
    public Transform m_DebugObject;

    private void Start()
    {
        m_SpaceshipPlane = new Plane(Vector3.forward, spaceship.transform.position);
        m_Caamera = GetComponent < Camera> ();
    }
    void FixedUpdate()
    {
        if (spaceship != null)
        {
            //Input.moou
            Ray l_Ray=m_Caamera.ScreenPointToRay(Input.mousePosition);
            float l_Distance;
            if (m_SpaceshipPlane.Raycast(l_Ray, out l_Distance))
            {
                Vector2 l_Position = l_Ray.GetPoint(l_Distance);
                m_DebugObject.transform.position = l_Position;
            }
            float posX, posY;
            posX = Mathf.SmoothDamp(transform.position.x, spaceship.transform.position.x, ref velocity.x, smoothTimeX);
            posY = Mathf.SmoothDamp(transform.position.y, spaceship.transform.position.y, ref velocity.y, smoothTimeY);
            
            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }

}
