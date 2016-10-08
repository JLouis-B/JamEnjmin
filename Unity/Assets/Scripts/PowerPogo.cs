using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerPogo : MonoBehaviour
{
	public float _radius = 1f;

	private bool _readyToClick = false;

	List<GameObject> getPublic()
	{
		GameObject[] publicObjs = GameObject.FindGameObjectsWithTag ("Public");
		List<GameObject> publics = new List<GameObject>();
		foreach (GameObject p in publicObjs)
			if (p.GetComponent<PublicController>()._hp > 0)
				publics.Add (p);

		return publics;
	}

	public void Pogo()
	{
		_readyToClick = true;
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0) && _readyToClick)
		{
			_readyToClick = false;

			List<GameObject> publicObjs = getPublic();
			if (publicObjs.Count <= 0)
				return;

			Vector3 worldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			worldPos.z = 0;

			int nbTarget = 0;
			GameObject[] CrsObjs = GameObject.FindGameObjectsWithTag ("CRS");
			foreach (GameObject crs in CrsObjs)
			{
				float distance = Vector3.Distance (worldPos, crs.transform.position);
				bool hp = crs.GetComponent<CRSController> ()._hp;
				if (hp && distance < _radius)
				{
					crs.GetComponent<CRSController> ()._hp = false;
					nbTarget++;
				}
			}
				
			nbTarget++;
			for (int i = 0; i < nbTarget; ++i)
			{
				if (publicObjs.Count - i < 1)
					return;

				int id = Random.Range (0, publicObjs.Count - i);
				GameObject p = publicObjs[id];
				p.GetComponent<PublicController>()._hp = -1;
				p.GetComponent<Collider2D> ().enabled = false;
			}
		}
	}
}
