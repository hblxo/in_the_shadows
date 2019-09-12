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


	private bool _rotX;
	// Use this for initialization
	void Start()
	{
		_rotX = GetComponent<RotateObject>().RotationY;
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
	
	public void CreateAnim ()
	{
		var anim = GetComponent<Animation>();
		AnimationClip clip = new AnimationClip();
		clip.legacy = true;

		var rotateX = AnimationCurve.Linear(0f, transform.localEulerAngles.x, 1f, 0.0f);
		var rotateY = AnimationCurve.Linear(0f, transform.localEulerAngles.y, 1f, 0.0f);
		if (_rotX)
		{
			var rotateZ = AnimationCurve.Linear(0f, transform.localEulerAngles.z, 1f, 0.0f);
			clip.SetCurve("", typeof(Transform), "localEulerAngles.z", rotateZ);
		}

		clip.SetCurve("", typeof(Transform), "localEulerAngles.x", rotateX);
		clip.SetCurve("", typeof(Transform), "localEulerAngles.y", rotateY);
		anim.AddClip(clip, "test");
		anim.Play("test");
	}
}
