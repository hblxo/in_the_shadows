using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateObject : MonoBehaviour {
	[SerializeField]
	private float _rotSpeed = 20;
	[SerializeField]
	private bool _rotationY = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDrag() {
		float rotX = Input.GetAxis("Mouse X") * _rotSpeed * Mathf.Deg2Rad * Time.timeScale;
		float rotY = Input.GetAxis("Mouse Y") * _rotSpeed * Mathf.Deg2Rad * Time.timeScale;

		if (!Input.GetKey(KeyCode.LeftShift))
		{
			transform.RotateAround(Vector3.up, rotX);
			if (_rotationY && Input.GetKey(KeyCode.LeftControl))
				transform.RotateAround(Vector3.right, rotY);
		}
	}
}