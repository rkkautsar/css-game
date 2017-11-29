using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningCamera : MonoBehaviour {

	public float mouseSensitivity = 0.1f;
	private Vector3 lastPosition;

	// Use this for initialization
	void Start () {
		
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			lastPosition = Input.mousePosition;
		}

		if (Input.GetMouseButton(0)) {
			Vector3 delta = Input.mousePosition - lastPosition;
			transform.Translate(-delta.x * mouseSensitivity, -delta.y * mouseSensitivity, 0.0f);
			lastPosition = Input.mousePosition;
		}
	}
}
