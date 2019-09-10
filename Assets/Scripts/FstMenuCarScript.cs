using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Object = System.Object;

public class FstMenuCarScript : MonoBehaviour
{
	private AudioSource _audioSource;
	public GameObject[] Spots;
	public UnityEvent OnClick = new UnityEvent();
 
	// Use this for initialization
	void Start ()
	{
		_audioSource = GetComponent<AudioSource>();
	}
     
	// Update is called once per frame
	void Update () {
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit Hit;
        
		if (GeneralData.OptionsPanelOpen)
			return;
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
			{
				StartCoroutine(KlaxonPlay());
				OnClick.Invoke();
			}
		}    
	}

	private void OnMouseEnter()
	{
		if (GeneralData.OptionsPanelOpen)
			return;
		foreach (var s in Spots)
		{
			s.SetActive(true);
		}
	}

	private void OnMouseExit()
	{
		foreach (var s in Spots)
		{
			s.SetActive(false);
		}
	}

	private IEnumerator KlaxonPlay()
	{
		_audioSource.Play();
		yield return new WaitForSeconds(2);
	}
}
