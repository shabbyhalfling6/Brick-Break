using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour 
{
	public Sprite normalBrick;
	public Sprite strongBrick;
	public Sprite healthBrick;

	private float randomBrickType;
	private int numHits = 1;

	public GameObject heart;

	void Start()
	{
		GameController gameContoller = FindObjectOfType<GameController> ();
		gameContoller.AddBricks ();

		randomBrickType = Random.value;
		TypeOfBrick ();
	}

	void TypeOfBrick()
	{
		if (randomBrickType >= 0.7 && randomBrickType <= 0.95)
		{
			StrongBrick ();
			numHits = 2;
		}
		else if (randomBrickType > 0.95)
		{
			HealthBrick ();
			numHits = 3;
		}
		else
		{
			NormalBrick ();
		}
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		GameController gameContoller = FindObjectOfType<GameController> ();

		if (numHits == 1) 
		{
			gameContoller.AddScore ();
			Destroyed ();
			gameContoller.RemoveBricks ();
		} 
		else if (numHits == 2)
		{
			NormalBrick ();
		} 
		else if (numHits == 3)
		{
			StrongBrick ();
			heart.SetActive(true);
		}
	
		numHits--;
	}

	void Destroyed()
	{
		Destroy (gameObject);
	}

	void NormalBrick()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = normalBrick;
	}

	void StrongBrick()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = strongBrick;
	}

	void HealthBrick()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = healthBrick;
	}
	
}
