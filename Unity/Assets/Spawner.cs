using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawn;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 50; i++)
			GameObject.Instantiate (spawn);
	}

}
