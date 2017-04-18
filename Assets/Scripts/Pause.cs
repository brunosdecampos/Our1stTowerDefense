using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool paused = false;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                SetPauseState(true);            
            }
            else
            {
                SetPauseState(false);
            }
        }
	}

    public void SetPauseState(bool state)
    {
        if(state)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        paused = state;
        GetComponent<Image>().enabled = state;
        transform.GetChild(0).GetComponent<Text>().enabled = state;
        for (int i = 1; i < 3; i++)
        {
            transform.GetChild(i).GetComponent<Image>().enabled = state;
            transform.GetChild(i).GetComponent<Button>().enabled = state;
            transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = state;
        }
    }
}
