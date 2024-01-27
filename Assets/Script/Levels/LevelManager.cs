using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject listLevelMenu;

	[SerializeField] private Button playButton;
	[SerializeField] private Button quitButton;
	[SerializeField] private Button returnButton;

	[SerializeField] private List<Button> gameButtons;

	[SerializeField] private GameObject _pausingScreen;

	public void Awake()
	{
		_pausingScreen.SetActive(false);
		
		int i = 1;
		foreach (Button gameButton in this.gameButtons)
		{
			gameButton.onClick.AddListener(() =>
			{
				Debug.Log("Loaded Level: " + (this.gameButtons.IndexOf(gameButton) + 1));

				//this.LoadLevel(i++);
			});
		}

		if (playButton != null)
		{
			this.playButton.onClick.AddListener(() =>
			{
				this.mainMenu.SetActive(false);

				this.listLevelMenu.SetActive(true);
			});
		}

		if (quitButton != null)
		{
			this.quitButton.onClick.AddListener(() =>
			{
				Application.Quit();
			});
		}

		if (returnButton != null)
		{
			this.returnButton.onClick.AddListener(() =>
			{
				this.mainMenu.SetActive(true);

				this.listLevelMenu.SetActive(false);
			});
		}

		Time.timeScale = 1.0f;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			PauseTheGame();
	}

	public void LoadLevel(int levelToLoad)
    {
        this.GetComponent<LevelLoader>().LoadLevel(levelToLoad);
    }

	public void PauseTheGame()
	{
		Time.timeScale = 0;
		_pausingScreen.SetActive(true);
	}

	public void ContinueTheGame()
	{
		Time.timeScale = 1f;
		_pausingScreen.SetActive(false);
	}
}
