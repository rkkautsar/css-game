using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour {

	public Text IPText;

	// Use this for initialization
	void Start () {
        //Debug.Log("Haha");
		IPText.text = "Your IP: " + AppData.currentIP;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
