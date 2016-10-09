using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour {
    public string textBefore;
    public int score;
    public int pointsPerSeconds;
    public int pointsByConvertedCRS;
    public int pointsByEliminatedCRS;
    private int currentWave;
    public int timepoints;

	// Use this for initialization
	void Start () {
        StartCoroutine(counting());
        currentWave = 0;
        timepoints = 0;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "Highscore : "+ PlayerPrefs.GetInt("highscore", 0) +"\n"+ textBefore + score.ToString()+"\nWave : "+currentWave;
	}
    IEnumerator counting()
    {
        yield return new WaitForSeconds(1);
        timepoints+=pointsPerSeconds;
        StartCoroutine(counting());
    }
    public void eliminateCRS(int number)
    {
        for(int i=1;i<number+1;i++)
        {
            if(i<4)
            {
                score += pointsByEliminatedCRS;
            }
            else
            {
                score += pointsByEliminatedCRS *i-2;
            }
        }
    }
    public void convertCRS(int number)
    {
        for (int i = 1; i < number + 1; i++)
        {
            if (i < 4)
            {
                score += pointsByConvertedCRS;
            }
            else
            {
                score += pointsByConvertedCRS * i - 2;
            }
        }
    }
    public void OnDestroy()
    {
        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
        if (score > oldHighscore)
            PlayerPrefs.SetInt("highscore", score);
    }
    public void incrementWave()
    {
        currentWave += 1;
    }
    public string finalScore()
    {
        return "Time bonus : "+timepoints+"\nCRS points : "+score+"\nTotal : "+(timepoints+score);
    }
}
