using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PosterScript : MonoBehaviour
{
	public int Level;
	public GameManager Gm;
	public UiManager Ui;
	private Animator _animator;
	
	// Use this for initialization
	void Start ()
	{
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (Gm.DevMode || Gm.AvailableLevels >= Level)
//			_posterRenderer.material = Material;
//		Debug.Log("DEV : " + Gm.DevMode + " - LEVEL : " + Gm.AvailableLevels);
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
		if (Gm.DevMode || Gm.AvailableLevels >= transform.GetSiblingIndex())
			Ui.LevelChanger(Level);
	}
}
