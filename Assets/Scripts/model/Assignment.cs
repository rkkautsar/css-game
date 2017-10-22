using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Assignment : MonoBehaviour {
	public string title;
	public double weight;
	public double score;
	public DateTime startDatetime;
	public DateTime endDatetime;
	public double progress;

	public Assignment(string title, double weight, DateTime startDatetime, DateTime endDateTime) {
		this.title = title;
		this.weight = weight;
		this.startDatetime = startDatetime;
		this.endDatetime = endDatetime;
	}

	public Assignment() {

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
