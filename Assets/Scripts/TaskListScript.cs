using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;


public class TaskListScript : MonoBehaviour {

	// public List<Assignment> listOfTask = new ArrayList<>();
	public GameObject buttonPrefab;
	public int n = 0;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < n; i++) {
			GameObject button = Instantiate (buttonPrefab, transform);
			button.GetComponent<Assignment> ().Init ("Tugas ", 5.0);
			button.GetComponentsInChildren<Text> () [0].text = "Task " + i;
		}
	}

	public void StopAll ()
	{
		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild (i);
			child.GetComponent<Assignment> ().StopCountdown ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void KillChild (GameObject target)
	{
		Debug.Log (target);
		DestroyImmediate (target, true);
	}
}
