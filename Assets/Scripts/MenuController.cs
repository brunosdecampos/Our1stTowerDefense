using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
	private GameObject optionsContainer;
	public Text submenuTitle;
	public Text instructions;
	private int initialXPosition = Screen.width, finalXPosition = 600, tutorialBtnCounter = 0, optionsBtnCounter = 0, submenuContainerCounter = 0;
	private bool tutorialBtnClicked, optionsBtnClicked;

	void Start ()
	{
		optionsContainer = GameObject.FindGameObjectWithTag ("OptionsContainer");
		optionsContainer.transform.position += new Vector3 (initialXPosition, 0, 0);
	}

	void Update ()
	{
		if (tutorialBtnClicked) {
			if (tutorialBtnCounter % 2 != 0) {
				ShowSubmenuContainer ();
			} else {
				HideSubmenuContainer ();
			}
		}

		if (optionsBtnClicked) {
			if (optionsBtnCounter % 2 != 0) {
				ShowSubmenuContainer ();
			} else {
				HideSubmenuContainer ();
			}
		}

	}

	public void PlayGame ()
    {
        SceneManager.LoadScene("LevelSelector");
	}

	public void ClickTutorialButton ()
	{
		instructions.enabled = true;
		submenuTitle.text = "Tutorial";
		optionsBtnCounter = 0;
		tutorialBtnCounter++;
		optionsBtnClicked = false;
		tutorialBtnClicked = true;
	}

	public void ClickOptionsButton ()
	{
		instructions.enabled = false;
		submenuTitle.text = "Options";
		tutorialBtnCounter = 0;
		optionsBtnCounter++;
		tutorialBtnClicked = false;
		optionsBtnClicked = true;
	}

	public void ShowSubmenuContainer ()
	{
		// Stop moving when reaching the maximum x position
		if (optionsContainer.transform.position.x > finalXPosition) {
			optionsContainer.transform.position += new Vector3 (-50, 0, 0);
		}
	}

	public void HideSubmenuContainer ()
	{
		// Stop moving when reaching the initial x position
		if (optionsContainer.transform.position.x < initialXPosition) {
			optionsContainer.transform.position += new Vector3 (50, 0, 0);
		}
	}

	public void QuitGame ()
    {
		Application.Quit();
	}

}