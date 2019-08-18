using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
//    public LevelData levelData;

    void Start () {

    }

    void Update () {
    	// save data + load data
        // if(Input.GetKeyDown (KeyCode.S))
        //     SaveCharacter (characterData, 0);

        // if (Input.GetKeyDown (KeyCode.L))
        //      characterData = LoadCharacter (0);
    }

    static void SaveLevel (int data) {
        PlayerPrefs.SetInt("Current Level", data);
        PlayerPrefs.Save ();
    }

    static int LoadLevel ()
    {
        var loadedLevel = PlayerPrefs.GetInt("Current Level");
        return loadedLevel;
    }
}
