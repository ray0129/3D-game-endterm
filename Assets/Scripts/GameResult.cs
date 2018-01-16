using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameResult : MonoBehaviour {


	public Text ScoreText;
	public int winScore = 30;
	public int levelToUnlock = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Cursor.lockState != CursorLockMode.None) {
			Cursor.lockState = CursorLockMode.None;
	//		Debug.Log (Cursor.lockState);
		}
		Debug.Log("in GameResult!");
		Cursor.visible = true;
	}

	void OnEnable(){
		
		ScoreText.text = MineManager.score.ToString();
	//	Debug.Log (MineManager.score);
		GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.lockCursor = false;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.XSensitivity = 0;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.YSensitivity = 0;
		Time.timeScale = 0f;

		if (MineManager.score >= winScore) {
			levelWin ();
		}
	}

	public void Retry(){
		//general purpose
		Routine();
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu(){
		Routine();
		SceneManager.LoadScene ("Start_01");
	}

	public void NextLevel(){
		Routine();
		//need modify, now just temp go to menu
		SceneManager.LoadScene ("LevelSelect");
	}

	void Routine(){
		Time.timeScale = 1f;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.XSensitivity = 2;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ().m_MouseLook.YSensitivity = 2;
	}

	private void levelWin(){
		PlayerPrefs.SetInt ("levelReached", levelToUnlock);
	}
}
