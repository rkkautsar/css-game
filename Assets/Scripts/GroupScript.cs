﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class GroupScript : MonoBehaviour {

    [Serializable]
    public class Count
    {
        public int maximum;
        public int minimum;

        public Count(int min, int max)
        {
            this.maximum = max;
            this.minimum = min;
        }
    }

    public GameObject emptyTable;
    public Transform groupCanvas;
	public int numberOfGroup;
    public Count intervalBoundary = new Count(5, 10);
    public int numberOfTable = 6;
    public GameObject[] groups;
    public GameObject[] groupPrefabs;
    public Group[] groupInstances;
    public Boolean[] isInstantiated;
    public Boolean[] isOccupied;
    public Vector3[] tablePositions;

    // get other script
    public GameController gameControllerScript;

    void initializeGroup(int index)
    {
        // randomize group attribute
        int position = Random.Range(0, tablePositions.Length);
        float startTime = Random.Range(0, gameControllerScript.maxTimePerLevel);
		float interval = Random.Range(intervalBoundary.minimum, intervalBoundary.maximum);

        // randomize affectedcourse

        int courseIndex = Random.Range(1, gameControllerScript.courseList.Count) - 1;
        Course affectedCourse = gameControllerScript.courseList[courseIndex];

        float incrementRate = Random.Range(-3.0f, 5.0f);

		int prefabType;

		if (incrementRate < 0) {
			prefabType = Random.Range (7, 9);
		} else if (affectedCourse.getCode () == "DDP" || affectedCourse.getCode () == "PSD") {
			prefabType = Random.Range (0, 2);
		} else {
			prefabType = Random.Range (3, 6);
		}

        // instantiate group
        this.groupInstances[index] = new Group(position, startTime, interval, prefabType, affectedCourse, incrementRate);
        this.isInstantiated[index] = false;
    }

    void setLevel(int level)
    {
        if (level == 1)
        {
            tablePositions[0] = new Vector3(-6f, 6f, 0f);
            tablePositions[1] = new Vector3(-6f, 0f, 0f);
            tablePositions[2] = new Vector3(-6f, -6f, 0f);
            tablePositions[3] = new Vector3(6f, 6f, 0f);
            tablePositions[4] = new Vector3(6f, 0f, 0f);
            tablePositions[5] = new Vector3(6f, -6f, 0f);
        }
    }

    // Use this for initialization
    void Start () {
        this.groups = new GameObject[numberOfGroup];
        this.groupInstances = new Group[numberOfGroup];
        this.isInstantiated = new Boolean[numberOfGroup];

        // start other script, need variable defined there
        gameControllerScript.Start();

        setLevel(gameControllerScript.currentLevel);

        // initialize fixed table
        for (int i = 0; i < numberOfTable; i++)
        {
            GameObject g = Instantiate(emptyTable, tablePositions[i], Quaternion.identity);
            g.transform.SetParent(this.groupCanvas);
            this.isOccupied[i] = false;
        }

        for (int i = 0; i < numberOfGroup; i++)
        {
            initializeGroup(i);	
        }
	}
	
	// Update is called once per frame
	void Update () {
        float time = Time.time;

        Array.Clear(isOccupied, 0, isOccupied.Length);

        // handle group appear in occupied table
        for(int i = 0; i < numberOfGroup; i++)
        {
            Group g = this.groupInstances[i];
            this.isOccupied[g.getPosition()] |= (this.groups[i] != null);
        }

        for (int i = 0; i < numberOfGroup; i++)
        {
            Group g = this.groupInstances[i];
            if (time > g.getStartTime() && !this.isInstantiated[i] && !this.isOccupied[g.getPosition()]) 
            {
                GameObject group = Instantiate(groupPrefabs[g.getPrefabType()], tablePositions[g.getPosition()], Quaternion.identity);

                group.GetComponent<Group>().setGroup(g.getPosition(), g.getStartTime(), g.getInterval(), g.getPrefabType(), g.getCourse(), g.getIncrementRate());
                group.GetComponent<Group>().incrementRateText.gameObject.SetActive(false);
                group.transform.SetParent(this.groupCanvas);

                Destroy(group, g.getInterval());

                this.groups[i] = group;
                this.isInstantiated[i] = true;
                this.isOccupied[g.getPosition()] = true;
            }
        }
	}
}
