using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{

	public float speed = 1f;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.up;
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameObject.transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed));
		Debug.Log ("Pos = " + transform.position.x);
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		
		Debug.Log ("COLLISION avec " + coll.collider.gameObject.name);
	}

	public void onClick()
	{
		Debug.Log ("Je clic");
	}
}
