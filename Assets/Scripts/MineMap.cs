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

	public GameObject HitEffect;
	public GameObject ExplodeEffect;
	private bool scoreDouble;

	public GameObject MineExplodeEffect;

	void Start(){
		scoreDouble = false;

		//itsMine = Random.value < 0.2; //random generate mines
		rend = GetComponent<Renderer> ();

	}
	/*
	void OnMouseDown(){ //will need to modify to OnClosion or OnTrigger
		Debug.Log("Find myself at:" + x.ToString() + " " + y.ToString() );

		recursive (x, y);
	}*/

	void recursive(int i, int j){

		if (MineManager.mines[i,j].GetComponent<MineMap>().itsMine) {
			MineManager.mines[i,j].GetComponent<Renderer>().material.color = Mine; //change to mine color
			gameObject.GetComponentInParent<MineManager> ().HitMines();
	//		GameObject effectD = (GameObject)Instantiate (ExplodeEffect, col.gameObject.transform.position, col.gameObject.transform.rotation);
			if (MineManager.used [i, j] == false) {
				Instantiate (MineExplodeEffect, this.transform.position, this.transform.rotation);
			}
			MineManager.used [i, j] = true;
		}else {
			//檢查周圍有無mines
			MineManager.used [i, j] = true;
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
				if (scoreDouble) {
					gameObject.GetComponentInParent<MineManager> ().AddScore (count);
					scoreDouble = false;
				}
			}else if(MineManager.hit[i,j] != true){
				MineManager.mines [i, j].GetComponent<Renderer> ().material.color = hoverColor; //change color
			}
			if (count == 0) { //周圍沒mines
                MineManager.mines[i, j].GetComponent<Renderer>().material.color = hitColor;

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
                if (i > 0 && j > 0 && MineManager.used[i - 1, j - 1] == false)//左下
                {
                    recursive(i - 1, j - 1);
                }
                if (i > 0 && j < MineManager.ColRow - 1 && MineManager.used[i - 1, j + 1] == false)//右下
                {
                    recursive(i - 1, j + 1);
                }
                if(i < MineManager.ColRow - 1 && j > 0 && MineManager.used[i + 1, j - 1] == false){//左上
                    recursive(i + 1, j - 1);
                }
                if(i < MineManager.ColRow - 1&& j < MineManager.ColRow - 1 && MineManager.used[i + 1, j + 1] == false)//右上
                {
                    recursive(i + 1, j + 1);
                }
			} else { //有mines
				Debug.Log(x.ToString() + " " + y.ToString() + "have " + count.ToString() + " mines");
				MineManager.mines [i, j].GetComponent<MineMap> ().MinesCount.text = "" + count;
			}
		}

	}

	void OnTriggerEnter(Collider col){
		Debug.Log("Find myself at:" + x.ToString() + " " + y.ToString() );
		if(col.CompareTag("Ball") == true || col.CompareTag("Shuriken") == true){
			FindObjectOfType<AudioManger> ().Play ("HitSound");
			GameObject effectD = (GameObject)Instantiate (HitEffect, col.gameObject.transform.position, col.gameObject.transform.rotation);
		}else if(col.CompareTag("FireBall") == true){
			FindObjectOfType<AudioManger> ().Play ("ExplodeSound");
			GameObject effectD = (GameObject)Instantiate (ExplodeEffect, col.gameObject.transform.position, col.gameObject.transform.rotation);
		}
			
		if (col.CompareTag ("Shuriken") == true) {
			scoreDouble = true;
		}

		Destroy (col.gameObject);
        if (BallControll.RunTurn == 1 && itsMine == true)
        {
            
            for (int k = 0; k < 1; k++)//重設地雷
            {
                int i = (int)Random.Range(0, MineManager.ColRow);
                int j = (int)Random.Range(0, MineManager.ColRow);

                if (MineManager.mines[i, j].GetComponent<MineMap>().itsMine == false )
                {
                    MineManager.mines[i, j].GetComponent<MineMap>().itsMine = true;
                }
                else if (MineManager.mines[i, j].GetComponent<MineMap>().itsMine == true)
                {
                    k--;
                }

            }
            itsMine = false;
            recursive(x, y);

        }
        else
        {
            recursive (x, y);
        }


       
	}

}
