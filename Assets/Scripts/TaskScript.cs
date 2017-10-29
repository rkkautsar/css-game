using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

	public List<Assignment> activeTasks;

	private Count gridRangeX;
	private Count gridRangeY;
	private int numVisible = 0;

	// Use this for initialization
	void Start () {
		activeTasks = new List<Assignment> {
			// judul tugas, bobot (%), start time (detik), end time (detik)
			new Assignment("Tugas 1 DDP", 20, 3, 10),
			new Assignment("Tugas 2 DDP", 20, 7, 12)
		};
		/**
		for (int i = 0; i < activeTasks.Count; i++) {
			GameObject button = Instantiate (taskUI, transform);
			button.GetComponent<Assignment> ().setValues (activeTasks[i].title, activeTasks[i].weight, activeTasks[i].startTime, activeTasks[i].endTime);
			
		}
		**/
	}
	
	// Update is called once per frame
	void Update () {
		double time = Time.time;
		foreach(Assignment task in activeTasks) {
			//print ("now=" + time.ToString() + ", s=" + task.startTime.ToString() + ", e=" + task.endTime.ToString());
			if (time > task.startTime && time < task.endTime && !task.isVisible) {
				numVisible++;
				GameObject taskObj = Instantiate (taskUI, transform);
				taskObj.GetComponent<Assignment> ().setValues (task.title, task.weight, task.startTime, task.endTime);
				taskObj.GetComponent<Text> ().text = task.title;
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
			child.GetComponent<Assignment> ().StopCountdown ();
		}
	}

	Vector3 getPosition(int idx) {
		return new Vector3 (80, 200 - (20 * idx));
	}
}
