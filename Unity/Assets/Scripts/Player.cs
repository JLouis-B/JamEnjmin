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
        if(Input.GetKey("left"))
        {
            rb.velocity = Vector2.left*velocity;
        }
        else if(Input.GetKey("right"))
        {
            rb.velocity = Vector2.right * velocity;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
	}
}
