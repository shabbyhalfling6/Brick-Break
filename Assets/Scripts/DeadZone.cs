using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	public GameController gameController;

	public GameObject ball;

	public Transform originalPosition;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (gameController.lives == 0)
		{
			collider.gameObject.SetActive(false);
		}
		//if the ball is in the dead zone remove a life and if the lives = 0 the ball will be disabled
		if (collider.gameObject.tag == "Ball")
		{
			collider.transform.position = originalPosition.position;
			gameController.RemoveLife ();
			Time.timeScale = 0.0f;
            gameController.continueText.SetActive(true);
		} 
		else 
		{
			//disable whatever touches the dead zone
			collider.gameObject.SetActive (false);
		}
	}

}
