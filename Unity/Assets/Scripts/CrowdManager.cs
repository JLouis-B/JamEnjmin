using UnityEngine;
using System.Collections;

public class CrowdManager : MonoBehaviour {

    public GameObject spawner;

	// Use this for initialization
	void Start () {
        // at start spawning the crowd
        for (int i =0;i<50;i++)
        GameObject.Instantiate(spawner);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
