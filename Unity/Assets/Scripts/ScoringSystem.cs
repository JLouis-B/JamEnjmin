using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour {
    public int score;
    public int pointsPerSeconds;
    public int pointsByConvertedCRS;
    public int pointsByEliminatedCRS;

	// Use this for initialization
	void Start () {
        StartCoroutine(counting());
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = score.ToString();
	}
    IEnumerator counting()
    {
        yield return new WaitForSeconds(1);
        score+=pointsPerSeconds;
        StartCoroutine(counting());
    }
    public void eliminateCRS()
    {
        score += pointsByEliminatedCRS;
    }
    public void convertCRS()
    {
        score += pointsByConvertedCRS;
    }
}
