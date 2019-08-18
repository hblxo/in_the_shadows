using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static bool _devMode;
	private int _availableLevels;
	public EndOfLevelAnimation EndOfLevelAnimation;
	private static int _lastLevel;
	public UiManager Ui;
	
	void Start ()
	{
//		SaveLevel(0);
//		DisableDevMode();
	}

	private void Awake()
	{
		if (PlayerPrefs.HasKey("DevMode"))
			_devMode = (PlayerPrefs.GetInt("DevMode") != 0);
		else
			_devMode = false;
		_availableLevels = PlayerPrefs.HasKey("Current Level") ? PlayerPrefs.GetInt("Current Level") : 0;
	}

	void Update () {
		
	}

	static void SaveLevel (int level) {
		if (PlayerPrefs.HasKey("Current Level"))
			PlayerPrefs.DeleteKey("Current Level");
        PlayerPrefs.SetInt ("Current Level", level);
        PlayerPrefs.Save();
	}

	public void ActiveDevMode()
	{
		_devMode = true;
		if (PlayerPrefs.HasKey("DevMode"))
			PlayerPrefs.DeleteKey("DevMode");
		PlayerPrefs.SetInt("DevMode", 1);
		PlayerPrefs.Save();
	}
	
	public void DisableDevMode()
	{
		_devMode = false;
		if (PlayerPrefs.HasKey("DevMode"))
			PlayerPrefs.DeleteKey("DevMode");
		PlayerPrefs.SetInt("DevMode", 0);
		PlayerPrefs.Save();
	}

	public IEnumerator ValidateLevel(int level)
	{
		Time.timeScale = 0;
		EndOfLevelAnimation.Congrats();
		if (!_devMode && level > _availableLevels)
		{
			SaveLevel(level);
			GeneralData.LevelToUnlock = level;
		}
		else
			GeneralData.LevelToUnlock = 0;
		yield return new WaitForSecondsRealtime(5);
		Time.timeScale = 1;
		Ui.LevelChanger(1);
//		SceneManager.LoadScene("Menu");
	}

	public void ResetProgression()
	{
		SaveLevel(0);
	}

	public bool DevMode
	{
		get { return _devMode; }
	}

	public int AvailableLevels
	{
		get { return _availableLevels; }
	}
}
