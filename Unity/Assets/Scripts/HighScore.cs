using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    GetComponent<Text>().text = "Highscore : "+PlayerPrefs.GetInt("highscore", 0).ToString();
    }
}
