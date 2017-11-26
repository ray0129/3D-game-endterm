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

	/*
		for (int i = 0; i < MineManager.ColRow; i++) {
			for (int j = 0; j < MineManager.ColRow; j++) {
				if (MineManager.mines [i, j] == this) {
					x = i;
					y = j;
				}
			}
		}*/

	}

	void OnMouseDown(){ //will need to modify to OnClosion or OnTrigger
		Debug.Log("Find myself at:" + x.ToString() + " " + y.ToString() );
		if (itsMine) {
			rend.material.color = Mine; //change to safe color
		}else {
			rend.material.color = hoverColor;//change to mine color
			//hp or sth go down
		}
	}


}
