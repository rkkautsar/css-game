using System.Collections;
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
	public int levelTime = 300;
	public int numberOfGroup = 50;
    public int minInterval = 10;
	public int maxInterval = 20;
    public int numberOfTable = 6;
    public GameObject[] groups;
    public GameObject[] groupPrefabs;
    public Group[] groupInstances;
    public Boolean[] isInstantiated;
    public Boolean[] isOccupied;
    public Count gridRangeX;
    public Count gridRangeY;
    public Vector3[] tablePositions;
    public int level;

    void initializeGroup(int index)
    {
        //Vector3 position = randomVector3();
        int position = Random.Range(0, tablePositions.Length);
        float startTime = Random.Range(0, levelTime);
		float interval = Random.Range(minInterval, maxInterval);
        int prefabType = Random.Range(0, groupPrefabs.Length);

        this.groupInstances[index] = new Group(position, startTime, interval, prefabType);
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
        this.gridRangeX = new Count(120, 800);
        this.gridRangeY = new Count(0, 320);
        this.groups = new GameObject[numberOfGroup];
        this.groupInstances = new Group[numberOfGroup];
        this.isInstantiated = new Boolean[numberOfGroup];

        setLevel(level);

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

                group.GetComponent<Group>().setGroup(g.getPosition(), g.getStartTime(), g.getInterval(), g.getPrefabType());
                group.transform.SetParent(this.groupCanvas);

                Destroy(group, g.getInterval());

                this.groups[i] = group;
                this.isInstantiated[i] = true;
                this.isOccupied[g.getPosition()] = true;
            }
        }
	}

    Vector3 randomVector3()
    {
        float x = Random.Range(this.gridRangeX.minimum, this.gridRangeX.maximum);
        float y = Random.Range(this.gridRangeY.minimum, this.gridRangeY.maximum);

        Vector3 pos = new Vector3(x, y, 0);

        return pos;
    }
}
