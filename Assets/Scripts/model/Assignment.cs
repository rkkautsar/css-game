
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Assignment : MonoBehaviour {
	public string title;
	public double weight;
	public double score; 
	public double progress;
	// public DateTime startDatetime;
	// public DateTime endDatetime;
	public GameObject go;

	IEnumerator countd = null;

	float speed = 1f;

	public void Init(string title, double weight) {
		this.title = title;
		this.weight = weight;
	}

	public void OnClick ()
	{
		transform.parent.GetComponent<TaskListScript> ().StopAll ();
		StartCountdown ();
	}

	public void StartCountdown()
	{
		countd = Countdown ();
		StartCoroutine (countd);
	}

	public void StopCountdown ()
	{
		if (countd != null)
			StopCoroutine (countd);
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

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Kill()
	{
		Destroy (gameObject);
	}
}
