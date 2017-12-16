using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreSceneController : MonoBehaviour {

	public List<Text> PositionTexts;

	// Use this for initialization
	void Start () {
		List<string> highscore = HighScoreScript.getHighscore ();
		foreach (string s in highscore) {
			print (s);
		}
		for (int i = 0; i < PositionTexts.Count; i++) {
			PositionTexts [i].text = highscore [i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
