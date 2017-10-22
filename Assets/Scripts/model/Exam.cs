using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exam {
	public string title;
	public double weight;
	public double score;
	public DateTime startDatetime;
	public DateTime endDatetime;
	public double progress;

	public Exam(string title, double weight, DateTime startDatetime, DateTime endDateTime) {
		this.title = title;
		this.weight = weight;
		this.startDatetime = startDatetime;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
