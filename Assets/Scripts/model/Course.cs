using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course {
	string title;
	int credits;
	double grade;
	string letterGrade;

	public List<Task> tasks;

	public Course(string title_, int credits_, List<Task> tasks_) {
		title = title_;
		credits = credits_;
		tasks = tasks_;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
