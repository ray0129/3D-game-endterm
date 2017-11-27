using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineManager : MonoBehaviour {

	public static Transform[,] mines;//static to access any where
	public static bool[,] used;

	public Color Safe;
	public Color Mine;


	public static int ColRow;

	void Awake(){
		ColRow = (int)Mathf.Sqrt (transform.childCount);
		mines = new Transform[ColRow,ColRow]; //make the array for wavepoints
		used = new bool[ColRow,ColRow];

		for (int i = 0; i < ColRow; i++) {
			for (int j = 0; j < ColRow; j++) {
				used [i,j] = false;
				mines [i,j] = transform.GetChild (i*ColRow + j);
				mines [i,j].GetComponent<MineMap> ().x = i;
				mines [i,j].GetComponent<MineMap> ().y = j;
			}
		}
		Debug.Log ("mine count = " + mines.Length.ToString ());

		/*
		//test for array;
		mines [0,0].GetComponent<Renderer> ().material.color = temp;
		mines [0,1].GetComponent<Renderer> ().material.color = temp;
		mines [0,2].GetComponent<Renderer> ().material.color = temp;
		mines [0,4].GetComponent<Renderer> ().material.color = temp;
		*/
	}

	/*
	public void recursive(int i, int j){
		MM.used [i, j] = true;

		if (MineManager.mines[i,j].GetComponent<MineMap>().itsMine) {
			MineManager.mines[i,j].GetComponent<Renderer>().material.color = MineManager.mines[i,j].GetComponent<MineMap>().Mine; //change to mine color
		}else {
			MineManager.mines[i,j].GetComponent<Renderer>().material.color = MineManager.mines[i,j].GetComponent<MineMap>().hoverColor;//change to safe color
			if (i > 0 && MineManager.used [i - 1, j] == false) {
				recursive (i - 1, j); //down
			}
			if (j > 0 && MineManager.used [i, j - 1] == false) {
				recursive (i, j - 1); //go left
			}
			if (i < MineManager.ColRow - 1 && MineManager.used [i + 1, j] == false) { //go up
				recursive (i + 1, j);
			}
			if (i < MineManager.ColRow - 1 && MineManager.used [i, j + 1] == false) { //go right
				recursive (i, j + 1);
			}
		}

	}*/

}

