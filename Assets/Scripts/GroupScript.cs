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

    public GameObject groupImage;
    public Transform groupCanvas;
	public int levelTime = 300;
	public int numberOfGroup = 999;
	public int maxInterval = 10;
    public GameObject[] groups;
    public Group[] groupInstances;
    public Boolean[] isInstantiated;
    public Count gridRangeX;
    public Count gridRangeY;

    void initializeGroup(int index)
    {
        Vector3 position = randomVector3();
        float startTime = Random.Range(0, levelTime);
		float interval = Random.Range(0, maxInterval);

        this.groupInstances[index] = new Group("Anjing" + index, position, startTime, interval);
        this.isInstantiated[index] = false;
    }

    // Use this for initialization
    void Start () {
        this.gridRangeX = new Count(0, 800);
        this.gridRangeY = new Count(0, 320);
        this.groups = new GameObject[numberOfGroup];
        this.groupInstances = new Group[numberOfGroup];
        this.isInstantiated = new Boolean[numberOfGroup];

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
                GameObject group = Instantiate(groupImage, g.getPosition(), Quaternion.identity);

                group.GetComponent<Group>().setGroup(g.getName(), g.getPosition(), g.getStartTime(), g.getInterval());
                group.transform.SetParent(this.groupCanvas);

                Destroy(group, g.getInterval());

                this.groups[i] = group;
                this.isInstantiated[i] = true;
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
