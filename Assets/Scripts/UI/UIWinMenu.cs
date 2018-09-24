using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIWinMenu : MonoBehaviour {

	public void Show()
	{
		Time.timeScale = 0.0f;
		gameObject.SetActive (true);
		if (Input.GetKeyDown ("space")) 
		{
			SceneManager.LoadScene(0);
		}
	}
}
