using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Group : MonoBehaviour {
    public int prefabType;
    public int position;
    public float startTime;
    public float interval;
    public Course course;
    public float incrementRate;

    public Text incrementRateText;

    public GameController gameControllerScript;

	public TaskScript taskScript;

    public Group() {}

    public Group(int position_, float startTime_, float interval_, int prefabType_, Course course_, float incrementRate_)
    {
        position = position_;
        startTime = startTime_;
        interval = interval_;
        prefabType = prefabType_;
        course = course_;
        incrementRate = incrementRate_;
    }

    public void setGroup(int position_, float startTime_, float interval_, int prefabType_, Course course_, float incrementRate_)
    {
        position = position_;
        startTime = startTime_;
        interval = interval_;
        prefabType = prefabType_;
        course = course_;
        incrementRate = incrementRate_;
    }


	// Use this for initialization
	void Start () {
		taskScript = (TaskScript) FindObjectOfType (typeof(TaskScript));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float getStartTime()
    {
        return startTime;
    }

    public float getInterval()
    {
        return interval;
    }

    public String getName()
    {
        return name;
    }

    public int getPosition()
    {
        return position;
    }

    public void OnClick()
    {
		// sound effect
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
    }

    public int getPrefabType()
    {
        return prefabType;
    }

    public Course getCourse()
    {
        return course;
    }

    public float getIncrementRate()
    {
        return incrementRate;
    }

	void OnTriggerEnter2D(Collider2D other) {
        float affectedIncrementRate = 0.0f;
		if (taskScript.taskGameObject != null && course != null)
        {
			for (int i = 0; i < taskScript.taskGameObject.Length; i++)
           {
				if (taskScript.taskGameObject [i] == null)
					continue;
				Task currentTask = taskScript.taskGameObject[i].GetComponent<Task>();
                string taskTitle = currentTask.getTitle();
                //Debug.Log(course.getCode() + " " + taskTitle);

                if (taskTitle.Contains(course.getCode()))
                {
                    affectedIncrementRate = incrementRate;
					currentTask.updateSpeed(incrementRate);
                }
            }
        }

        incrementRateText.text = affectedIncrementRate.ToString("F2");
        if (affectedIncrementRate > 0)
        {
            incrementRateText.color = Color.green;
        }
        else if (affectedIncrementRate < 0)
        {
            incrementRateText.color = Color.red;
        }
        else
        {
            incrementRateText.color = Color.black;
        }
        
        StartBlinking();

        // start dialog animation
		GameObject dialog;
		if (affectedIncrementRate > 0) {
			dialog = GameObject.Find ("Dialog");
		} else {
			dialog = GameObject.Find ("DialogBad");
		}

        dialog.transform.localScale = new Vector3(0.1819f, 0.1879f, 1);
        dialog.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y + 3, -1);
	}

	void OnTriggerExit2D(Collider2D other) {
        // reset speed on all active tasks
		if (taskScript.taskGameObject != null && course != null)
        {
			for (int i = 0; i < taskScript.taskGameObject.Length; i++)
            {

				if (taskScript.taskGameObject [i] == null)
					continue;
				Task currentTask = taskScript.taskGameObject[i].GetComponent<Task>();
                string taskTitle = currentTask.getTitle();

                if (taskTitle.Contains(course.getCode()))
                {
                    gameControllerScript.activeTasks[i].updateSpeed(-incrementRate);
                }
            }
        }

        StopBlinking();

        // hide dialog animation
        GameObject.Find("Dialog").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("DialogBad").transform.localScale = new Vector3(0, 0, 0);
	}

    IEnumerator Blink()
    {
        Boolean isVisible = false;
        while (true)
        {
            switch (isVisible)
            {
                case true:
                    isVisible = !isVisible;
                    incrementRateText.gameObject.SetActive(false);
                    yield return new WaitForSeconds(0.5f);
                    break;
                case false:
                    isVisible = !isVisible;
                    incrementRateText.gameObject.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }
    
    void StartBlinking()
    {
        StopBlinking();
        StartCoroutine("Blink");
    }

    void StopBlinking()
    {
        incrementRateText.gameObject.SetActive(false);
        StopAllCoroutines();
    }
}
