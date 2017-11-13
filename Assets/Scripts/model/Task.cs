using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
	public string title;
	public float weight;
	public float startWeight;
	public double score;
	public double startTime;
	public double endTime;
	public double progress;
	public bool isVisible = false;
	public Slider slider;

	IEnumerator countd = null;

	float speed = 1f;

	public Task (string title_, float weight_, double startTime_, double endTime_)
	{
		title = title_;
		weight = weight_;
		startTime = startTime_;
		endTime = endTime_;
	}

	public Task ()
	{

	}

	public void setValues (string title_, float weight_, double startTime_, double endTime_)
	{
		title = title_;
		weight = weight_;
		startTime = startTime_;
		startWeight = weight_;
		endTime = endTime_;
		slider = GameObject.Find ("Slider").GetComponent<Slider> ();
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
		Destroy (gameObject);
	}

	IEnumerator Countdown ()
	{
		slider.value = (weight/startWeight);
		while (weight > 0) {
			yield return new WaitForSeconds (1f);
			Debug.Log (weight);
			weight -= speed;
			slider.value = (weight / startWeight);
		}
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
