using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerOrUpgradeCost : MonoBehaviour
{
    public int cost = 0;
    Text costTxt;

	// Use this for initialization
	void Start ()
    {
        costTxt = transform.GetChild(0).GetChild(5).GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ShowNewText(bool display)
    {
        if(display)
        {
            costTxt.text = "Cost: " + cost;
        }
        else
        {
            costTxt.text = "";
        }
    }
}
