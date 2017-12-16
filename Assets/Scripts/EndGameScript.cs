using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour {

	public Text IPText;
	public InputField nameInput;
	public Button submitButton;

	// Use this for initialization
	void Start () {
        //Debug.Log("Haha");
		IPText.text = "Your IP: " + AppData.currentIP.ToString("F2");
	}

	public void submitHighscore() {
		HighScoreScript.updateHighScore (nameInput.text, AppData.currentIP);
		submitButton.enabled = false;
		nameInput.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
