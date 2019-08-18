using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Object = System.Object;

public class ItemToCheck : MonoBehaviour
{
	[SerializeField]
	private float _posDiff = 0.1f;
	[SerializeField]
	private float _rotDiff = 15f;


	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	public bool IsValid()
	{
		return Mathf.Abs(Vector3.Distance(transform.localPosition, new Vector3(0f, 0f, 0f))) < _posDiff
		       && Mathf.Abs(Vector3.Distance(transform.localEulerAngles, new Vector3(0f, 0f, 0f))) < _rotDiff;
	}
	
}
