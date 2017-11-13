using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void exitOnClick()
	{
		Application.Quit();
	}

	public void loadMainScene() {
		SceneManager.LoadScene ("MainScene");
	}
}
