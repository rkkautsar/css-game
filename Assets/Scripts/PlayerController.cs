using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text mouseText;

	public float moveSpeed = 5.0f;
	private Animator anim;
	private RectTransform rt;
	public Sprite player;
	private Vector3 destination;
	private bool isMouseMoving;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rt = GetComponent<RectTransform> ();
		isMouseMoving = false;
	}

	public void MovePlayer(){
		destination = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		destination.z = 0;
		isMouseMoving = true;
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetMouseButtonUp (0)) {
//			destination = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//			destination.z = 0;
//			isMouseMoving = true;
//		}

		if (!isMouseMoving) {
//			if (Mathf.Abs(Input.GetAxisRaw ("Horizontal")) > 0) {
//				Vector3 vector = new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f);
//				transform.Translate (vector);
//			}
//
//			if (Mathf.Abs(Input.GetAxisRaw ("Vertical")) > 0) {
//				Vector3 vector = new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f);
//				transform.Translate (vector);
//			}
//
//			anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
//			anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
	
		} else {
			Vector3 source = rt.position;
			Vector3 delta = destination - source;
		
			if (Mathf.Abs (delta.x) > 1 || Mathf.Abs (delta.y) > 1) {
				Vector3 vector = new Vector3 (delta.x / 2 * moveSpeed * Time.deltaTime, delta.y / 2 * moveSpeed * Time.deltaTime, 0f);
				transform.Translate (vector);
				anim.SetFloat ("MoveX", delta.x);
				anim.SetFloat ("MoveY", delta.y);
			} else {
				isMouseMoving = false;
				anim.SetFloat ("MoveX", 0f);
				anim.SetFloat ("MoveY", 0f);
			}
		}

	}
}
