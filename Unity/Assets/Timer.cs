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
		if (!Player.GamePhase)
			return;

		_timer.text = ((int)Time.timeSinceLevelLoad).ToString();
	}
}
