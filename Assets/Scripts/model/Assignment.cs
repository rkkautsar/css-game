using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Assignment : MonoBehaviour
{
	public string title;
	public double weight;
	public double score;
	public double startTime;
	public double endTime;
	public double progress;
	public bool isVisible = false;

	IEnumerator countd = null;

	float speed = 1f;

	public Assignment (string title_, double weight_, double startTime_, double endTime_)
	{
		title = title_;
		weight = weight_;
		startTime = startTime_;
		endTime = endTime_;
	}

	public Assignment ()
	{

	}

	public void setValues (string title_, double weight_, double startTime_, double endTime_)
	{
		title = title_;
		weight = weight_;
		startTime = startTime_;
		endTime = endTime_;
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
		while (weight > 0) {
			yield return new WaitForSeconds (1f);
			Debug.Log (weight);
			weight -= speed;
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
