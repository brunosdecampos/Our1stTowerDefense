using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageUpgradeLevel : MonoBehaviour
{
    public int upgradeLevel = 1;
    TextMesh upgradeTxt;
    SphereCollider shootTrigger;
    TowerShoot ts;

	// Use this for initialization
	void Start ()
    {
        upgradeTxt = transform.GetChild(3).GetComponent<TextMesh>();
        shootTrigger = transform.GetChild(2).GetComponent<SphereCollider>();
        ts = transform.GetChild(1).GetComponent<TowerShoot>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void UpdateText()
    {
        upgradeTxt.text = upgradeLevel.ToString();
    }

    public void Upgrade(TowerMove tm)
    {
        shootTrigger.radius = float.Parse(tm.upgradeRangePerLevel[upgradeLevel - 1]);
        //ts.projSpeed = shootTrigger.radius * 2;
        ts.projDamageFactor = float.Parse(tm.upgradeDamageFactorPerLevel[upgradeLevel - 1]);
        upgradeLevel++;
        UpdateText();
    }
}
