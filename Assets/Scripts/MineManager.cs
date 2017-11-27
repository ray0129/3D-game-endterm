using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineManager : MonoBehaviour {

	public static Transform[,] mines;//static to access any where

	public Color temp;

	public static int ColRow;

	void Awake(){
		ColRow = (int)Mathf.Sqrt (transform.childCount);
		mines = new Transform[ColRow,ColRow]; //make the array for wavepoints
		for (int i = 0; i < ColRow; i++) {
			for (int j = 0; j < ColRow; j++) {
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
}
