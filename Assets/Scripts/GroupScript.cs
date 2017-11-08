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
	public int maxInterval = 10;
    public int numberOfTable = 6;
    public GameObject[] groups;
    public GameObject[] groupPrefabs;
    public Group[] groupInstances;
    public Boolean[] isInstantiated;
    public Count gridRangeX;
    public Count gridRangeY;
    public Vector3[] tablePositions = {
        new Vector3(-6f, 6f, 0f),
        new Vector3(-6f, 0f, 0f),
        new Vector3(-6f, -6f, 0f),
        new Vector3(6f, 6f, 0f),
        new Vector3(6f, 0f, 0f),
        new Vector3(6f, -6f, 0f),
    };

    void initializeGroup(int index)
    {
        //Vector3 position = randomVector3();
        Vector3 position = new Vector3(0f, 0f, 0f);
        float startTime = Random.Range(0, levelTime);
		float interval = Random.Range(0, maxInterval);
        int prefabType = Random.Range(0, groupPrefabs.Length);

        this.groupInstances[index] = new Group("Anjing" + index, position, startTime, interval, prefabType);
        this.isInstantiated[index] = false;
    }

    // Use this for initialization
    void Start () {
        this.gridRangeX = new Count(120, 800);
        this.gridRangeY = new Count(0, 320);
        this.groups = new GameObject[numberOfGroup];
        this.groupInstances = new Group[numberOfGroup];
        this.isInstantiated = new Boolean[numberOfGroup];

        // initialize fixed table
        for (int i = 0; i < numberOfTable; i++)
        {
            GameObject g = Instantiate(emptyTable, tablePositions[i], Quaternion.identity);
            g.transform.SetParent(this.groupCanvas);
        }

        for (int i = 0; i < numberOfGroup; i++)
        {
            initializeGroup(i);	
        } 
	}
	
	// Update is called once per frame
	void Update () {
        float time = Time.time;
        for (int i = 0; i < numberOfGroup; i++)
        {
            Group g = this.groupInstances[i];
            if (time > g.getStartTime() && !this.isInstantiated[i])
            {
                //GameObject group = Instantiate(groupPrefabs[g.getPrefabType()], g.getPosition(), Quaternion.identity);

                //group.GetComponent<Group>().setGroup(g.getName(), g.getPosition(), g.getStartTime(), g.getInterval(), g.getPrefabType());
                //group.transform.SetParent(this.groupCanvas);

                //Destroy(group, g.getInterval());

                //this.groups[i] = group;
                //this.isInstantiated[i] = true;
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
