using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course {
	public string title;
	public string code;
	public int credits;
	public double grade;
	public string letterGrade;

	public List<Task> tasks;

	public Course(string title_, string code_, int credits_, List<Task> tasks_) {
		title = title_;
		code = code_;
		credits = credits_;
		tasks = tasks_;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string getTitle()
    {
        return title;
    }

    public string getCode()
    {
        return code;
    }

    public int getCredits()
    {
        return credits;
    }
}
