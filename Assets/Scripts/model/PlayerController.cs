using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 5.0f;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
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
