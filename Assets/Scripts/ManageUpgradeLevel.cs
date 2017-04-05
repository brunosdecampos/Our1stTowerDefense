using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageUpgradeLevel : MonoBehaviour
{
    public int upgradeLevel = 1;
    TextMesh upgradeTxt;

	// Use this for initialization
	void Start ()
    {
        upgradeTxt = transform.GetChild(3).GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void UpdateText()
    {
        upgradeTxt.text = upgradeLevel.ToString();
    }
}
