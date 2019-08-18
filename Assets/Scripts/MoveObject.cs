using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    [SerializeField]
    private float _dragSpeed = 0.1f;
    private Vector3 _lastMousePos;
   
    void OnMouseDown() {
        _lastMousePos = Input.mousePosition;
    }
   
    void OnMouseDrag() {
        var delta = Input.mousePosition - _lastMousePos;
        var pos = transform.position;
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
        {
        	pos.y += delta.y * _dragSpeed * Time.timeScale;
        	transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
        {
        	pos.x += delta.x * _dragSpeed * Time.timeScale;
        	transform.position = pos;
        }
        _lastMousePos = Input.mousePosition;
    }
}
