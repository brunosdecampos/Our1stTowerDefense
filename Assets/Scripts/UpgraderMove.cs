using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgraderMove : MonoBehaviour
{
    GameObject target;
    ManageUpgradeLevel mul;
    TowerMove tm;
    MoneyManager mm;
    TowerOrUpgradeCost touc;

	// Use this for initialization
	void Start ()
    {
        GameObject gcObj = GameObject.FindGameObjectWithTag("GameController");
        mm = gcObj.GetComponent<MoneyManager>();
        touc = gcObj.GetComponent<TowerOrUpgradeCost>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
        pos.y = 4.5f;
        transform.position = pos;

        if (target != null)
        {
            if (mul.upgradeLevel - 1 < tm.upgradeCostPerLevel.Length)
            {
                if ((mm.balance - int.Parse(tm.upgradeCostPerLevel[mul.upgradeLevel - 1])) >= 0)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        touc.ShowNewText(false);
                        mm.balance -= int.Parse(tm.upgradeCostPerLevel[mul.upgradeLevel - 1]);
                        mul.Upgrade(tm);

                        mm.placeMode = false;
                        Destroy(gameObject);
                    }
                }
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("PathBox"))
        {
            if (other.transform.parent.parent != null)
            {
                if (other.transform.parent.parent.gameObject.tag.Equals("Tower"))
                {
                    target = other.transform.parent.parent.gameObject;
                    tm = target.GetComponent<TowerMove>();
                    mul = target.GetComponent<ManageUpgradeLevel>();
                    touc.cost = int.Parse(tm.upgradeCostPerLevel[mul.upgradeLevel - 1]);
                    touc.ShowNewText(true);
                    GetComponent<Renderer>().material.color = Color.green;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("PathBox"))
        {
            if (other.transform.parent.parent != null)
            {
                if (other.transform.parent.parent.gameObject.tag.Equals("Tower"))
                {
                    target = null;
                    touc.ShowNewText(false);
                    GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
    }
}
