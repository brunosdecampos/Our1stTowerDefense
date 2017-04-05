using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scoreNum = 0;
    Text scoreTxt;
    public int moneyBonus = 100;
    public int castleBonus = 250;
    public int levelClearBonus = 1000;

    // Use this for initialization
    void Start ()
    {
        scoreTxt = transform.GetChild(0).GetChild(3).GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreTxt.text = "Score: " + scoreNum;
	}
}
