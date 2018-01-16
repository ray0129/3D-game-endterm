using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescence : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Cursor.visible = true;
		if (Cursor.lockState != CursorLockMode.None) {
			Cursor.lockState = CursorLockMode.None;
		}
	}
    public void start()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
