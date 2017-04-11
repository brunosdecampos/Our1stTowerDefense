using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMove : MonoBehaviour
{
    public List<Color> oldColors;
    public int towerCost = 25;
    public string upgradeCost;
	public string upgradeDamageFactor;
	public string upgradeRange;
	public bool placable = true;
	public string[] upgradeCostPerLevel;

	TowerShoot ts;
	MoneyManager mm;

    // Use this for initialization
    void Start ()
    {
        oldColors = new List<Color>();
        ts = transform.GetChild(1).GetComponent<TowerShoot>();
        oldColors.Add(transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color);
        oldColors.Add(transform.GetChild(0).GetChild(1).GetComponent<Renderer>().material.color);
        oldColors.Add(transform.GetChild(0).GetChild(2).GetComponent<Renderer>().material.color);
        oldColors.Add(transform.GetChild(1).GetChild(0).GetComponent<Renderer>().material.color);
        oldColors.Add(transform.GetChild(1).GetChild(1).GetComponent<Renderer>().material.color);
        mm = GameObject.FindGameObjectWithTag("GameController").GetComponent<MoneyManager>();
        upgradeCostPerLevel = upgradeCost.Split(',');
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(!ts.placed)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
            pos.y = 0;
            transform.position = pos;
            //Debug.Log(pos);
            if (placable)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if ((mm.balance - towerCost) >= 0)
                    {
                        ts.placed = true;
                        mm.placeMode = false;
                        mm.balance -= towerCost;

                        //Set materials to opaque
                        transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = new Color(oldColors[0].r, oldColors[0].g, oldColors[0].b, 1);
                        transform.GetChild(0).GetChild(1).GetComponent<Renderer>().material.color = new Color(oldColors[1].r, oldColors[1].g, oldColors[1].b, 1);
                        transform.GetChild(0).GetChild(2).GetComponent<Renderer>().material.color = new Color(oldColors[2].r, oldColors[2].g, oldColors[2].b, 1);
                        transform.GetChild(1).GetChild(0).GetComponent<Renderer>().material.color = new Color(oldColors[3].r, oldColors[3].g, oldColors[3].b, 1);
                        transform.GetChild(1).GetChild(1).GetComponent<Renderer>().material.color = new Color(oldColors[4].r, oldColors[4].g, oldColors[4].b, 1);

                        //Enable colliders
                        //transform.GetChild(0).FindChild("Tower_Base").GetComponent<Collider>().isTrigger = false;
                        transform.GetChild(1).FindChild("Tower_Top").GetComponent<Collider>().enabled = true;
                    }
                }
            }
        }
    }
}
