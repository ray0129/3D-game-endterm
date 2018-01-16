using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

	public Button[] levelButtons;

	void Start(){
		//stored data 
		int levelReached = PlayerPrefs.GetInt("levelReached", 1); //name , default number
			
		for (int i = 0; i < levelButtons.Length; i++) {
			if(i + 1 > levelReached)
				levelButtons [i].interactable = false;
		}
	}

	void Update(){
		if(Input.GetKey (KeyCode.E)){
			unlock ();
		}
	}

	private void unlock(){
		for (int i = 0; i < levelButtons.Length; i++) {
			levelButtons [i].interactable = true;
		}
	}

	public void Select(int level){
		switch (level) {
			case 1:
				SceneManager.LoadScene ("mis01");
				break;
			case 2:
				SceneManager.LoadScene ("mis02");
				break;
			case 3:
				SceneManager.LoadScene ("mis03");
				break;
			case 4:
				SceneManager.LoadScene ("mis04");
				break;
			case 5:
				SceneManager.LoadScene ("mis05");
				break;
			case 6:
				SceneManager.LoadScene ("mis06");
				break;
			case 7:
				SceneManager.LoadScene ("mis07");
				break;
			case 8:
				SceneManager.LoadScene ("mis08");
				break;
			case 9:
				SceneManager.LoadScene ("mis09");
				break;
			case 10:
				SceneManager.LoadScene ("");
				break;
		}
	}

}
