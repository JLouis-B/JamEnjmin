using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerMakeLove : MonoBehaviour {
    public GameObject spawned;

    public int tempsChargement;

    private float previousTime;

    private float coolDown;
    // Use this for initialization
    void Start () {
        previousTime = Time.time - tempsChargement;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponentsInChildren<Text>()[0].text = getCooldown();
        coolDown = Time.time - previousTime;
    }
    public void MakeLove()
    {
        if (Time.time - previousTime > tempsChargement)
        {
            coolDown = tempsChargement;
            previousTime = Time.time;
            GameObject[] CrsObjs = GameObject.FindGameObjectsWithTag("CRS");
            foreach (GameObject crs in CrsObjs)
            {
                Vector3 v = crs.transform.position;
                Destroy(crs);
                GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoringSystem>().convertCRS(1);
                GameObject.Instantiate(spawned, v, new Quaternion());
            }
        }
    }
    public string getCooldown()
    {
        if (coolDown < tempsChargement)
        {
            return "Make Love\n" + Mathf.FloorToInt(tempsChargement - coolDown).ToString();
        }
        else
        {
            return "Make Love\nReady";
        }
    }
}
