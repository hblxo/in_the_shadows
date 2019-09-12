using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Validation : MonoBehaviour {

	public GameManager Gm;
	private GameObject[] _children;
	private bool _fireworksStarted = false;
	public EndOfLevelAnimation EndOfLevelAnimation;
	public GameObject GodModBtn;
	
	public GameObject EndPanel;
	private bool _endPanelOpen = false;
	
	void Start ()
	{
		_children = GameObject.FindGameObjectsWithTag("ValidObject");
//		if (GeneralData.DevMode)
		GodModBtn.SetActive(GeneralData.DevMode);
	}
	
	void Update()
	{
		if (_endPanelOpen)
			return;
		if (Input.GetKeyDown(KeyCode.Escape))
			Gm.LevelChanger((int)GeneralData.Scenes.Menu);
		if (_children.Any(child => !child.GetComponent<ItemToCheck>().IsValid()))
			return;
		if (_fireworksStarted) return;
		StartCoroutine(ValidateLevel(SceneManager.GetActiveScene().buildIndex - 1));
		_fireworksStarted = true;
	}

	public void GodMod()
	{
		foreach (var child in _children)
		{
			child.GetComponent<ItemToCheck>().CreateAnim();
		}
	}

	public void OpenEndPanel()
	{
		_endPanelOpen = !_endPanelOpen;
//		GeneralData.EndPanelOpen = _endPanelOpen;
		EndPanel.SetActive(_endPanelOpen);
	}

	private IEnumerator ValidateLevel(int level)
	{
		Time.timeScale = 0;
		GodModBtn.SetActive(false);
		EndOfLevelAnimation.Congrats();
		if (!GeneralData.DevMode && level > GeneralData.AvailableLevels)
		{
			Gm.SaveLevel(level);
			GeneralData.LevelToUnlock = level;
		}
		else
			GeneralData.LevelToUnlock = 0;
		yield return new WaitForSecondsRealtime(5);
		Time.timeScale = 1;
		OpenEndPanel();
	}
}
