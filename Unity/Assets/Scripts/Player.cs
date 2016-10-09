using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject _ecran = null;
	public Text _scoreBase;
	public Text _scoreTemps;
	public Text _scoreTotal;
    public Text _scoreWave;

	public float _hp = 1000f;


    public float _speed = 1f;
	public float _maxAngle = 1f;

	public float _offsetY = 0;
	public float _radius = 1f;
	public float _scaleX;

	private float _angle = 0;
	private Rigidbody2D _rb;
	private float _movement = 0;

	public static bool GamePhase = true;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//_angle += _movement;
		//newPos ();
	}

	void newPos()
	{
		_angle = Mathf.Clamp (_angle, -_maxAngle, _maxAngle);

		float angle = _angle - (3.14f / 2f);


		float x = Mathf.Cos (angle) * _radius * _scaleX;
		float y = Mathf.Sin (angle) * _radius + _offsetY;
		transform.position = new Vector3 (x, y, 0);
	}

    public void GoLeft()
    {
		_movement -= _speed;


        //rb.velocity = Vector2.left * velocity;
    }
    public void GoRight()
    {
		_movement += _speed;


        //rb.velocity = Vector2.right * velocity;
    }

	public void Stop()
	{
		_movement = 0;
	}

    public void ResetVelocity()
    {
        _rb.velocity = Vector2.zero;
    }
		
	public void Attack()
	{
		_hp--;
		if (_hp <= 0 && GamePhase)
		{
			GamePhase = false;
			_ecran.SetActive (true);

			int baseScore = GameObject.FindGameObjectWithTag ("ScoreSystem").GetComponent<ScoringSystem> ().score;
			int timeScore = GameObject.FindGameObjectWithTag ("ScoreSystem").GetComponent<ScoringSystem> ().timepoints;
            int wave = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoringSystem>().currentWave;

            _scoreBase.text = "Score : " + baseScore.ToString();
			_scoreTemps.text = "Bonus temps : " + timeScore.ToString();
			_scoreTotal.text = "Total : " + (baseScore + timeScore).ToString();
            _scoreWave.text = "Wave : " + wave;
		}
	}
		
}
