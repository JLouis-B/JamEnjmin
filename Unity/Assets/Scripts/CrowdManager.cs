using UnityEngine;
using System.Collections;

public class CrowdManager : MonoBehaviour {

    public GameObject spawner;
    public int crowdNumber;
    public ArrayList groupies;

	// Use this for initialization
	void Start () {
        crowdNumber = 5;
        // at start spawning the crowd
        for (int i =0;i<crowdNumber;i++)
        GameObject.Instantiate(spawner);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //Tombelaaaaaaaa !
    public void Tombela(int numberOfGroupie)
    {
        for(int i = 0;i<numberOfGroupie;i++)
        {
            groupies.Add(GameObject.Instantiate(spawner));
        }
    }
    public void GroupieLost(int numberofgroupielost)
    {
        groupies.RemoveRange(0,numberofgroupielost);
    }
}
