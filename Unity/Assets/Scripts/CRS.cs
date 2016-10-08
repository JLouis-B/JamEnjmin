using UnityEngine;
using System.Collections;

public class CRS : MonoBehaviour
{
	public float speed = 1f;

	private Rigidbody2D _rigidbody = null;

	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody2D> ();
	}
	
	void Update ()
	{
		_rigidbody.velocity = new Vector2 (0f, speed);
	}
}
