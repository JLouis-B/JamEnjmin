using UnityEngine;
using System.Collections;

public class musiqueLoop : MonoBehaviour {

	public AudioClip _loop;

	AudioSource _audio;

	void Start () {
		_audio = GetComponent<AudioSource> ();
	}
	
	void Update ()
	{
		if (!_audio.isPlaying)
		{
			_audio.clip = _loop;
			_audio.Play();
		}
	}
}
