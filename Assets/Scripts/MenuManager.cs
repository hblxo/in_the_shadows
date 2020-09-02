using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public Camera Cam;
	public GameManager Gm;
	public GameObject[] Posters;
	public GameObject[] Lights;
	public Material[] Materials;
	
	public GameObject Trail;
	public GameObject Stamp;
	private Animator _camAnimator;
	
	
	void Start ()
	{
		_camAnimator = Cam.GetComponent<Animator>();
		if (GeneralData.AvailableLevels >= 3)
			MoveCameraOn2NdPos();
		if (GeneralData.LevelToUnlock != 0)
			StartCoroutine(UnlockLevel(GeneralData.LevelToUnlock));
		SetPoster();
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Gm.LevelChanger((int) GeneralData.Scenes.FirstMenu);
	}
	
	public void SetPoster()
	{
		var i = 0;
		
		while (Posters.Length > i && (GeneralData.DevMode || GeneralData.AvailableLevels >= i))
		{
			SetRenderer(i);
			SetLight(i);
			if (!GeneralData.DevMode && GeneralData.AvailableLevels > i)
				SetStamp(i);
			i++;
		}
	}

	private void SetStamp(int i)
	{
		Instantiate(Stamp, Posters[i].transform);
	}

	private void SetRenderer(int i)
	{
		Posters[i].GetComponent<Renderer>().material = Materials[i];
	}
	
	private void SetLight(int i)
	{
		Lights[i].SetActive(true);
	}

	public void MoveCameraOn1StPos()
	{
		_camAnimator.SetTrigger("firstPos");
	}
	
	public void MoveCameraOn2NdPos()
	{
		_camAnimator.SetTrigger("nextPos");
	}
	
	private IEnumerator UnlockLevel(int level)
	{
		var trailPos = new Vector3(0f, 59f, 0f);
		var trailRot = new Quaternion(0f, 0f, 0f, 0f);
		var timeDelay = (level < 3) ? 1 : 4;
		yield return new WaitForSeconds(timeDelay);
		switch (level)
		{
			case 1:
				trailPos.x = 365;
				trailPos.z = 839;
				break;
			case 2:
				trailPos.x = 345;
				trailPos.z = 839;
				break;
			case 3:
				trailPos.x = 472;
				trailPos.z = 851;
				trailRot = Quaternion.Euler(0, 188, 0);
				break;
			case 4:
				trailPos.x = 492;
				trailPos.z = 848;
				trailRot = Quaternion.Euler(0, 188, 0);
				break;
			case 5:
				trailPos.x = 512;
				trailPos.z = 845;
				trailRot = Quaternion.Euler(0, 188, 0);
				break;
		}

		var clone = Instantiate(Trail, trailPos, trailRot);
		Destroy(clone, 4f);
	}
}
