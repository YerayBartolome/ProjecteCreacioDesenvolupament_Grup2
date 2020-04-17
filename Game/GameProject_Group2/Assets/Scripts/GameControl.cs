using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

public class GameControl : MonoBehaviour {

	[SerializeField]
	GameObject cat, car;// carButton;

	[SerializeField]
	Transform carDoor;

	Rigidbody2D carRb, catRb;

	bool inCar;
	public static bool catNearTheCarDoor;

	float dirX, moveSpeed;

	// Use this for initialization
	void Start () {		
		carRb = car.GetComponent<Rigidbody2D> ();
		catRb = cat.GetComponent<Rigidbody2D> ();
		//carButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (inCar)
			moveSpeed = 10f;
		else
			moveSpeed = 5f;

		/*if (catNearTheCarDoor || inCar)
			carButton.SetActive (true);
		else
			carButton.SetActive(false);			

		dirX = CrossPlatformInputManager.GetAxis ("Horizontal") * moveSpeed;*/
	}

	void FixedUpdate()
	{
		if (inCar)
			carRb.velocity = new Vector2 (carRb.velocity.x*moveSpeed, carRb.velocity.y);
		else
			catRb.velocity = new Vector2 (catRb.velocity.x * moveSpeed, catRb.velocity.y);
	}

	public void EnterExitCar()
	{
		if (!inCar) {
			cat.gameObject.SetActive (false);
		}

		if (inCar) {
			cat.gameObject.SetActive (true);
			cat.transform.position = new Vector2 (carDoor.position.x, carDoor.position.y);
		}

		inCar = !inCar;
	}

}
