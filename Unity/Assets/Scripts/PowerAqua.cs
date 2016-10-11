using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PowerAqua : MonoBehaviour {
    public float radius = 1f;

    private bool _readyToClick = false;


    public int tempsChargement;

    private float previousTime;

    private float coolDown;

    public GameObject[] spawned;

	AudioSource _audio;
	public AudioClip _buttonSound;
	public AudioClip _powerSound;

    void Start()
    {
		_audio = GetComponent<AudioSource> ();
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
        if ((Time.time - previousTime > tempsChargement))
        {
			_audio.clip = _buttonSound;
			_audio.Play ();

            _readyToClick = true;
        }
    }

    void Update()
    {
        GetComponentsInChildren<Text>()[0].text = getCooldown();
        coolDown = Time.time - previousTime;
        if (Input.GetMouseButtonDown(0) && _readyToClick&& (Time.time - previousTime > tempsChargement))
        {
			_audio.clip = _powerSound;
			_audio.Play ();

            coolDown = tempsChargement;
            previousTime = Time.time;
            _readyToClick = false;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;

            GameObject[] CrsObjs = GameObject.FindGameObjectsWithTag("CRS");
            int converted = 0;
            foreach (GameObject crs in CrsObjs)
            {
				Vector3 distanceVect = worldPos - crs.transform.position;
				distanceVect.z = 0;
				float distance = distanceVect.magnitude;
                bool hp = crs.GetComponent<CRSController>()._hp;
                if (hp && distance < radius)
                {
                    Vector3 v = crs.transform.position;
					Destroy(crs);
                    converted++;
                    GameObject go = (GameObject)GameObject.Instantiate(spawned[(int)Random.Range(0,spawned.Length)],v,new Quaternion());
                    go.GetComponent<Rigidbody2D>().velocity=(new Vector2(Random.Range(-2f, 2f),1));
                    go.GetComponent<Rigidbody2D>().drag = 1;
                }
            }
            //Scoooooore !;
            GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoringSystem>().convertCRS(converted);
        }
    }
    public string getCooldown()
    {
        if (coolDown<tempsChargement)
        {
            return Mathf.FloorToInt(tempsChargement - coolDown).ToString();
        }
        else
        {
            return "";
        }
    }
}
