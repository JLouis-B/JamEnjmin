using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerMakeLove : MonoBehaviour {

    private float previousTime;

    private float coolDown;

    public int remaining;

	public Animator _anim;

    public GameObject[] spawned;

	AudioSource _audio;

    // Use this for initialization
    void Start () {
		_audio = GetComponent<AudioSource> ();
    }
	
	// Update is called once per frame
	void Update () {
        GetComponentsInChildren<Text>()[0].text = getCooldown();
    }
    public void MakeLove()
    {
        if (remaining>0)
        {
			//_anim.SetTrigger ("Play");
			_audio.Play ();
            remaining--;
            previousTime = Time.time;
            GameObject[] CrsObjs = GameObject.FindGameObjectsWithTag("CRS");
            foreach (GameObject crs in CrsObjs)
            {
                Vector3 v = crs.transform.position;
                Destroy(crs);
                GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoringSystem>().convertCRS(1);
                GameObject go = (GameObject)GameObject.Instantiate(spawned[(int)Random.Range(0, spawned.Length)], v, new Quaternion());
                go.GetComponent<Rigidbody2D>().velocity = (new Vector2(Random.Range(-2f, 2f), 1));
                go.GetComponent<Rigidbody2D>().drag = 1;
            }
        }
    }
    public string getCooldown()
    {
        return "Make Love\n"+remaining;
    }
}
