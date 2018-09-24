using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public float movementSpeed = 8f;

	public Vector2 input;
	public Vector2 lockedYAxis;

	void Update()
	{
		
		lockedYAxis = transform.position;
		lockedYAxis.y = -4.65f;
		//transform.position.y = 0;
		input = new Vector2 (Input.GetAxis ("Horizontal"), 0);
		transform.position = lockedYAxis;
	}

	void FixedUpdate () 
	{
		GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + (input * movementSpeed * Time.fixedDeltaTime));
	}
}
