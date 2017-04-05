using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public float balance = 100;
    public GameObject towerPrefab;
    Text balanceTxt;
    public bool placeMode = false;
    GameObject currentTower;

	// Use this for initialization
	void Start ()
    {
        balanceTxt = transform.GetChild(0).GetChild(0).GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        balanceTxt.text = "Money: " + balance;

        if (!placeMode)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                currentTower = Instantiate(towerPrefab, new Vector3(0, 0, -4), Quaternion.identity);
                placeMode = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Destroy(currentTower);
                placeMode = false;
            }
        }
	}
}
