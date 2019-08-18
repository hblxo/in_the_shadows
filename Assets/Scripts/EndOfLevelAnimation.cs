using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelAnimation : MonoBehaviour {
	public GameManager Gm;
	private Animator _animator;
	public GameObject Ps;

	// Use this for initialization
	void Start ()
	{
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Congrats()
	{
		Instantiate(Ps, new Vector3(427, 0, 784), Quaternion.identity);
		_animator.SetTrigger("Validation");
		//TODO : Add sound
		//TODO : Add video Ending
	}
}
