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
    public List<Course> courses;
    public List<float> incrementRates;

    public Text incrementRateText;

    public Group() {}

    public Group(int position_, float startTime_, float interval_, int prefabType_, List<Course> courses_, List<float> incrementRates_)
    {
        position = position_;
        startTime = startTime_;
        interval = interval_;
        prefabType = prefabType_;
        courses = courses_;
        incrementRates = incrementRates_;
    }

    public void setGroup(int position_, float startTime_, float interval_, int prefabType_, List<Course> courses_, List<float> incrementRates_)
    {
        position = position_;
        startTime = startTime_;
        interval = interval_;
        prefabType = prefabType_;
        courses = courses_;
        incrementRates = incrementRates_;
    }


	// Use this for initialization
	void Start () {
		
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

    public List<Course> getCourses()
    {
        return courses;
    }

    public List<float> getIncrementRates()
    {
        return incrementRates;
    }

	void OnTriggerEnter2D(Collider2D other) {
        // update text
        incrementRateText.text = "+2.00";
        incrementRateText.color = Color.green;

        startBlinking();
	}

	void OnTriggerExit2D(Collider2D other) {
        stopBlinking();
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
    
    void startBlinking()
    {
        stopBlinking();
        StartCoroutine("Blink");
    }

    void stopBlinking()
    {
        incrementRateText.gameObject.SetActive(false);
        StopAllCoroutines();
    }
}
