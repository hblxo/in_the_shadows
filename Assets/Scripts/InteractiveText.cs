﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveText : MonoBehaviour {

	public UnityEvent OnClick = new UnityEvent();
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit Hit;
         
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
			{
//				StartCoroutine();
				OnClick.Invoke();
			}
		} 
	}
}
