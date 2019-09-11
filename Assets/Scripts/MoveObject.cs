using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveObject : MonoBehaviour
{
//	private Camera _mainCamera;
	private Vector3 _zeroCamPos;
	private Vector3 _objBounds;
	public bool CanMove;
	// Use this for initialization
	void Start ()
	{
//		_mainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    [SerializeField]
    private float _dragSpeed = 0.1f;
    private Vector3 _lastMousePos;
//	private Vector3 _screenBounds;
   
    void OnMouseDown() {
        _lastMousePos = Input.mousePosition;
    }
   
    void OnMouseDrag() {
        var delta = Input.mousePosition - _lastMousePos;
        var pos = transform.position;
//	    SetBoundaries();
	    if (!CanMove)
		    return;
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
        {
        	pos.y += delta.y * _dragSpeed * Time.timeScale;
//	        if (Mathf.Abs(Vector3.Distance(_objBounds, pos)) >= 20 && Vector3.Distance(pos, ))
//	        Mathf.Clamp(pos.y, _zeroCamPos.y + 20, _screenBounds.y - 50);
	        transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
        {
        	pos.x += delta.x * _dragSpeed * Time.timeScale;
//	        if (Vector3.Distance(_objBounds, pos) >= 20)
        		transform.position = pos;
        }
        _lastMousePos = Input.mousePosition;
    }

	//TODO : Fixer les limites du déplacements de l'objet
	/*
	private void SetBoundaries()
	{
		_zeroCamPos = _mainCamera.ScreenToWorldPoint(Vector3.zero);
		_screenBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));
		_objBounds.x = transform.GetComponentInChildren<MeshRenderer>().bounds.extents.x;
		_objBounds.y = transform.GetComponentInChildren<MeshRenderer>().bounds.extents.y;
	}*/
}
