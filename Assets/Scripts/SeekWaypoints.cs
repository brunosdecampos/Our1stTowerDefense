using System.Collections;
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
    public int numOfWaypoints = 6;
    public float maxSpeed = 5;
    float velMag;

    // Use this for initialization
    void Start ()
    {
        waypoints = new List<GameObject>();
        rb = GetComponent<Rigidbody>();
        for (int i = 0; i < numOfWaypoints; i++)
        {
            waypoints.Add(GameObject.Find("Waypoint_" + i));
        }
        seekPos = waypoints[seek_i].transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        Seek();
        //Debug.Log(vel.magnitude);
        if (vel.magnitude < seekFactor + 0.05f)
        {
            //Debug.Log("Reached waypoint " + seek_i);
            if (seek_i < waypoints.Count - 1)
            {
                seek_i++;
                seekPos = waypoints[seek_i].transform.position;
            }
            else
            {
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