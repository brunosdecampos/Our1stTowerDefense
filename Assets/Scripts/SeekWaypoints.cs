﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekWaypoints : MonoBehaviour
{
    List<GameObject> waypoints;
    Vector3 seekPos;
    int seek_i = 0;
    Vector3 pullP = Vector3.zero;
    Vector3 vel;
    public float seekFactor;
    Rigidbody rb;
    public float maxSpeed = 5;
    float velMag;
    EnemyProperties castle_ep;
    public int enemyStrength = 1;
	GameController controller;

    // Use this for initialization
    void Start ()
    {
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
        waypoints = new List<GameObject>();
        rb = GetComponent<Rigidbody>();
		for (int i = 0; i < controller.numOfWaypoints; i++)
        {
            waypoints.Add(GameObject.Find("Waypoint_" + i));
        }
        seekPos = waypoints[seek_i].transform.position;
        castle_ep = GameObject.FindGameObjectWithTag("Castle").GetComponent<EnemyProperties>();
    }

    // Update is called once per frame
    void Update ()
    {
        Seek();
		//Debug.Log((seekPos - transform.position).magnitude);
		if ((seekPos - transform.position).magnitude < 0.1f * Time.timeScale)
        {
            //Debug.Log("Reached waypoint " + seek_i);
            if (seek_i < waypoints.Count - 1)
            {
                seek_i++;
                seekPos = waypoints[seek_i].transform.position;
                rb.velocity = Vector3.zero;
            }
            else
            {
                castle_ep.ChangeHealth(-enemyStrength);
                Destroy(gameObject);
            }
        }
    }

    void Seek()
    {
        pullP = seekPos - transform.position;
        pullP.y = 0;
        vel = rb.velocity;
        vel += pullP * seekFactor;

        velMag = vel.magnitude;
        if (velMag > maxSpeed)
        {
            vel *= (maxSpeed / velMag);
        }

        rb.velocity = vel;
    }
}