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
	public float PosDiff = 4f;
	public float RotDiff = 15f;


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
		return (RotCompare() && Vector3.Distance(transform.localPosition, new Vector3(0f, 0f, 0f)) < PosDiff);
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

	private bool RotCompare()
	{
		Quaternion local = Quaternion.Euler(transform.localEulerAngles);
		Quaternion valid = Quaternion.Euler(0f, 0f, 0f);
		float angle = Quaternion.Angle(local, valid);
		if (Mathf.Abs(angle) > RotDiff)
			return false;
		return true;
	}
}
