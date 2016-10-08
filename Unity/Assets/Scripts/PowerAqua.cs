using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerAqua : MonoBehaviour {
    public ParticleSystem pe;
    public float radius = 1f;

    private bool _readyToClick = false;

    public GameObject spawned;

    void Start()
    {
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
        _readyToClick = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _readyToClick)
        {
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
                    CrowdManager cm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CrowdManager>();
                    GameObject.Instantiate(spawned,v,new Quaternion());
                }
            }
        }
    }
}
