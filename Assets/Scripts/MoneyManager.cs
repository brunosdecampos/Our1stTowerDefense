﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int balance = 100;
    public List<GameObject> towerPrefab;
    public GameObject upgraderPrefab;
    Text balanceTxt;
    public bool placeMode = false;
    GameObject currentObject;
    TowerOrUpgradeCost touc;
    Pause p;

	// Use this for initialization
	void Start ()
    {
        balanceTxt = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        touc = GameObject.FindGameObjectWithTag("GameController").GetComponent<TowerOrUpgradeCost>();
        p = transform.GetChild(0).GetChild(7).GetComponent<Pause>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        balanceTxt.text = "Money: " + balance;

        if (!placeMode)
        {
            if (!p.paused)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    currentObject = Instantiate(towerPrefab[0], new Vector3(0, 0, -4), Quaternion.identity);
                    touc.cost = currentObject.GetComponent<TowerMove>().towerCost;
                    touc.ShowNewText(true);
                    placeMode = true;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    currentObject = Instantiate(towerPrefab[1], new Vector3(0, 0, -4), Quaternion.identity);
                    touc.cost = currentObject.GetComponent<TowerMove>().towerCost;
                    touc.ShowNewText(true);
                    placeMode = true;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    currentObject = Instantiate(towerPrefab[2], new Vector3(0, 0, -4), Quaternion.identity);
                    touc.cost = currentObject.GetComponent<TowerMove>().towerCost;
                    touc.ShowNewText(true);
                    placeMode = true;
                }
                else if (Input.GetKeyDown(KeyCode.U))
                {
                    currentObject = Instantiate(upgraderPrefab, new Vector3(0, 5, -4), upgraderPrefab.transform.rotation);
                    placeMode = true;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) ||
                Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.U))
            {
                touc.ShowNewText(false);
                Destroy(currentObject);
                placeMode = false;
            }
        }
	}
}
