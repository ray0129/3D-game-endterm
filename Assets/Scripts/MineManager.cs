using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineManager : MonoBehaviour {

	public static Transform[,] mines;//static to access any where
	public static bool[,] used;
	public static bool[,] hit;

	public Color Safe;
	public Color Mine;

	public Text ScoreText;
	public static int score;

	public Text HitMineText;
	private int HitMineCount;

	public static int ColRow;

    public int MineNumber = 8;

	//batter score

	private int batter1=0;
	private int batter2=0;
	private int batter3=0;
	private bool triple=false;
	public Text batterscore;
	public GameObject batterplus;

	void Awake(){
		ColRow = (int)Mathf.Sqrt (transform.childCount);
		mines = new Transform[ColRow,ColRow]; //make the array for wavepoints
		used = new bool[ColRow,ColRow];
		hit = new bool[ColRow,ColRow];

		for (int i = 0; i < ColRow; i++) {
			for (int j = 0; j < ColRow; j++) {
				used [i,j] = false;
				hit [i, j] = false;
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

	void Start(){
		score = 0;
		ScoreText.text = "Score:" + score.ToString();

		HitMineCount = 0;
		HitMineText.text = "HitMines" + HitMineCount.ToString();

        for (int i = 0; i < ColRow; i++)//預設為空白
        {
            for (int j = 0; j < ColRow; j++)
            {
                MineManager.mines[i, j].GetComponent<MineMap>().itsMine=false;

            }
        }

        for(int k = 0; k < MineNumber; k++)//設置地雷
        {
            int i = (int)Random.Range(0, ColRow);
            int j = (int)Random.Range(0, ColRow);

            if (MineManager.mines[i, j].GetComponent<MineMap>().itsMine == false)
            {
                MineManager.mines[i, j].GetComponent<MineMap>().itsMine = true;
            }
            else if(MineManager.mines[i, j].GetComponent<MineMap>().itsMine == true)
            {
                k--;
            }
            
        }
		batterplus.SetActive (false);
	}

	public void AddScore(int count){

		score += count;

		//batter 3 same num

		batter1 = count;

		if (batter2 == batter1&&batter1!=0) {
			
			Debug.Log ("b2" + batter1);

			if (batter3 == batter2) {
				
				Debug.Log ("b3" + batter2);
				if (count == 1) {
					batterscore.text = "+3";
					StartCoroutine (temporarilydeactive (1f));
					FindObjectOfType<AudioManger> ().Play ("addmore");
					Debug.Log ("batter+3");
					score += 3;
				}
				if (count == 2) {
					batterscore.text = "+6"; 
					StartCoroutine (temporarilydeactive (1f));
					FindObjectOfType<AudioManger> ().Play ("addmore");
					Debug.Log ("batter+6");
					score += 6;
				}
				if (count == 3) {
					batterscore.text = "+9"; 
					StartCoroutine (temporarilydeactive (1f));
					FindObjectOfType<AudioManger> ().Play ("addmore");
					Debug.Log ("batter+9");
					score += 9;
				}
				batter2 = 0;
				batter1 = 0;
			}
			batter3 = batter2;
		}

		//batter 1 2 3

		if (triple) {
			FindObjectOfType<AudioManger> ().Play ("addtriple");
			triple = false;
			score += 2 * count;
			Debug.Log ("triple: " + count);
			batter1 = batter2 = batter3 = 0;
			batterplus.SetActive (false);
		}

		if(batter2==(batter1-1)){
			if (batter3 == (batter2-1)&&batter3==1) {
				triple = true;
				batterscore.text = "next X3";
				batterplus.SetActive (true);
			}
			batter3 = batter2;
		}

		batter2 = batter1;

		ScoreText.text = "Score:" + score.ToString();
	}

	public void HitMines(){
		HitMineCount++;
		HitMineText.text = "HitMines" + HitMineCount.ToString();

		//hitMines -> Score -= 2
		score -= 2;
		ScoreText.text = "Score:" + score;
	}

	private IEnumerator temporarilydeactive(float duration)
	{
		batterplus.SetActive (true);
		yield return new WaitForSeconds (duration);
		batterplus.SetActive (false);
	}
}

