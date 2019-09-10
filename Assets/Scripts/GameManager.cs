using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static int _lastLevel;
	
	public UiManager Ui;
	public LevelChanger Lc;

	void Start ()
	{
//		SaveLevel(0);
//		DisableDevMode();
	}

	private void Awake()
	{
		if (PlayerPrefs.HasKey("DevMode"))
			GeneralData.DevMode = (PlayerPrefs.GetInt("DevMode") != 0);
		else
			GeneralData.DevMode = false;
		GeneralData.AvailableLevels = PlayerPrefs.HasKey("Current Level") ? PlayerPrefs.GetInt("Current Level") : 0;
	}

	void Update () {
	}

	public void SaveLevel (int level) {
		if (PlayerPrefs.HasKey("Current Level"))
			PlayerPrefs.DeleteKey("Current Level");
        PlayerPrefs.SetInt ("Current Level", level);
        PlayerPrefs.Save();
	}

	public void ActiveDevMode()
	{
		GeneralData.DevMode = true;
		if (PlayerPrefs.HasKey("DevMode"))
			PlayerPrefs.DeleteKey("DevMode");
		PlayerPrefs.SetInt("DevMode", 1);
		PlayerPrefs.Save();
	}
	
	public void DisableDevMode()
	{
		GeneralData.DevMode = false;
		if (PlayerPrefs.HasKey("DevMode"))
			PlayerPrefs.DeleteKey("DevMode");
		PlayerPrefs.SetInt("DevMode", 0);
		PlayerPrefs.Save();
	}

	public void ResetProgression()
	{
		SaveLevel(0);
	}

	public void LevelChanger(int level)
	{
		Lc.FadeToLevel(level);
	}
}
