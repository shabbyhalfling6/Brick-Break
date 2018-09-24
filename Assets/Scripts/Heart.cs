using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {

	private GameController gameController;

    void Start()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("New tag");
        gameController = controller.GetComponent<GameController>();
    }

    void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Platform")
	  	{
            Debug.Log("Test");
			gameController.AddLife();
            Destroy(this.gameObject);
		}
	}
	
}
