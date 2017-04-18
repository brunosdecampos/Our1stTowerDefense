using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
	private GameObject optionsContainer;
	public Text submenuTitle, instructions, soundsOnOff, effectsOnOff;
	private int initialXPosition = Screen.width, finalXPosition = 600, tutorialBtnCounter = 0, optionsBtnCounter = 0, submenuContainerCounter = 0, soundsBtnCounter = 0, effectsBtnCounter = 0;
	private bool tutorialBtnClicked, optionsBtnClicked;
	public AudioSource song;

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
		soundsOnOff.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		effectsOnOff.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		optionsBtnCounter = 0;
		tutorialBtnCounter++;
		optionsBtnClicked = false;
		tutorialBtnClicked = true;
	}

	public void ClickOptionsButton ()
	{
		instructions.enabled = false;
		submenuTitle.text = "Options";
		soundsOnOff.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
		effectsOnOff.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
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

	public void ClickSoundsButton ()
	{
		soundsBtnCounter++;

		if (soundsBtnCounter % 2 != 0) {
			song.Stop ();
			soundsOnOff.text = "Sounds: Off";
		} else {
			song.Play ();
			soundsOnOff.text = "Sounds: On";
		}
	}

	public void ClickEffectsButton ()
	{
		effectsBtnCounter++;

		if (effectsBtnCounter % 2 != 0) {
			// soundEffect.volume = 0;
			effectsOnOff.text = "Effects: Off";
		} else {
			// soundEffect.volume = 1;
			effectsOnOff.text = "Effects: On";
		}
	}

	public void QuitGame ()
    {
		Application.Quit();
	}

}