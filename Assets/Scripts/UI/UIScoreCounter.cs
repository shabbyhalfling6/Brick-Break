using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScoreCounter : MonoBehaviour {

	public Text value;

	public void SetScore(int score)
	{
		value.text = score.ToString ();
	}
}
