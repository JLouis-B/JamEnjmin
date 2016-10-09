using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PowerAqua : MonoBehaviour {
    public float radius = 1f;

    private bool _readyToClick = false;

    public GameObject spawned;

    public int tempsChargement;

    private float previousTime;

    private float coolDown;

    void Start()
    {
        previousTime = Time.time - tempsChargement;
    }

    List<GameObject> getPublic()
    {
        GameObject[] publicObjs = GameObject.FindGameObjectsWithTag("Public");
        List<GameObject> publics = new List<GameObject>();
        foreach (GameObject p in publicObjs)
            if (p.GetComponent<PublicController>()._hp > 0)
                publics.Add(p);

        return publics;
    }

    public void Aqua()
    {
        if((Time.time - previousTime > tempsChargement))
        {
            _readyToClick = true;
        }
    }

    void Update()
    {
        GetComponentsInChildren<Text>()[0].text = getCooldown();
        coolDown = Time.time - previousTime;
        if (Input.GetMouseButtonDown(0) && _readyToClick&& (Time.time - previousTime > tempsChargement))
        {
            coolDown = tempsChargement;
            previousTime = Time.time;
            _readyToClick = false;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;

            GameObject[] CrsObjs = GameObject.FindGameObjectsWithTag("CRS");
            foreach (GameObject crs in CrsObjs)
            {
                float distance = Vector3.Distance(worldPos, crs.transform.position);
                bool hp = crs.GetComponent<CRSController>()._hp;
                if (hp && distance < radius)
                {
                    Vector3 v = crs.transform.position;
					Destroy(crs);
                    //Scoooooore !;
                    GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoringSystem>().convertCRS();
                    GameObject.Instantiate(spawned,v,new Quaternion());
                }
            }
        }
    }
    public string getCooldown()
    {
        if (coolDown<tempsChargement)
        {
            return "Aqua\n" + Mathf.FloorToInt(tempsChargement - coolDown).ToString();
        }
        else
        {
            return "Aqua\nReady";
        }
    }
}
