using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : MonoBehaviour {

    const string prefKey = "highscore_";
    const int numOfScores = 10;

	// Use this for initialization
	void Start () {
		for (int i = 1; i <= numOfScores; i++)
        {
            if (PlayerPrefs.HasKey(getPrefKey(i)))
            {
                PlayerPrefs.SetString(getPrefKey(i), "COMP 0.0");
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    string getPrefKey(int index)
    {
        return prefKey + index;
    }

    public void updateHighScore(string name, float score)
    {
        string newHighScore = name + " " + score;
        for (int i = 1; i <= numOfScores; i++)
        {
            string currentHighScore = PlayerPrefs.GetString(getPrefKey(i));

            float newScore = float.Parse(newHighScore.Split(' ')[1]);
            float currentScore = float.Parse(currentHighScore.Split(' ')[1]);

            if (newScore - currentScore > 1e-9)
            {
                PlayerPrefs.SetString(getPrefKey(i), newHighScore);

                // to update next high score
                newHighScore = currentHighScore;
            }
        }
        PlayerPrefs.Save();
    }
}
