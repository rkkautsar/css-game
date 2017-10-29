using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Assignment : MonoBehaviour{
	public string title;
	public double weight;
	public double score;
	public double startTime;
	public double endTime;
	public double progress;
	public bool isVisible = false;

	public Assignment(string title_, double weight_, double startTime_, double endTime_) {
		title = title_;
		weight = weight_;
		startTime = startTime_;
		endTime = endTime_;
	}

	public Assignment() {

	}

	public void setValues(string title_, double weight_, double startTime_, double endTime_) {
		title = title_;
		weight = weight_;
		startTime = startTime_;
		endTime = endTime_;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

}
