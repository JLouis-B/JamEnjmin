using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Rigidbody2D rb;
    public float velocity;
	// Use this for initialization
	void Start () {
        velocity = 2;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

	}
    public void GoLeft()
    {
        rb.velocity = Vector2.left * velocity;
    }
    public void GoRight()
    {
        rb.velocity = Vector2.right * velocity;
    }
    public void ResetVelocity()
    {
        Debug.Log("test");
        rb.velocity = Vector2.zero;
    }
}
