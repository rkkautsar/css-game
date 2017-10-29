using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course {
	string title;
	int credits;
	double grade;
	string letterGrade;

	public List<Exam> exams;
	public List<Assignment> assignments;

	public Course(string title_, int credits_, List<Exam> exams_, List<Assignment> assignments_) {
		title = title_;
		credits = credits_;
		exams = exams_;
		assignments = assignments_;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
