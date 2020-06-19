using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    public GameObject[] drop;
    public GameObject explotionObj;

    public void OnDestroy()
    {   
        System.Random rnd = new System.Random();
        GameObject obj1 = Instantiate(explotionObj);

        int index = rnd.Next(drop.Length);

        GameObject obj2 = Instantiate(drop[index]);
    }
}
