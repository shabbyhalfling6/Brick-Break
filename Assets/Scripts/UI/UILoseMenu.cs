using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UILoseMenu : MonoBehaviour {

	public int highScore;
	public Text value;

	public void Show()
	{
		Time.timeScale = 0.0f;
		gameObject.SetActive (true);
		value.text = "YOUR HIGH SCORE: " + highScore.ToString ();
	}
}
