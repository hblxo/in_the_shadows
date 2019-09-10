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
		if (GeneralData.DevMode || GeneralData.AvailableLevels >= transform.GetSiblingIndex())
			Gm.LevelChanger(Level);
	}
}
