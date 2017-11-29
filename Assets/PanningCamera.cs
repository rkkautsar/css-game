using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningCamera : MonoBehaviour {

	public float mouseSensitivity = 0.1f;
	private Vector3 lastPosition;
	public float ScrollSpeed = 15f;
	public float ScrollEdge = 0.01f;

	private int HorizontalScroll = 1;
	private int VerticalScroll = 1;
	private int DiagonalScroll = 1;

	public float PanSpeed = 10f;

	Vector2 ZoomRange = new Vector2(-5,5);
	float CurrentZoom = 0f;
	float ZoomZpeed = 1f;
	float ZoomRotation = 1;

	private Vector3 InitPos;
	private Vector3 InitRotation;

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


		if ( Input.GetKey("w")
//			|| Input.mousePosition.x >= Screen.height * (1f - ScrollEdge)
		)
		{
			transform.Translate(Vector3.up * Time.deltaTime * ScrollSpeed, Space.World);
		}
		else if ( Input.GetKey("s")
//			|| Input.mousePosition.y <= Screen.height * ScrollEdge
		)
		{
			transform.Translate(Vector3.up * Time.deltaTime * -ScrollSpeed, Space.World);
		}

		if ( Input.GetKey("d")
//			|| Input.mousePosition.x >= Screen.width * (1f - ScrollEdge)
		)
		{
			transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed, Space.World);
		}
		else if ( Input.GetKey("a")
//			|| Input.mousePosition.x <= Screen.width * ScrollEdge
		)
		{
			transform.Translate(Vector3.right * Time.deltaTime * -ScrollSpeed, Space.World);
		}
	}
}
