using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Group : MonoBehaviour {
    public string name;
    public int prefabType;
    public int position;
    public float startTime;
    public float interval;
    public String interest;

    public GameObject go;

    public Group() {}

    public Group(String name, int position, float start, float interval, int prefabType)
    {
        this.name = name;
        this.position = position;
        this.startTime = start;
        this.interval = interval;
        //this.interest = interest;
        this.prefabType = prefabType;
    }

    public void setGroup(String name, int position, float start, float interval, int prefabType)
    {
        this.name = name;
        this.position = position;
        this.startTime = start;
        this.interval = interval;
        //this.interest = interest;
        this.prefabType = prefabType;
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float getStartTime()
    {
        return this.startTime;
    }

    public float getInterval()
    {
        return this.interval;
    }

    public String getName()
    {
        return this.name;
    }

    public int getPosition()
    {
        return this.position;
    }

    public void OnClick()
    {
		// sound effect
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
    }

    public int getPrefabType()
    {
        return this.prefabType;
    }
}
