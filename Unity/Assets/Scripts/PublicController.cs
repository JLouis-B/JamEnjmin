using UnityEngine;
using System.Collections;

public class PublicController : MonoBehaviour {

	private GameObject _scene = null;
	public float _hp = 1f;

	private Rigidbody2D _rigidbody = null;

	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody2D> ();
		_scene = GameObject.FindGameObjectWithTag ("Scene");

		Debug.Log ("HP = " + _hp);
	}
	
	void Update ()
	{
		if (!Player.GamePhase)
			return;
		
		if (_hp <= 0)
		{
			_rigidbody.velocity = (transform.position - _scene.transform.position).normalized;
            gameObject.layer = 8;
        }
	}

	public void Attack(Collider2D crs)
	{
		float distance = Vector3.Distance (_scene.transform.position, transform.position);
		_hp -= distance;


		if (_hp < 0) {
            //Destroy (gameObject);
            //Physics2D.IgnoreCollision (GetComponent<Collider2D> (), crs);
		}
	}
}
