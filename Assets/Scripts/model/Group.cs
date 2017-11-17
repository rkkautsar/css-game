using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Group : MonoBehaviour {
    public int prefabType;
    public int position;
    public float startTime;
    public float interval;
    public CourseList courses;
    public List<float> incrementRates;

    public GameObject go;

    public Group() {}

    public Group(int _position, float _startTime, float _interval, int _prefabType)
    {
        position = _position;
        startTime = _startTime;
        interval = _interval;
        prefabType = _prefabType;
    }

    public void setGroup(int _position, float _startTime, float _interval, int _prefabType)
    {
        position = _position;
        startTime = _startTime;
        interval = _interval;
        prefabType = _prefabType;
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
}
