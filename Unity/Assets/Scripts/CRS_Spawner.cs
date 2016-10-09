using UnityEngine;
using System.Collections;


[System.Serializable]
public class Wave
{
	public float spawnTime = 1f;
	public float fulltime = 1f;
	public int nbSpawns = 3;
	public float speedSpawn = 1f;
}


public class CRS_Spawner : MonoBehaviour
{
	public GameObject _spawnObject = null;
	public Wave[] _waves;
	public float _width;
	public float _y;

	public int _minCRSperWave = 1;
	public int _maxCRSperWave = 1;

	public float _timeAdd = 1f;

	private float _timer = 0f;
	private int _waveIndex = 0;

	Wave _newWave = new Wave();

	IEnumerator spawnWithDelay()
	{
		float delay = Random.Range (0, _newWave.spawnTime);
		yield return new WaitForSeconds (delay);



		int nbCRS = Random.Range (_minCRSperWave, _maxCRSperWave + 1);
		float x = Random.Range (-_width, _width);
		float y = _y;
		for (int j = 0; j < nbCRS; ++j)
		{
			GameObject crs = GameObject.Instantiate (_spawnObject);

			crs.transform.position = new Vector3 (x, y, crs.transform.position.z);

			float offset = Random.Range (-0.01f, 0.01f);
			float offset2 = Random.Range (-0.01f, 0.01f);
			crs.transform.Translate(new Vector3(offset, offset2, 0));

		}
	}

	void Start()
	{
		_newWave = _waves [0];
		spawnWave ();
	}

	void spawnWave()
	{
        GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoringSystem>().incrementWave();
        if (_waveIndex < _waves.Length)
			_newWave = _waves [_waveIndex];
		else {
			_newWave = _waves [_waves.Length - 1];
			_newWave.nbSpawns += (_waveIndex - _waves.Length);
			_newWave.spawnTime += (_waveIndex - _waves.Length) * _timeAdd;
			_newWave.fulltime += (_waveIndex - _waves.Length) * _timeAdd;
		}

		for (int i = 0; i < _newWave.nbSpawns; ++i)
		{
			StartCoroutine ("spawnWithDelay");
		}
	}

	void Update ()
	{
		_timer += Time.deltaTime;
		if (_timer > _newWave.fulltime)
		{
			_timer = 0;
			_waveIndex++;
			spawnWave();
		}
	}
}
