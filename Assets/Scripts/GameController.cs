using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Text IPText;
	public List<Course> courseList;
	public List<Task> activeTasks;
    public int maxTimePerLevel = 180;
    public int currentLevel = 1;
	public int totalSKSLevel = 20;
	public static double currentIP = 4;
	public Slider timerUI;

	// Use this for initialization
	public void Start () {
        setLevel(currentLevel);
		gameObject.SendMessage ("resetPause");
		IPText.text = "IP: " + getIP().ToString();
		InvokeRepeating ("changeIP", 1f, 1f);

	}

	public Transform taskHolder;
	
	// Update is called once per frame
	void Update () {
		timerUI.value = (maxTimePerLevel - Time.timeSinceLevelLoad) / maxTimePerLevel;
        if (Time.timeSinceLevelLoad > maxTimePerLevel)
        {
            levelEnded();
			//Debug.Log ("udah kelar oi");
        }

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if (taskHolder.childCount >= 1) {
				taskHolder.GetChild (0).GetComponent<Task> ().OnClick ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			if (taskHolder.childCount >= 2) {
				taskHolder.GetChild (1).GetComponent<Task> ().OnClick ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			if (taskHolder.childCount >= 3) {
				taskHolder.GetChild (2).GetComponent<Task> ().OnClick ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			if (taskHolder.childCount >= 4) {
				taskHolder.GetChild (3).GetComponent<Task> ().OnClick ();
			}
		}
	}

	void changeIP() {
		IPText.text = "IP: " + getIP ().ToString ("F2");
        //Debug.Log(IPText.text + " hehe");
		// AppData.currentIP = getIP ();
	}

	public double getIP() {
		// IP 4 = all tasks' weight == 0
		//double ip = 4;
		//for (int i = 0; i < courseList.Count; i++) {
			//Course course = courseList [i];
			//List<Task> tasks = course.tasks;
			//double jatah = (course.credits / (double) totalSKSLevel) * 4;
			//for (int j = 0; j < tasks.Count; j++) {
				//Task task = tasks [j];
				//print ("///\n");
				//if (task.endTime < Time.timeSinceLevelLoad && !task.isFinished) {
					//print (task.title + " " + task.isFinished + "\n");
					//double decrement = (task.weight / 100) * jatah;
					//ip -= decrement;
				//}
			//}
		//}

		//print ("IP=" + ip + "\n");
        double totalMutu = 0f;
        int creditsTaken = 0;
        //Debug.Log("=================");
        foreach (Course course in courseList) {
            creditsTaken += course.credits;

            double totalScore = 0f;
            double weightTaken = 0f;

            foreach (Task task in course.tasks)
            {
                // if a task already up
                if (task.isFinished)
                {
                    //Debug.Log(task.title + " >>>>> " + task.startWeight + " " + task.weight);
                    totalScore += (task.startWeight - task.weight);
                    weightTaken += task.startWeight;
                    //Debug.Log(totalScore + " " + weightTaken);
                }
            }

            // if not a single task is end yet, assume it is 4
            if (weightTaken < 1e-9)
            {
                totalMutu += 4f * course.credits;
            }
            else
            {
                double score = totalScore / weightTaken * 100;

                if (score - 85f > 1e-9)
                {
                    totalMutu += 4f * course.credits;
                }
                else if (score - 80f > 1e-9)
                {
                    totalMutu += 3.7f * course.credits;
                }
                else if (score - 75f > 1e-9)
                {
                    totalMutu += 3.3f * course.credits;
                }
                else if (score - 65f > 1e-9)
                {
                    totalMutu += 2.7f * course.credits;
                }
                else if (score - 60f > 1e-9)
                {
                    totalMutu += 2.3f * course.credits;
                }
                else if (score - 55f > 1e-9)
                {
                    totalMutu += 2f * course.credits;
                }
                else if (score - 50f > 1e-9)
                {
                    totalMutu += 1.7f * course.credits;
                }
                else if (score - 40f > 1e-9)
                {
                    totalMutu += 1f * course.credits;
                }
            }
        }

        double ip = (double)totalMutu / (double)creditsTaken;
        //Debug.Log(ip);
        //Debug.Log("========end========");
        return ip;
	}

	public void addActiveTask(Task task) {
		
		activeTasks.Add (task);
	}

	public void removeActiveTask(Task task) {
		activeTasks.Remove (task);
	}

    public void levelEnded()
    {
        double ip = getIP();
        Debug.Log(ip);
        AppData.currentIP = ip;
        // go to other scene

        // check if passed current level
        if ((ip - 2.0) > 1e-9)
        {
            currentLevel++;

            setLevel(currentLevel);			
        }
        else
        {
            setLevel(currentLevel);
        }
        SceneManager.LoadScene("EndScene");
    }

    public void setLevel(int level)
    {
        GameObject.Find("Dialog").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("DialogBad").transform.localScale = new Vector3(0, 0, 0);

        if (level == 1)
        {
            List<Task> tasks1 = new List<Task> {
			    // judul tugas, bobot (%), start time (detik), end time (detik)
			    new Task("Tugas 1 - DDP", 5, 0, 20),
                new Task("UTS - DDP", 7, 30, 60),
                new Task("UAS - DDP", 18, 90, 165),
            };

            List<Task> tasks2 = new List<Task> {
                new Task("Worksheet 1 - CAL", 6, 10, 30),
                new Task("Kuis 1 - CAL", 8, 35, 70),
                new Task("UTS - CAL", 8, 60, 120),
                new Task("UAS - CAL", 8, 130, 170),
            };

            List<Task> tasks3 = new List<Task> {
                new Task("Tugas - DISC", 6, 0, 30),
                new Task("Ujian 1 - DISC", 7, 20, 50),
                new Task("UTS - DISC", 7, 70, 120),
                new Task("Ujian 2 - DISC", 10, 140, 170),
            };

            List<Task> tasks4 = new List<Task> {
                new Task("Worksheet 1 - ALG", 8, 0, 60),
                new Task("Worksheet 2 - ALG", 8, 60, 120),
                new Task("Final Project- ALG", 14, 130, 180),
            };

            List<Task> tasks5 = new List<Task> {
                new Task("Praktikum 1 - PSD", 5, 30, 50),
                new Task("Praktikum 2 - PSD", 5, 60, 80),
                new Task("UTS - PSD", 10, 80, 120),
                new Task("Praktikum 3 - PSD", 10, 120, 160),
            };

            courseList = new List<Course> {
                new Course ("Dasar Dasar Pemrograman", "DDP", 6, tasks1),
                new Course ("Calculus", "CAL", 3, tasks2),
                new Course ("Discrete", "DISC", 3, tasks3),
                new Course ("Algebra", "ALG", 3, tasks4),
                new Course ("Pengantar Sistem Digital", "PSD", 5, tasks5)
            };

            activeTasks = new List<Task>();
            activeTasks.AddRange(tasks1);
            activeTasks.AddRange(tasks2);
            activeTasks.AddRange(tasks3);
            activeTasks.AddRange(tasks4);
            activeTasks.AddRange(tasks5);
        }
    }
}
