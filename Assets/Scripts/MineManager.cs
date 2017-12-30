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

    public GameObject shield;
    public static bool touchShield;

    public int MineNumber = 8;

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
	}

	public void AddScore(int count){
		
		score += count;
		ScoreText.text = "Score:" + score.ToString();
	}

	public void HitMines(){
		HitMineCount++;
		HitMineText.text = "HitMines" + HitMineCount.ToString();

        if (BallControll.hasShield == true)
        {
            BallControll.toolUsing = true;
            touchShield = true;
            shield.SetActive(true);
            BallControll.hasShield = false;
        }
        else
        {
            score -= 3;
            if (score < 0)
            {
             score = 0;
            }
		    ScoreText.text = "Score:" + score;

        }
		
	}
}

