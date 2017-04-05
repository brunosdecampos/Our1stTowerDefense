using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public float balance = 100;
    public GameObject towerPrefab;
    Text balanceTxt;

	// Use this for initialization
	void Start ()
    {
        Instantiate(towerPrefab, new Vector3(0, 0, -4), Quaternion.identity);
        balanceTxt = transform.GetChild(0).GetChild(0).GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        balanceTxt.text = "Money: " + balance;
	}
}
