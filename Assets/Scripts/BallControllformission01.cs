using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControllformission01 : MonoBehaviour
{
	public GameObject balls;
	public float time;
	public float Destroy_time = 3;
	public float maxSpeed = 150f;
	public float minSpeed = 3f;
	public float cSpeed = 0f;
	public float increase_speed = 50f;
	public Slider slider;

	//wind
	public static float WindX;
	//range 0.1~1f
	public static float WindY;
	public static float WindZ;
	//turn & gameControl
	private bool isGameStart = false;
	private bool isShooting = false;
	public int TurnCount = 10;
	public float TurnTime = 15;
	private float currentTime;
	private float temp;
	public Text TimeCountDownText;
	public Text ArrowRemainText;
    public static int RunTurn= 0;

	//for GameResult UI
	public GameObject gameResultUI;
	
	// Use this for initialization
	void Start ()
	{
		slider.value = 0;

		isGameStart = false;
		currentTime = TurnTime;
	}

	// Update is called once per frame
	void Update ()
	{
		if (true) {
			if (isShooting == false) {
				currentTime -= Time.deltaTime;
				//		TurnTime = Mathf.Clamp (TurnTime, 0f, Mathf.Infinity);
				TimeCountDownText.text = string.Format ("{0:00.00}", currentTime);
			}
			if (currentTime < 0) { // time is up
				
				Turn ();
				currentTime = TurnTime;
			}
			if (Input.GetKey (KeyCode.CapsLock)) {
				cSpeed = 0;
				slider.value = 0;
			
			} 
			if (Input.GetMouseButton (0) && isShooting == false ) {
				if (cSpeed < maxSpeed) {
					float amount = Time.deltaTime * increase_speed;
					cSpeed += amount;
					slider.value += 100 * amount / maxSpeed;
				} else {
					cSpeed = maxSpeed;
				}
			} else {

				//ball destory time
				if (temp > 0) {
					temp -= Time.deltaTime;
				}
				if (temp <= 0 || GameObject.FindGameObjectWithTag ("Ball") == null) {
					isShooting = false;
				}
					
				if (cSpeed > 0f) {
					
					isShooting = true;
					currentTime = TurnTime;
					TimeCountDownText.text = string.Format ("{0:00.00}", currentTime);


					cSpeed += minSpeed;
					BallFly.speed = cSpeed;

					temp = Destroy_time;

					Destroy (Instantiate (balls, this.transform.position, this.transform.rotation), Destroy_time);

					Turn ();
					time = 0f;
					cSpeed = 0f;
					slider.value = 0;

				}
			}	
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			EndGame ();
		}

	}

	void Turn ()
	{
		TurnCount--;
		RunTurn++;

		ArrowRemainText.text = "Remain:" + TurnCount.ToString ();
		if (TurnCount == -1) { // game end
	//		Debug.Log ("Game End -> Result");
			EndGame ();
		}

	}

	public void GameStart ()
	{
		isGameStart = true;
	}

	void EndGame(){ //game end and show Result
		gameResultUI.SetActive(true);
	}
}
