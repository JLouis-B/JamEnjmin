using UnityEngine;
using System.Collections;

public class PowerMakeLove : MonoBehaviour {
    public GameObject spawned;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void MakeLove()
    {
        GameObject[] CrsObjs = GameObject.FindGameObjectsWithTag("CRS");
        foreach (GameObject crs in CrsObjs)
        {
            Vector3 v = crs.transform.position;
            Destroy(crs);
            GameObject.Instantiate(spawned, v, new Quaternion());
        }
    }
}
