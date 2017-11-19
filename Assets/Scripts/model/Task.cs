using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
	public string title;
	public float weight = 0;
	public float startWeight;
	public double score;
	public double startTime;
	public double endTime;
	public double progress;
	public bool isVisible = false;
	public bool isStarted = false;
	public Slider slider;
	public bool onGoing;

	IEnumerator countd = null;

	float speed = 1f;

	public Task (string title_, float startWeight_, double startTime_, double endTime_)
	{
		title = title_;
		weight = startWeight_;
		startWeight = startWeight_;
		startTime = startTime_;
		endTime = endTime_;
		onGoing = false;
	}

	public Task ()
	{

	}

	public void setValues (string title_, float startWeight_, double startTime_, double endTime_, Slider slider_)
	{
		title = title_;
		startWeight = startWeight_;
		weight = startWeight_;
		startTime = startTime_;
		endTime = endTime_;
		slider = slider_;
		slider.value = 1f;
		onGoing = false;
	}

    public string getTitle()
    {
        return title;
    }

    public void updateSpeed(float incrementRate)
    {
        speed += incrementRate;
    }

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void Kill ()
	{
		onGoing = false;
		Destroy (gameObject);
	}

	IEnumerator Countdown ()
	{
		slider.value = (weight/startWeight);
		onGoing = true;
		while (weight > 0) {
			yield return new WaitForSeconds (1f);
			Debug.Log (weight + " " + speed);
			weight -= speed;
			if (weight < 0) {
				weight = 0;
			}
			slider.value = (weight / startWeight);
		}
		slider.value = 0.1f;
		yield return new WaitForSeconds (1f);
		Kill ();
	}

	public void OnClick ()
	{
		transform.parent.GetComponent<TaskScript> ().StopAll ();
		StartCountdown ();
	}

	public void StartCountdown ()
	{
		countd = Countdown ();
		StartCoroutine (countd);
	}

	public void StopCountdown ()
	{
		if (countd != null)
			StopCoroutine (countd);
	}

}
