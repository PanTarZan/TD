using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] Points;
	// Use this for initialization
	void Awake () {
        Points = new Transform[transform.childCount];
        for (int i = 0; i < Points.Length; i++)
        {
            Points[i] =  transform.GetChild(i);

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
