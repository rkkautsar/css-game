using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Text timerText;
	public List<Course> courseList;

	// Use this for initialization
	void Start () {
		List<Task> tasks1 = new List<Task> {
			// judul tugas, bobot (%), start time (detik), end time (detik)
			new Task("Tugas 1 - DDP", 5, 0, 60),
			new Task("Kuis 1 - DDP", 10, 60, 110),
			new Task("UTS - DDP", 25, 120, 150),
			new Task("Tugas 2 - DDP", 15, 155, 210),
			new Task("Kuis 2  - DDP", 15, 210, 250),
			new Task("UAS - DDP", 30, 260, 300)
		};

		List<Task> tasks2 = new List<Task> {
			new Task("Worksheet 1 - CAL", 5, 0, 60),
			new Task("Kuis 1 - CAL", 10, 60, 110),
			new Task("UTS - CAL", 30, 120, 150),
			new Task("Worksheet 2 - CAL", 5, 150, 210),
			new Task("Kuis 2  - CAL", 20, 210, 250),
			new Task("UAS - CAL", 30, 260, 300)
		};

		List<Task> tasks3 = new List<Task> {
			new Task("Tugas - DISC", 10, 0, 50),
			new Task("Ujian 1 - DISC", 15, 50, 100),
			new Task("UTS - DISC", 20, 110, 140),
			new Task("Ujian 2 - DISC", 15, 155, 210),
			new Task("Ujian 3 - DISC", 15, 210, 250),
			new Task("UAS - DISC", 25, 260, 300)
		};

		List<Task> tasks4 = new List<Task> {
			new Task("Worksheet 1 - ALG", 10, 0, 60),
			new Task("Worksheet 2 - ALG", 10, 60, 120),
			new Task("UTS - ALG", 25, 130, 150),
			new Task("Worksheet 3 - ALG - DDP", 10, 150, 210),
			new Task("Kuis - ALG", 15, 210, 250),
			new Task("UAS - ALG", 30, 260, 300)
		};

		List<Task> tasks5 = new List<Task> {
			new Task("Praktikum 1 - PSD", 10, 0, 60),
			new Task("Praktikum 2 - PSD", 10, 60, 120),
			new Task("UTS - PSD", 20, 130, 150),
			new Task("Praktikum 3 - PSD", 10, 150, 210),
			new Task("Tugas Akhir  - PSD", 20, 210, 240),
			new Task("UAS - PSD", 30, 260, 300)
		};

		List<Course> courseList = new List<Course> {
			new Course ("Dasar Dasar Pemrograman", "DDP", 6, tasks1),
			new Course ("Calculus", "CAL", 3, tasks2),
			new Course ("Discrete", "DISC", 3, tasks3),
			new Course ("Algebra", "ALG", 3, tasks4),
			new Course ("Pengantar Sistem Digital", "PSD", 5, tasks5)
		};

		timerText.text = "Time: " + Time.time.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		timerText.text = "Time: " + Time.time.ToString();
	}
}
