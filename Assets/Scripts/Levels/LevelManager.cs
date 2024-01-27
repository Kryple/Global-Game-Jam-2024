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

	public void Awake()
	{
		int i = 1;
		foreach (Button gameButton in this.gameButtons)
		{
			gameButton.onClick.AddListener(() =>
			{
				Debug.Log("Loaded Level: " + (this.gameButtons.IndexOf(gameButton) + 1));

				//this.LoadLevel(i++);
			});
		}

		this.playButton.onClick.AddListener(() =>
		{
			this.mainMenu.SetActive(false);

			this.listLevelMenu.SetActive(true);
		});

		this.quitButton.onClick.AddListener(() =>
		{
			Application.Quit();
		});

		this.returnButton.onClick.AddListener(() =>
		{
			this.mainMenu.SetActive(true);

			this.listLevelMenu.SetActive(false);
		});

		Time.timeScale = 1.0f;
	}

	public void LoadLevel(int levelToLoad)
    {
        this.GetComponent<LevelLoader>().LoadLevel(levelToLoad);
    }
}
