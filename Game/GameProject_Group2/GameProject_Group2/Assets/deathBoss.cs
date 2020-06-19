using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathBoss : MonoBehaviour
{
    [SerializeField] GameObject obj;
    public GameObject boss_B;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (boss_B == null)
        {
            obj.active = true;
        }
    }
}
