using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PosterScript : MonoBehaviour
{
	public int Level;
	public GameManager Gm;
	private Animator _animator;
	
	void Start ()
	{
		_animator = GetComponent<Animator>();
	}
	
	private void OnMouseEnter()
	{
		_animator.SetBool("MouseOver", true);
	}

	private void OnMouseExit()
	{
		_animator.SetBool("MouseOver", false);
	}

	private void OnMouseDown()
	{
//	    Debug.Log(Level + " - " + GeneralData.AvailableLevels);
		if (GeneralData.DevMode || GeneralData.AvailableLevels + 1 >= Level - 1)//transform.GetSiblingIndex())
			Gm.LevelChanger(Level);
	}
}
