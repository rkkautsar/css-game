using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Text timerText;
	public List<Course> courseList;

	// Use this for initialization
	void Start () {
		List<Assignment> assignments1 = new List<Assignment> {
			// judul tugas, bobot (%), start time (detik), end time (detik)
			new Assignment("Tugas Pemrograman 1 DDP", 20, 50, 100),
			new Assignment("Tugas Pemrograman 2 DDP", 20, 100, 250)
		};

		List<Assignment> assignments2 = new List<Assignment> {
			new Assignment("Tutorial 1 SDA", 15, 30, 60),
			new Assignment("Tutorial 2 SDA", 15, 180, 210)
		};

		List<Exam> exams1 = new List<Exam> {
			// judul ujian, bobot (%), start time (detik), end time (detik)
			new Exam("UTS DDP", 30, 120, 150),
			new Exam("UAS DDP", 30, 240, 270)
		};

		List<Exam> exams2 = new List<Exam> {
			new Exam("UTS SDA", 35, 150, 180),
			new Exam("UAS SDA", 35, 260, 290)
		};
			
		List<Course> courseList = new List<Course> {
			new Course ("DDP 1", 4, exams1, assignments1),
			new Course ("SDA 2", 4, exams2, assignments2)
		};

		timerText.text = Time.time.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		timerText.text = Time.time.ToString();
	}
}
