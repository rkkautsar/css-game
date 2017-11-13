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
			new Task("Tugas Pemrograman 1 DDP", 20, 50, 100),
			new Task("Tugas Pemrograman 2 DDP", 20, 100, 250),
			new Task("UTS DDP", 30, 120, 150),
			new Task("UAS DDP", 30, 240, 270)
		};

		List<Task> tasks2 = new List<Task> {
			new Task("Tutorial 1 SDA", 15, 30, 60),
			new Task("Tutorial 2 SDA", 15, 180, 210),
			new Task("UTS SDA", 35, 150, 180),
			new Task("UAS SDA", 35, 260, 290)
		};
			
		List<Course> courseList = new List<Course> {
			new Course ("DDP 1", 4, tasks1),
			new Course ("SDA 2", 4, tasks2)
		};

		timerText.text = "Time: " + Time.time.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		timerText.text = "Time: " + Time.time.ToString();
	}
}
