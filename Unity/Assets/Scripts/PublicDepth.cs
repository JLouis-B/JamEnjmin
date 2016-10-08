using UnityEngine;
using System.Collections;

public class PublicDepth : MonoBehaviour
{
	void Update ()
	{
		GameObject scene = GameObject.FindGameObjectWithTag ("Scene");
		float distance = Vector3.Distance (transform.position, scene.transform.position);
		transform.position = new Vector3 (transform.position.x, transform.position.y, -distance);
	}
}
