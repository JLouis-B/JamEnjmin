using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
    public float baseforce;
    public Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        baseforce = 5;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerpos = (player.GetComponent<Transform>().position - rb.transform.position);
        if (GetComponent<Rigidbody2D>().position.x<playerpos.x+20 || GetComponent<Rigidbody2D>().position.x > playerpos.x - 20)
        {
            //MoveToPlayer();
            MoveToPlayerVelocity();
        }
        StartCoroutine(MoveRandom());
	}
    void MoveToPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerpos = (player.GetComponent<Transform>().position - rb.transform.position);
        playerpos.Set(playerpos.x, playerpos.y - 5, playerpos.z);
        // Moving towards the player
        int rand = Random.Range(-2,2);
        rb.AddForce(playerpos.normalized*rand);
    }
    IEnumerator MoveRandom()
    {
        yield return new WaitForSeconds(0.1f);
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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerpos = (player.GetComponent<Transform>().position - rb.transform.position);
            playerpos.Set(playerpos.x, playerpos.y - 5, playerpos.z);
            // Moving towards the player
            rb.AddForce(playerpos.normalized);
            rb.velocity.Set(playerpos.x*Random.Range(-2,2),playerpos.y * Random.Range(-2, 2));
            if (rb.velocity.x>1 || rb.velocity.y>1)
        {
            rb.velocity.Set(rb.velocity.x,rb.velocity.y);
        }
    }
}
