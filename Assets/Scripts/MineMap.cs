using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMap : MonoBehaviour {

	public Color hoverColor;
	public Color Mine;

	private Renderer rend;

	public bool itsMine;

	public int x;
	public int y;

	void Start(){

		itsMine = Random.value < 0.15; //random generate mines
		rend = GetComponent<Renderer> ();

	}

	void OnMouseDown(){ //will need to modify to OnClosion or OnTrigger
		Debug.Log("Find myself at:" + x.ToString() + " " + y.ToString() );

		recursive (x, y);
	}

	void recursive(int i, int j){
		MineManager.used [i, j] = true;

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
			if (j < MineManager.ColRow - 1 && MineManager.used [i, j + 1] == false) { //go right
				recursive (i, j + 1);
			}
		}

	}


}
