using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PowerPogo : MonoBehaviour
{
	public float _radius = 1f;
	public int _nbSpec = 1;

	private bool _readyToClick = false;

	AudioSource _audio;
	public AudioClip _buttonSound;
	public AudioClip _powerSound;

	void Start()
	{
		_audio = GetComponent<AudioSource> ();
	}

	List<GameObject> getPublic()
	{
		GameObject[] publicObjs = GameObject.FindGameObjectsWithTag ("Public");
		List<GameObject> publics = new List<GameObject>();
		foreach (GameObject p in publicObjs)
			if (p.GetComponent<PublicController> ()._hp > 0)
				publics.Add (p);

		return publics;
	}

	List<GameObject> getPublicZone(Vector3 pos)
	{
		var dict = new Dictionary<float, GameObject> ();

		GameObject[] publicObjs = GameObject.FindGameObjectsWithTag ("Public");
		foreach (GameObject p in publicObjs)
			if (p.GetComponent<PublicController> ()._hp > 0)
			{
				float distance = Vector3.Distance (pos, p.transform.position);
				dict.Add (distance, p);
			}

		var list = dict.Keys.ToList();
		list.Sort();

		List<GameObject> publics = new List<GameObject>();
		foreach(var l in list)
			publics.Add (dict [l]);

		return publics;
	}

	public void Pogo()
	{
		_audio.clip = _buttonSound;
		_audio.Play ();

		_readyToClick = true;
	}



	void Update ()
	{
		if (Input.GetMouseButtonDown (0) && _readyToClick)
		{
			_audio.clip = _powerSound;
			_audio.Play ();

			List<GameObject> publicObjs = getPublic();
			if (publicObjs.Count <= 0)
				return;

			Vector3 worldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			worldPos.z = 0;

			int nbTarget = 0;
			GameObject[] CrsObjs = GameObject.FindGameObjectsWithTag ("CRS");
            int eliminated = 0;
			foreach (GameObject crs in CrsObjs)
			{
				Vector3 distanceVect = worldPos - crs.transform.position;
				distanceVect.z = 0;
				float distance = distanceVect.magnitude;
				bool hp = crs.GetComponent<CRSController> ()._hp;

				if (hp && distance < _radius)
				{
                    crs.GetComponent<CRSController> ()._hp = false;
					nbTarget++;
                    eliminated++;
				}
			}
            //Scoooooore !
            GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoringSystem>().eliminateCRS(eliminated);

            if (nbTarget > 0)
			{
				var specs = getPublicZone (worldPos);
				for (int i = 0; i < _nbSpec; ++i)
				{
					specs [i].GetComponent<PublicController> ()._hp = -1;
					//specs [i].GetComponent<Collider2D> ().enabled = false;
				}
			}
				
			_readyToClick = false;
		}
	}
}
