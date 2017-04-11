using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgraderMove : MonoBehaviour
{
    GameObject target;
    ManageUpgradeLevel mul;
    TowerMove tm;
    MoneyManager mm;

	// Use this for initialization
	void Start ()
    {
        mm = GameObject.FindGameObjectWithTag("GameController").GetComponent<MoneyManager>();
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
            mul = target.GetComponent<ManageUpgradeLevel>();
            tm = target.GetComponent<TowerMove>();
            if (mul.upgradeLevel - 1 < tm.upgradeCostPerLevel.Length)
            {
                if ((mm.balance - int.Parse(tm.upgradeCostPerLevel[mul.upgradeLevel - 1])) >= 0)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
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
                    GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
    }
}
