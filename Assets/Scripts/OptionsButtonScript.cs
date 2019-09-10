using UnityEngine;
using UnityEngine.UI;

public class OptionsButtonScript : MonoBehaviour {

	public Text MusicText;
	public Text ControlText;

	void Start ()
	{
		SetMusicButton();
		SetControlButton();
	}

	public void SetMusicButton()
	{
		bool musicSettings;

		if (PlayerPrefs.HasKey("Music Settings"))
		{
			musicSettings = (PlayerPrefs.GetInt("Music Settings") == 0);
		}
		else
			musicSettings = true;
		MusicText.text = musicSettings ? "OFF" : "ON";
	}
	
	public void SetControlButton()
	{
		bool controlsSettings;

		if (PlayerPrefs.HasKey("Control Settings"))
		{
			controlsSettings = (PlayerPrefs.GetInt("Control Settings") == 0);
		}
		else
			controlsSettings = true;
		ControlText.text = controlsSettings ? "Keyboard" : "Mouse";
	}
	
}
