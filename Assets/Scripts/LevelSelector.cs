using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {



	public void Select(int level){
		switch (level) {
			case 1:
				SceneManager.LoadScene ("Demo_01");
				break;
			case 2:
				SceneManager.LoadScene ("");
				break;
			case 3:
				SceneManager.LoadScene ("");
				break;
			case 4:
				SceneManager.LoadScene ("");
				break;
			case 5:
				SceneManager.LoadScene ("");
				break;
			case 6:
				SceneManager.LoadScene ("");
				break;
			case 7:
				SceneManager.LoadScene ("");
				break;
			case 8:
				SceneManager.LoadScene ("");
				break;
			case 9:
				SceneManager.LoadScene ("");
				break;
			case 10:
				SceneManager.LoadScene ("");
				break;
		}
	}

}
