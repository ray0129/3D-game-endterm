using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineMap : MonoBehaviour {

	public Color hoverColor;
	public Color Mine;
	public Color hitColor;

	private Renderer rend;

	public bool itsMine;
	public Text MinesCount;

	public int x;
	public int y;

	void Start(){

		itsMine = Random.value < 0.2; //random generate mines
		rend = GetComponent<Renderer> ();

	}
	/*
	void OnMouseDown(){ //will need to modify to OnClosion or OnTrigger
		Debug.Log("Find myself at:" + x.ToString() + " " + y.ToString() );

		recursive (x, y);
	}*/

	void recursive(int i, int j){
		MineManager.used [i, j] = true;

		if (MineManager.mines[i,j].GetComponent<MineMap>().itsMine) {
			MineManager.mines[i,j].GetComponent<Renderer>().material.color = Mine; //change to mine color
			gameObject.GetComponentInParent<MineManager> ().HitMines();
		}else {
			//檢查周圍有無mines
		
			int count = 0;

			if (i > 0) { //下
				if (MineManager.mines [i - 1, j].GetComponent<MineMap> ().itsMine)
					count++;
			}
			if (j > 0) { //左
				if (MineManager.mines [i, j - 1].GetComponent<MineMap> ().itsMine)
					count++;
			}
			if (i > 0 && j > 0) { //左下
				if (MineManager.mines [i - 1, j - 1].GetComponent<MineMap> ().itsMine)
					count++;
			}
			if (i < MineManager.ColRow - 1) { //上
				if (MineManager.mines [i + 1, j].GetComponent<MineMap> ().itsMine)
					count++;
			}
			if (i < MineManager.ColRow - 1 && j > 0) { //左上
				if (MineManager.mines [i + 1, j - 1].GetComponent<MineMap> ().itsMine)
					count++;
			}
			if (j < MineManager.ColRow - 1) { //右
				if (MineManager.mines [i, j + 1].GetComponent<MineMap> ().itsMine)
					count++;
			}
			if(i < MineManager.ColRow - 1 && j < MineManager.ColRow - 1){ //右上
				if (MineManager.mines [i + 1, j + 1].GetComponent<MineMap> ().itsMine)
					count++;
			}
			if(i > 0 && j < MineManager.ColRow - 1){ //右下
				if (MineManager.mines [i - 1, j + 1].GetComponent<MineMap> ().itsMine)
					count++;
			}

			if (i == x && j == y && count != 0 && MineManager.hit [i, j] == false) {
				MineManager.hit [i, j] = true;
				MineManager.mines [i, j].GetComponent<Renderer> ().material.color = hitColor;
				gameObject.GetComponentInParent<MineManager> ().AddScore (count);
			}else if(MineManager.hit[i,j] != true){
				MineManager.mines [i, j].GetComponent<Renderer> ().material.color = hoverColor; //change color
			}
			if (count == 0) { //周圍沒mines

				if (i > 0 && MineManager.used [i - 1, j] == false) { //down
					recursive (i - 1, j);
				}
				if (j > 0 && MineManager.used [i, j - 1] == false) { //go left
					recursive (i, j - 1);
				}
				if (i < MineManager.ColRow - 1 && MineManager.used [i + 1, j] == false) { //go up
					recursive (i + 1, j);
				}
				if (j < MineManager.ColRow - 1 && MineManager.used [i, j + 1] == false) { //go right
					recursive (i, j + 1);
				}
			} else { //有mines
				Debug.Log(x.ToString() + " " + y.ToString() + "have " + count.ToString() + " mines");
				MineManager.mines [i, j].GetComponent<MineMap> ().MinesCount.text = "" + count;
			}
		}

	}

	void OnTriggerEnter(Collider col){
		Debug.Log("Find myself at:" + x.ToString() + " " + y.ToString() );
		Destroy (col.gameObject);
		recursive (x, y);
	}

}
