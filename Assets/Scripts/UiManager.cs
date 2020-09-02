using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
//	public GameManager Gm;

//	private AudioSource _music;

	private bool _optionsPanelOpen;
	public GameObject OptionsPanel;	
	
	// Use this for initialization
	void Start ()
	{
//		_music = GetComponent<AudioSource>();
		_optionsPanelOpen = false;
		MusicPlay();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 0)
			OpenOptionsPanel();
	}

	public void OpenOptionsPanel()
	{
		_optionsPanelOpen = !_optionsPanelOpen;
		GeneralData.OptionsPanelOpen = _optionsPanelOpen;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		OptionsPanel.SetActive(_optionsPanelOpen);
	}
	
	public void MusicPlay()
	{
		bool set;

		if (PlayerPrefs.HasKey("Music Settings"))
			set = (PlayerPrefs.GetInt("Music Settings") == 1);
		else
			set = false;
		AudioListener.volume = set ? 0f : 1f;
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
		AudioListener.volume = set ? 0f : 1f;
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