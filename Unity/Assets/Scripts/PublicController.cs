using UnityEngine;
using System.Collections;

public class PublicController : MonoBehaviour {

	public GameObject _scene = null;
	public float _hp = 1f;

	private Rigidbody2D _rigidbody = null;

	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody2D> ();
	}
	
	void Update ()
	{
		if (_hp <= 0)
		{
			_rigidbody.velocity = (transform.position - GameObject.FindGameObjectWithTag ("Scene").transform.position).normalized;
		}
	}

	public void Attack(Collider2D crs)
	{
		float distance = Vector3.Distance (_scene.transform.position, transform.position);
		_hp -= distance;


		if (_hp < 0) {
			//Destroy (gameObject);
			Physics2D.IgnoreCollision (GetComponent<Collider2D> (), crs);

		}
	}
}
