using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public UIScoreCounter uiScoreCounter;
	public UILivesCounter uiLivesCounter;
	public UILoseMenu uiLoseMenu;
	public UIWinMenu uiWinMenu;

	public GameObject pauseMenu;
	public GameObject continueText;
	public GameObject brickBreakText;

	public int score;
	public int remainingBricks;
	public int lives = 3;

	public bool gameOver;
	public bool won = false;
	public bool spacePressed;

	void Awake()
	{
		Time.timeScale = 0.0f;

		uiLivesCounter.SetLives (lives);

		uiLoseMenu.highScore = PlayerPrefs.GetInt ("High Score");

        score = PlayerPrefs.GetInt ("Player Score");
        uiScoreCounter.SetScore(score);
    }

	void Update()
	{
		PlayerPrefs.SetInt ("Player Score", score);
		PlayerPrefs.SetInt ("High Score", uiLoseMenu.highScore);

		if(remainingBricks == 0)
		{
			gameOver = true;
			won = true;
            continueText.SetActive(true);
		}

		if (gameOver)
		{
			if(won)
			{
				uiWinMenu.Show();

				if(score > uiLoseMenu.highScore)
				{
					uiLoseMenu.highScore = score;
					continueText.SetActive(true);
				}

                if (Input.GetKeyDown("space"))
                {
                    SceneManager.LoadScene(0);
                }
            }
			else
			{
                uiLoseMenu.Show();
                PlayerPrefs.SetInt("Player Score", 0);

                if (Input.GetKeyDown("space"))
                {
                    SceneManager.LoadScene(0);
                }
            }
		}

        if (Input.GetKeyDown("space"))
        {
            brickBreakText.SetActive(false);
            Time.timeScale = 1.0f;
            continueText.SetActive(false);
        }

        if(Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

	public void AddBricks()
	{
		remainingBricks++;
	}

	public void RemoveBricks()
	{
		remainingBricks--;
	}

	public void AddScore()
	{
		score++;
		uiScoreCounter.SetScore(score);
	}

	public void AddLife()
	{
		lives ++;
		uiLivesCounter.SetLives (lives);
	}

	public void RemoveLife()
	{
		if (lives == 0) 
		{
			gameOver = true;
		} 
		else 
		{
			lives--;
			uiLivesCounter.SetLives (lives);
		}
	}

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Player Score", 0);
    }
}
