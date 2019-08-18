﻿using UnityEngine;

public class UiManager : MonoBehaviour
{
	public GameManager Gm;
	public LevelChanger Lc;

	private AudioSource _music;

	private bool _panelOpen;
	public GameObject OptionsPanel;	
	// Use this for initialization
	void Start ()
	{
		_music = GetComponent<AudioSource>();
		_panelOpen = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			OpenOptionsPanel();
	}

	public void OpenOptionsPanel()
	{
		_panelOpen = !_panelOpen;
		GeneralData.PanelOpen = _panelOpen;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		OptionsPanel.SetActive(_panelOpen);
	}

	public void LevelChanger(int level)
	{
		Lc.FadeToLevel(level);
	}
	
	public void MusicSettings()
	{
		bool set;

		if (PlayerPrefs.HasKey("Music Settings"))
		{
			set = (PlayerPrefs.GetInt("Music Settings") == 0);
			PlayerPrefs.DeleteKey("Music Settings");
		}
		else
			set = true;
		PlayerPrefs.SetInt("Music Settings", set ? 1 : 0);
		if (set)
			_music.Pause();
		else
			_music.UnPause();
		PlayerPrefs.Save();
	}	
	
	public void ControlSettings()
	{
		bool mouseSet;

		if (PlayerPrefs.HasKey("Control Settings"))
		{
			mouseSet = (PlayerPrefs.GetInt("Control Settings") == 0);
			PlayerPrefs.DeleteKey("Control Settings");
		}
		else
			mouseSet = true;
		PlayerPrefs.SetInt("Control Settings", mouseSet ? 1 : 0);
		PlayerPrefs.Save();
	}	
	
	public void Exit()
	{
		Application.Quit();
	}

}