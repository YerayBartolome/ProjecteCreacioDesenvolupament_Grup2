using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Vector2 velocity;
    [SerializeField] float smoothTimeX = 0;
    [SerializeField] float smoothTimeY = 0, distance = 10;
    [SerializeField] GameObject spaceship; 
    Vector2 targetPosition;


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

            if (Vector2.Distance((Vector2)m_DebugObject.transform.position, (Vector2)spaceship.transform.position) <= distance)
            {
                targetPosition = (new Vector2(m_DebugObject.transform.position.x, m_DebugObject.transform.position.y) -
                                new Vector2(spaceship.transform.position.x, spaceship.transform.position.y))/2;
            }
                                  
            float posX, posY;
            posX = Mathf.SmoothDamp(transform.position.x, targetPosition.x + spaceship.transform.position.x, ref velocity.x, smoothTimeX);
            posY = Mathf.SmoothDamp(transform.position.y, targetPosition.y + spaceship.transform.position.y, ref velocity.y, smoothTimeY);
                        
            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }
}
