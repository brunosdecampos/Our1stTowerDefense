using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
	private GameObject optionsContainer;
	public Text submenuTitle, instructions, soundsOnOff, effectsOnOff;
    private int initialXPosition = Screen.width, finalXPosition = 600,
                tutorialBtnCounter = 0, optionsBtnCounter = 0;
	private bool tutorialBtnClicked, optionsBtnClicked;
	public AudioSource song;
    private bool musicOn = true, effectsOn = true;

	void Start ()
	{
		optionsContainer = GameObject.FindGameObjectWithTag ("OptionsContainer");
		optionsContainer.transform.position += new Vector3 (initialXPosition, 0, 0);
        if(PlayerPrefs.HasKey("MusicOn"))
        {
            musicOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("MusicOn"));
            if(!musicOn)
            {
                song.Stop();
                soundsOnOff.text = "Music: Off";
            }
        }
        if (PlayerPrefs.HasKey("EffectsOn"))
        {
            effectsOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("EffectsOn"));
            if (!effectsOn)
            {
                song.Stop();
                effectsOnOff.text = "Sound Effects: Off";
            }
        }
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
		if (musicOn) {
			song.Stop ();
			soundsOnOff.text = "Music: Off";
            musicOn = false;
		} else {
			song.Play ();
			soundsOnOff.text = "Music: On";
            musicOn = true;
		}
        PlayerPrefs.SetInt("MusicOn", System.Convert.ToInt32(musicOn));
	}

	public void ClickEffectsButton ()
	{
		if (effectsOn) {
			// soundEffect.volume = 0;
			effectsOnOff.text = "Sound Effects: Off";
            effectsOn = false;
		} else {
			// soundEffect.volume = 1;
			effectsOnOff.text = "Sound Effects: On";
            effectsOn = true;
		}
        PlayerPrefs.SetInt("EffectsOn", System.Convert.ToInt32(effectsOn));
    }

	public void QuitGame ()
    {
		Application.Quit();
	}

}