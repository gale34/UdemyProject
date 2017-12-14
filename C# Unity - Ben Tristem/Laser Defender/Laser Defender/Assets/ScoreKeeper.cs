using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    
    public static int score;

    private Text myText;

    public void Scorepoints(int points)
    {
        score += points;
        myText.text = score.ToString();
    }

    public static void ResetScore()
    {
        score = 0;
    }

	void Start () {
        myText = GetComponent<Text>();
	}
}
