using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateObject : MonoBehaviour {
	[SerializeField]
	private float _rotSpeed = 2000;
	public bool RotationY = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDrag() {
		var rotX = Input.GetAxis("Mouse X") * _rotSpeed * Mathf.Deg2Rad * Time.timeScale;
		var rotY = Input.GetAxis("Mouse Y") * _rotSpeed * Mathf.Deg2Rad * Time.timeScale;

		if (Input.GetKey(KeyCode.LeftShift)) return;
		if (RotationY && Input.GetKey(KeyCode.LeftControl))
			transform.Rotate(Vector3.right * rotY, Space.World);
		else if (Input.GetKey(KeyCode.LeftAlt))
			transform.Rotate(Vector3.back * rotX, Space.World);
		else
			transform.Rotate(Vector3.up * rotX, Space.World);
	}
}