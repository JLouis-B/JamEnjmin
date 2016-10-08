using UnityEngine;
using System.Collections;

public class CrowdManager : MonoBehaviour {

    public GameObject spawner;
    public int crowdNumber;

	// Use this for initialization
	void Start () {
        crowdNumber = 50;
        // at start spawning the crowd
        for (int i =0;i<crowdNumber;i++)
        GameObject.Instantiate(spawner);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
