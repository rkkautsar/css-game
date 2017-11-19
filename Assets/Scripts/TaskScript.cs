using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;

public class TaskScript : MonoBehaviour {
	
	[Serializable]
	public class Count
	{
		public int maximum;
		public int minimum;

		public Count(int min, int max)
		{
			this.maximum = max;
			this.minimum = min;
		}
	}

	public GameObject taskUI;
	public GameObject visibleTasks;
	public Transform taskCanvas;

	public List<Task> activeTasks;

	private Count gridRangeX;
	private Count gridRangeY;
	private int numVisible = 0;

	// Use this for initialization
	void Start () {
		activeTasks = new List<Task> {
			// judul tugas, bobot (%), start time (detik), end time (detik)
			new Task("Tugas 1 DDP", 10f, 3, 10),
			new Task("Tugas 2 DDP", 5f, 4, 12),

			new Task("Tugas 3 DDP", 10f, 5, 10),
			new Task("Tugas 4 DDP", 5f, 6, 12),

			new Task("Tugas 5 DDP", 10f, 7, 10),
			new Task("Tugas 6 DDP", 5f, 8, 12)
		};
	}
	
	// Update is called once per frame
	void Update () {
		double time = Time.time;
		foreach(Task task in activeTasks) {
			//print ("now=" + time.ToString() + ", s=" + task.startTime.ToString() + ", e=" + task.endTime.ToString());
			if (time > task.startTime && time < task.endTime && !task.isVisible) {
				numVisible++;
				GameObject taskObj = Instantiate (taskUI, transform);
				taskObj.GetComponent<Task> ().setValues (task.title, task.weight, task.startTime, task.endTime);
				taskObj.GetComponentInChildren <Text> ().text = task.title;
				task.isVisible = true;
			}

			if (time > task.endTime) {
				task.isVisible = false;
			}
		}
	}

	public void StopAll ()
	{
		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild (i);
			child.GetComponent<Task> ().StopCountdown ();
		}
	}

	public void onPlayClick() {
		SceneManager.LoadScene("MainScene");
	}
}
