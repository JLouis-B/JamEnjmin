﻿using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
    public float baseforce;
    public Rigidbody2D rb;
    private GameObject player;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        MoveRandom();
        Vector3 playerpos = (player.GetComponent<Transform>().position - rb.transform.position);
        MoveToPlayerVelocity();
	}
    void MoveRandom()
    {
        // Moving randomly
        int rand = Random.Range(0, 8);
        switch (rand)
        {
            case 0:
                rb.AddForce(-transform.up * baseforce);
                break;
            case 1:
                rb.AddForce(transform.up * baseforce);
                break;
            case 2:
                rb.AddForce(transform.right * baseforce);
                break;
            case 3:
                rb.AddForce(-transform.right * baseforce);
                break;
            default:
                break;
        }
    }
    void MoveToPlayerVelocity()
    {
        Vector3 playerpos = (player.GetComponent<Transform>().position - rb.transform.position);
            playerpos.Set(playerpos.x, playerpos.y - 2, playerpos.z);
            // Moving towards the player
            rb.AddForce(playerpos.normalized);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "CRS")
            coll.gameObject.GetComponent<CRSController>()._hp = false;

    }

}
