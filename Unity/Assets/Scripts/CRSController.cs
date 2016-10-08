using UnityEngine;
using System.Collections;

public class CRSController : MonoBehaviour
{
	public float _speed = 1f;
	public float _attackDistance = 1f;

	private Rigidbody2D _rigidbody = null;

	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody2D> ();
	}
	
	void Update ()
	{
		GameObject target = null;
		float bestTargetDist = 1000000f;

		GameObject[] publicObjs = GameObject.FindGameObjectsWithTag ("Public");
		foreach (GameObject p in publicObjs)
		{
			float distance = Vector3.Distance (transform.position, p.transform.position);
			if (distance < _attackDistance && distance < bestTargetDist && p.GetComponent<PublicController>()._hp > 0)
			{
				target = p;
				bestTargetDist = distance;
			}
		}

		if (target != null)
		{
			Vector3 direction = target.transform.position - transform.position;
			direction.z = 0;
			direction.Normalize ();
			direction *= _speed;
			_rigidbody.velocity = direction;
		}
		else
		{
			_rigidbody.velocity = new Vector2 (0f, _speed);
		}

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Public") {
			coll.gameObject.GetComponent<PublicController> ().Attack (GetComponent<Collider2D>());
		}
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Public") {
			coll.gameObject.GetComponent<PublicController> ().Attack (GetComponent<Collider2D>());
		}
	}
}


