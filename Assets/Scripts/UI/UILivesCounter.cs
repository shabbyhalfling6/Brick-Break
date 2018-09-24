using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UILivesCounter : MonoBehaviour {

	public Text value;

	public void SetLives(int lives)
	{
		value.text = lives.ToString ();
	}
}
