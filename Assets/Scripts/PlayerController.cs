using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 5.0f;
	public Text timerText;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		timerText.text = Time.time.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		timerText.text = Time.time.ToString();

		if (Mathf.Abs(Input.GetAxisRaw ("Horizontal")) > 0) {
			Vector3 vector = new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f);
			transform.Translate (vector);
		}

		if (Mathf.Abs(Input.GetAxisRaw ("Vertical")) > 0) {
			Vector3 vector = new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f);
			transform.Translate (vector);
		}

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
	}
}
