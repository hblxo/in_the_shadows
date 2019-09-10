using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	public Text MovieNames;
	private bool _helpPanelOpen;
	public GameObject HelpPanel;

	// Use this for initialization
	void Start () {
		_helpPanelOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Awake()
	{
		var movieValue =  SceneManager.GetActiveScene().buildIndex - 2;
		MovieNames.text = "\"" + EnumExtensions.StringValueOf((GeneralData.MovieNames)movieValue) + "\"";
	}
	
	public void OpenHelpPanel()
	{
		_helpPanelOpen = !_helpPanelOpen;
		HelpPanel.SetActive(_helpPanelOpen);
	}
}

