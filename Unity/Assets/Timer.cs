using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	private Text _timer = null;

	void Start ()
	{
		_timer = GetComponent<Text> ();
	}
	
	void Update ()
	{
		_timer.text = "Temps : " + (int)Time.timeSinceLevelLoad;
	}
}
