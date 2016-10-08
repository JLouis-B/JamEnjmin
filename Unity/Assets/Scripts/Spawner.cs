using UnityEngine;
using System.Collections;

public enum SpawnMode
{
	SpawnRandom,
	SpawnPoints
}



[System.Serializable]
public class Wave
{
	public float spawnTime = 1f;
	public float fulltime = 1f;
	public int nbSpawns = 3;
	public float speedSpawn = 1f;
}


public class Spawner : MonoBehaviour
{
	public GameObject _spawnObject = null;
	public Wave[] _waves;
	public float _width;
	public float _y;

	public int _minCRSperWave = 1;
	public int _maxCRSperWave = 1;

	private float _timer = 0f;
	private int _waveIndex = 0;

	IEnumerator spawnWithDelay()
	{
		float delay = Random.Range (0, _waves[_waveIndex].spawnTime);
		yield return new WaitForSeconds (delay);



		int nbCRS = Random.Range (_minCRSperWave, _maxCRSperWave + 1);
		float x = Random.Range (-_width, _width);
		float y = _y;
		for (int j = 0; j < nbCRS; ++j) {
			GameObject crs = GameObject.Instantiate (_spawnObject);

			crs.transform.position = new Vector3 (x, y, crs.transform.position.z);

			float offset = Random.Range (-0.01f, 0.01f);
			float offset2 = Random.Range (-0.01f, 0.01f);
			crs.transform.Translate(new Vector3(offset, offset2, 0));

		}
	}

	void Start()
	{
		spawnWave ();
	}

	void spawnWave()
	{
		Wave newWave = _waves[_waveIndex];
		for (int i = 0; i < newWave.nbSpawns; ++i)
		{
			StartCoroutine ("spawnWithDelay");
		}
	}

	void Update ()
	{
		_timer += Time.deltaTime;
		if (_waveIndex < _waves.Length && _timer > _waves[_waveIndex].fulltime)
		{
			_timer = 0;
			_waveIndex++;
			if (_waveIndex < _waves.Length)
				spawnWave();
		}
	}
}
