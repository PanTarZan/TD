using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY : MonoBehaviour {
    public float Speed = 10f;
    private Transform Target;
    private int WavepointIndex;
	// Use this for initialization
	void Start () {
        Target = Waypoints.Points[0];
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = Target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(Target.position, transform.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
	}

    private void GetNextWaypoint()
    {
        if (WavepointIndex >= Waypoints.Points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        WavepointIndex++;
        Target = Waypoints.Points[WavepointIndex];
    }
}
