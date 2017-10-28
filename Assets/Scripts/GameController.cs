using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Text timerText;

	// Use this for initialization
	void Start () {
		timerText.text = Time.time.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		timerText.text = Time.time.ToString();
	}
}
