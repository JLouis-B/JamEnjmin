using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Life : MonoBehaviour {
    private float _life;
    private float _maxwidth;
    private float _baseheight;
    private float _maxlife;
	// Use this for initialization
	void Start () {
        _maxwidth = GetComponent<RectTransform>().rect.width;
        _baseheight = GetComponent<RectTransform>().rect.height;
        _maxlife = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>()._hp;
        _life = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>()._hp;
	}
	
	// Update is called once per frame
	void Update () {
        _life = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>()._hp;
        GetComponent<RectTransform>().sizeDelta = new Vector2(_maxwidth*(_life/_maxlife),_baseheight);
	}
}
