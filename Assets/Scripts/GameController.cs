using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Text timerText;
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
		timerText.text = "Time: " + Time.timeSinceLevelLoad.ToString();
		IPText.text = "IP: " + getIP().ToString();
		InvokeRepeating ("changeIP", 1f, 1f);

	}
	
	// Update is called once per frame
	void Update () {
		timerText.text = "Time: " + Time.timeSinceLevelLoad.ToString();
		timerUI.value = (maxTimePerLevel - Time.timeSinceLevelLoad) / maxTimePerLevel;
        if (Time.timeSinceLevelLoad > maxTimePerLevel)
        {
            levelEnded();
			//Debug.Log ("udah kelar oi");
        }
	}

	void changeIP() {
		IPText.text = "IP: " + getIP ().ToString ("F1");
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
        //Debug.Log(ip);
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
        if (level == 1)
        {
            List<Task> tasks1 = new List<Task> {
			    // judul tugas, bobot (%), start time (detik), end time (detik)
			    new Task("Tugas 1 - DDP", 5, 0, 5),
                new Task("Kuis 1 - DDP", 10, 30, 550),
                new Task("UTS - DDP", 25, 60, 75),
                new Task("Tugas 2 - DDP", 15, 78, 105),
                new Task("Kuis 2  - DDP", 15, 105, 125),
                new Task("UAS - DDP", 30, 130, 180)
            };

            List<Task> tasks2 = new List<Task> {
                new Task("Worksheet 1 - CAL", 5, 0, 30),
                new Task("Kuis 1 - CAL", 10, 30, 55),
                new Task("UTS - CAL", 30, 60, 75),
                new Task("Worksheet 2 - CAL", 5, 75, 105),
                new Task("Kuis 2  - CAL", 20, 105, 125),
                new Task("UAS - CAL", 30, 130, 180)
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
                new Task("Worksheet 1 - ALG", 10, 0, 30),
                new Task("Worksheet 2 - ALG", 10, 30, 60),
                new Task("UTS - ALG", 25, 130, 150),
                new Task("Worksheet 3 - ALG - DDP", 10, 75, 105),
                new Task("Kuis - ALG", 15, 105, 125),
                new Task("UAS - ALG", 30, 130, 180)
            };

            List<Task> tasks5 = new List<Task> {
                new Task("Praktikum 1 - PSD", 10, 0, 30),
                new Task("Praktikum 2 - PSD", 10, 30, 60),
                new Task("UTS - PSD", 20, 65, 75),
                new Task("Praktikum 3 - PSD", 10, 75, 105),
                new Task("Tugas Akhir  - PSD", 20, 105, 120),
                new Task("UAS - PSD", 30, 130, 180)
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
