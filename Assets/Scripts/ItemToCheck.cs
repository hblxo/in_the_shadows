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
	private float _posDiff = 4f;
	[SerializeField]
	private float _rotDiff = 15f;


	private bool _rotX;
	private bool _move;
	// Use this for initialization
	void Start()
	{
		_move = GetComponent<MoveObject>().CanMove;
		_rotX = GetComponent<RotateObject>().RotationY;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	public bool IsValid()
	{
//		var dist = Vector3.Distance(transform.localPosition, new Vector3(0f, 0f, 0f));
//		Debug.Log(transform.name + " - pod : " + dist + " -- rot : " + Vector3.Distance(transform.localEulerAngles, new Vector3(0f, 0f, 0f)) % 360);
		return Vector3.Distance(transform.localPosition, new Vector3(0f, 0f, 0f)) < _posDiff
		       && (Vector3.Distance(transform.localEulerAngles, new Vector3(0f, 0f, 0f)) % 360 < _rotDiff
		           || (Vector3.Distance(transform.localEulerAngles, new Vector3(0f, 0f, 0f)) % 360) > 360 - _rotDiff);
	}
	
	public void CreateAnim ()
	{
		var anim = GetComponent<Animation>();
		var clip = new AnimationClip {legacy = true};

		if (_move)
		{
			var moveX = AnimationCurve.Linear(0f, transform.localPosition.x, 1f, 0.0f);
			var moveY = AnimationCurve.Linear(0f, transform.localPosition.y, 1f, 0.0f);
			clip.SetCurve("", typeof(Transform), "localPosition.x", moveX);
			clip.SetCurve("", typeof(Transform), "localPosition.y", moveY);
		}
		
		var rotateX = AnimationCurve.Linear(0f, transform.localEulerAngles.x, 1f, 0.0f);
		var rotateY = AnimationCurve.Linear(0f, transform.localEulerAngles.y, 1f, 0.0f);
		if (_rotX)
		{
			var rotateZ = AnimationCurve.Linear(0f, transform.localEulerAngles.z, 1f, 0.0f);
			clip.SetCurve("", typeof(Transform), "localEulerAngles.z", rotateZ);
		}
		clip.SetCurve("", typeof(Transform), "localEulerAngles.x", rotateX);
		clip.SetCurve("", typeof(Transform), "localEulerAngles.y", rotateY);
		anim.AddClip(clip, "rotation");
		anim.Play("rotation");
	}
}
