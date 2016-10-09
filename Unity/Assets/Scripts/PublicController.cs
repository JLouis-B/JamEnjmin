using UnityEngine;
using System.Collections;

public class PublicController : MonoBehaviour {

	private GameObject _scene = null;
	public float _hp = 1f;

	private Rigidbody2D _rigidbody = null;

	private Vector3 _lastPos;
	private float _lastHp;
	private Animator _anim = null;

	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody2D> ();
		_scene = GameObject.FindGameObjectWithTag ("Scene");
		_anim = GetComponent<Animator> ();

		Debug.Log ("HP = " + _hp);
	}
	
	void Update ()
	{
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);
		if (!Player.GamePhase)
			return;
		
		if (_hp <= 0)
		{
			_rigidbody.velocity = (transform.position - _scene.transform.position).normalized;
            gameObject.layer = 8;
        }

		Vector3 movement = transform.position - _lastPos;
		_anim.SetBool ("face", (movement.y < 0));
		_anim.SetBool ("matraque", (_lastHp != _hp));
		_lastPos = transform.position;
		_lastHp = _hp;
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
