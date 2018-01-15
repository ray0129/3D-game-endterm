using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class StartTeachingText : MonoBehaviour {

	public GameObject ui;
	public BallControll obj;


	void Update(){
		if (ui.activeSelf) {

			if (Cursor.lockState != CursorLockMode.None) {
				Cursor.lockState = CursorLockMode.None;
			}
			GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.lockCursor = false;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.XSensitivity = 0;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.YSensitivity = 0;

			Time.timeScale = 0f;
			
			Cursor.visible = true;

		}
	}

	public void StartGame(){
		if (Cursor.lockState != CursorLockMode.Locked)
			Cursor.lockState = CursorLockMode.Locked;

		GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.lockCursor = true;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.XSensitivity = 2;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.YSensitivity = 2;

		Time.timeScale = 1f;
		Cursor.visible = false;
		obj.GameStart ();
		this.ui.SetActive (false);
	}

}
