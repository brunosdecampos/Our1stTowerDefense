using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public float shotInterval = 0.5f;
    float shootTimer = 0;
    public List<GameObject> targets;
    Vector3 dir;
    public GameObject projectilePrefab;
    public float projSpeed = 10;
    public bool placed = true;

	// Use this for initialization
	void Start ()
    {
        targets = new List<GameObject>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (placed)
        {
            if (targets.Count > 0)
            {
                CheckIfEnemyIsDead(targets[0]);
                if (targets.Count > 0)
                {
                    OrientToEnemy(targets[0]);
                    if (Time.time > shootTimer)
                    {
                        ShootEnemy();
                    }
                }
            }
        }
	}

    private void CheckIfEnemyIsDead(GameObject enemy)
    {
        if(enemy == null)
        {
            targets.Remove(enemy);
        }
    }

    void OrientToEnemy(GameObject enemy)
    {
        Vector3 enemyPos = enemy.transform.position + enemy.GetComponent<Rigidbody>().velocity / 3;
        dir = enemyPos - transform.position;
        Debug.DrawRay(transform.position, dir);
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir, transform.up);
    }

    void ShootEnemy()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.y = 0.5f;
        GameObject projectile = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = dir.normalized * projSpeed;
        shootTimer = Time.time + shotInterval;
    }
}
