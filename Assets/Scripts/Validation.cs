using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Validation : MonoBehaviour {

	public GameManager Gm;
	public ItemToCheck[] Children;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Children.Any(child => !child.IsValid()))
			return ;
		//StartCoroutine(Gm.ValidateLevel(SceneManager.GetActiveScene().buildIndex - 1));
	}


	public void TEMPORARY()
	{
		StartCoroutine(Gm.ValidateLevel(SceneManager.GetActiveScene().buildIndex - 1));		
	}
}
