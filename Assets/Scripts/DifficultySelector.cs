using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    private int difficultyIndex;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void DifficultySelect(int difficulty)
    {
        difficultyIndex = difficulty;
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public int GetDifficultyLevel()
    {
        return difficultyIndex;
    }
}
