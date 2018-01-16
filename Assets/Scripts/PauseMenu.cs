using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public GameObject ui;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P)) {
			Toggle ();
		}

		//to deal with pause bug
		if (!ui.activeSelf && StartTeachingText.StartTextIsActive == false) {
			Cursor.visible = false;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.lockCursor = true;
		}
	}

	void OnEnable(){
		
	}

	public void Retry(){
		//general purpose
		Toggle();
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu(){
		Toggle();
		Cursor.visible = true;
		SceneManager.LoadScene ("Start_01");
	}

	public void Continue(){
		Toggle ();
	}

	public void Toggle(){

		ui.SetActive (!ui.activeSelf);

		if (ui.activeSelf) {
			Cursor.visible = true;
			if (Cursor.lockState != CursorLockMode.None) {
				Cursor.lockState = CursorLockMode.None;
			}
			GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.lockCursor = false;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.XSensitivity = 0;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.YSensitivity = 0;
			Time.timeScale = 0f;
		} else {
			Debug.Log ("IN");
			if (Cursor.lockState != CursorLockMode.Locked) {
				Cursor.lockState = CursorLockMode.Locked;
			}
			GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.lockCursor = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.XSensitivity = 2;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.YSensitivity = 2;
			Time.timeScale = 1f;
		}



//		GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.lockCursor = true;
	}

}
