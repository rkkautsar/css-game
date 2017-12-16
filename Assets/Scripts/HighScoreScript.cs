using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreScript : MonoBehaviour {

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

	public static List<string> getHighscore() {
		List<string> highscore = new List<string> ();
		for (int i = 1; i <= numOfScores; i++) {
			highscore.Add (PlayerPrefs.GetString (getPrefKey (i)));
		}
		return highscore;
	}

    static string getPrefKey(int index)
    {
        return prefKey + index;
    }

    public static void updateHighScore(string name, double score)
    {
        string newHighScore = name + " " + score;
        for (int i = 1; i <= numOfScores; i++)
        {
            string currentHighScore = PlayerPrefs.GetString(getPrefKey(i));
			print (currentHighScore);
			if (currentHighScore.Length < 2)
				currentHighScore = "COMP 0.0";

            float newScore = float.Parse(newHighScore.Split(' ')[1]);
            float currentScore = float.Parse(currentHighScore.Split(' ')[1]);

			if (newScore - currentScore > 1e-9) {
				PlayerPrefs.SetString (getPrefKey (i), newHighScore);

				// to update next high score
				newHighScore = currentHighScore;
			} else {
				PlayerPrefs.SetString (getPrefKey (i), currentHighScore);
			}
        }
        PlayerPrefs.Save();
    }
}
