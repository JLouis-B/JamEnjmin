using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float _speed = 1f;
	public float _maxAngle = 1f;

	public float _offsetY = 0;
	public float _radius = 1f;
	public float _scaleX;

	private float _angle = 0;
	private Rigidbody2D _rb;
	private float _movement = 0;


	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_angle += _movement;
		newPos ();
	}

	void newPos()
	{
		_angle = Mathf.Clamp (_angle, -_maxAngle, _maxAngle);

		float angle = _angle - (3.14f / 2f);


		float x = Mathf.Cos (angle) * _radius * _scaleX;
		float y = Mathf.Sin (angle) * _radius + _offsetY;
		transform.position = new Vector3 (x, y, 0);
	}

    public void GoLeft()
    {
		_movement -= _speed;


        //rb.velocity = Vector2.left * velocity;
    }
    public void GoRight()
    {
		_movement += _speed;


        //rb.velocity = Vector2.right * velocity;
    }

	public void Stop()
	{
		_movement = 0;
	}

    public void ResetVelocity()
    {
        Debug.Log("test");
        _rb.velocity = Vector2.zero;
    }
}
