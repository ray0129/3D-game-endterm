using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {



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
				SceneManager.LoadScene ("Complete");
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
