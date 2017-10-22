using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course : MonoBehaviour {
	string title;
	int credits;
	double grade;
	string letterGrade;

	public Exam[] exams;
	public Assignment[] assignments;

	public Course(string title, int credits) {
		this.title = title;
		this.credits = credits;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
