using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake()
    {
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject MissileLauncherPrefab;
    private GameObject turrettoBuild;
    public GameObject GetTurretToBuild()
    {
        return turrettoBuild;
    }

	
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetTurretToBuild(GameObject turret)
    {
        turrettoBuild = turret;
    }
   
}
