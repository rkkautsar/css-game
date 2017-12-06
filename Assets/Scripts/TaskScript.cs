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
    public GameObject[] taskGameObject;

	private Count gridRangeX;
	private Count gridRangeY;
	private int numVisible = 0;

    public GameController gameControllerScript;

    // Use this for initialization
    void Start () {
        taskGameObject = new GameObject[10005];
	}
	
	// Update is called once per frame
	void Update () {
		double time = Time.timeSinceLevelLoad;
        int index = 0;
		foreach(Task task in gameControllerScript.activeTasks) {
			//print ("now=" + time.ToString() + ", s=" + task.startTime.ToString() + ", e=" + task.endTime.ToString());
			if (time > task.startTime && time < task.endTime && !task.isVisible) {
				numVisible++;
				GameObject taskObj = Instantiate (taskUI, transform);
				taskObj.GetComponent<Task> ().setValues (task.title, task.weight, task.startTime, task.endTime, taskObj.GetComponentInChildren<Slider> (), gameControllerScript);
				taskObj.GetComponentInChildren <Text> ().text = task.title;
				task.isVisible = true;
                taskGameObject[index] = taskObj;
			}

			if (time > task.endTime && task.isVisible) {
				task.isVisible = false;
                // @TODO kurangin ipnya disini
                if (taskGameObject[index] == null)
                {
                    continue;
                }
                Task currentTask = taskGameObject[index].GetComponent<Task>();
                foreach (Course course in gameControllerScript.courseList)
                {
                    foreach (Task t in course.tasks)
                    {
                        if (t.title == currentTask.title)
                        {
                            t.weight = currentTask.weight;
                            t.isFinished = true;
                        }
                    }
                }
                Destroy(taskGameObject[index]);
            }

            index++;
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
