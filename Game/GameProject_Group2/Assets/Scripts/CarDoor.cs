using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDoor : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals ("Cat"))
			GameControl.catNearTheCarDoor = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name.Equals ("Cat"))
			GameControl.catNearTheCarDoor = false;
	}

}
