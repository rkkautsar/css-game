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

	private Count gridRangeX;
	private Count gridRangeY;
	private int numVisible = 0;

    public GameController gameControllerScript;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		double time = Time.time;
		foreach(Task task in gameControllerScript.activeTasks) {
			//print ("now=" + time.ToString() + ", s=" + task.startTime.ToString() + ", e=" + task.endTime.ToString());
			if (time > task.startTime && time < task.endTime && !task.isVisible) {
				numVisible++;
				GameObject taskObj = Instantiate (taskUI, transform);
				taskObj.GetComponent<Task> ().setValues (task.title, task.weight, task.startTime, task.endTime, taskObj.GetComponentInChildren<Slider> ());
				taskObj.GetComponentInChildren <Text> ().text = task.title;
				task.isVisible = true;
			}

			if (time > task.endTime) {
				task.isVisible = false;
				// @TODO kurangin ipnya disini
			}
		}
	}

	public void StopAll ()
	{
		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild (i);
			child.GetComponent<Task> ().onGoing = false;
			child.GetComponent<Task> ().StopCountdown ();
		}
	}

	public void onPlayClick() {
		SceneManager.LoadScene("MainScene");
	}
}
