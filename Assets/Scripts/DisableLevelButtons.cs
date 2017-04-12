using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableLevelButtons : MonoBehaviour
{
    GameObject[] levelButtons;

    // Use this for initialization
    void Start ()
    {
        levelButtons = GameObject.FindGameObjectsWithTag("LevelButton");
        int lastLevelBeaten = 0;
        if (PlayerPrefs.HasKey("lastLevelBeaten"))
        {
            lastLevelBeaten = PlayerPrefs.GetInt("lastLevelBeaten");
        }
        print(lastLevelBeaten);
        foreach (var button in levelButtons)
        {
            if (button.GetComponent<LevelNum>().levelToLoad > lastLevelBeaten + 1)
            {
                button.GetComponent<Button>().interactable = false;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
