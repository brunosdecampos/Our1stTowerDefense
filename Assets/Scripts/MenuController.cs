using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public GameObject optionsContainer;

	void Start ()
    {
		optionsContainer = GameObject.FindGameObjectWithTag ("OptionsContainer");
		// optionsContainer.SetActive (true); // optionsContainer.enabled = false;
	}

	public void PlayGame ()
    {
        SceneManager.LoadScene("Level1");
	}

	public void QuitGame ()
    {
		Application.Quit();
	}

}