using UnityEngine;
using System.Collections;

public class CRSController : MonoBehaviour
{
	public float _speed = 1f;
	public float _attackDistance = 1f;
	public bool _hp = true;
	public float _animSpeed = 20;

	private Rigidbody2D _rigidbody = null;
	private Animator _anim = null;
	private SpriteRenderer _sp = null;
	private Vector3 _lastPos;
	private bool _inTrigger = false;

	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody2D> ();
		_anim = GetComponent<Animator> ();
		_sp = GetComponent<SpriteRenderer> ();
	}

	void FixedUpdate()
	{
		Vector3 movement = transform.position - _lastPos;

		_sp.flipX = (movement.x < 0);

		_anim.SetFloat ("Speed", movement.magnitude * _animSpeed);
		_lastPos = transform.position;

		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);
	}

	void Update ()
	{
		if (_hp) {
			GameObject target = null;
			float bestTargetDist = 1000000f;

			GameObject[] publicObjs = GameObject.FindGameObjectsWithTag ("Public");
			foreach (GameObject p in publicObjs) {
				Vector3 distanceVect = transform.position - p.transform.position;
				distanceVect.z = 0;
				float distance = distanceVect.magnitude;
				if (distance < _attackDistance && distance < bestTargetDist && p.GetComponent<PublicController> ()._hp > 0) {
					target = p;
					bestTargetDist = distance;
				}
			}

			if (target != null) {
				Vector3 direction = target.transform.position - transform.position;
				direction.z = 0;
				direction.Normalize ();
				direction *= _speed;
				_rigidbody.velocity = direction;
			} else if (!_inTrigger) {
				_rigidbody.velocity = new Vector2 (0f, _speed);
			} else {
				_rigidbody.velocity = (GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position).normalized * _speed;
			}
		} else {
			_rigidbody.velocity = (transform.position - GameObject.FindGameObjectWithTag ("Scene").transform.position).normalized;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Public") {
			coll.gameObject.GetComponent<PublicController> ().Attack (GetComponent<Collider2D> ());
		}

		string tag = coll.gameObject.tag;
		if (tag == "Public" || tag == "Player")
			_anim.SetBool ("Attack", true);
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Public") {
			coll.gameObject.GetComponent<PublicController> ().Attack (GetComponent<Collider2D>());
		}

		if (tag == "Public" || tag == "Player")
			_anim.SetBool ("Attack", true);
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		_anim.SetBool ("Attack", false);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Scene")
			_inTrigger = true;
	}
}


