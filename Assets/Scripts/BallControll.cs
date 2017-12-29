using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControll : MonoBehaviour
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
	public static float WindX;//range 0.1~1f
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

	//shelter
	public GameObject shelter;

	//104703034
	public GameObject direction;
	private int x = 0;
	private int RandDir;
	public static int Wind;

	//for GameResult UI
	public GameObject gameResultUI;


	public Text windrangetext;
	private bool windChange;

	//change Weapon
	public static int weaponType; //0 ~ 4
	public static bool hasShotGun;
	public static bool hasStaff;
	public static bool hasShuriken;
	public static bool hasDetector;

	//funtion open or not
	public static bool needWind;
	public static bool needShelter;

	//FireBall
	public GameObject FireBall;

	// Use this for initialization
	void Start ()
	{
		//upper for value
		needWind = true;
		needShelter = true;
		slider.value = 0;
		isGameStart = false;
		currentTime = TurnTime;
		weaponType = 0;

		//lower for function call
		ChangeWind ();
		shelter.GetComponent<changeShelter>().shelterChange();
	}

	// Update is called once per frame
	void Update ()
	{

		if (true) { //isGameStart use here
			
			//是否在飛行
			if (isShooting == false) {
				currentTime -= Time.deltaTime;
				//		TurnTime = Mathf.Clamp (TurnTime, 0f, Mathf.Infinity);
				TimeCountDownText.text = string.Format ("{0:00.00}", currentTime);
			}

			//時間到 -> 強制換
			if (currentTime < 0) {
				Turn ();
				currentTime = TurnTime;
			}

			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				weaponType = 1;
			}else if(Input.GetKeyDown (KeyCode.Alpha2)){
				weaponType = 2;
			}else if(Input.GetKeyDown (KeyCode.Alpha3)){
				weaponType = 3;
			}else if(Input.GetKeyDown (KeyCode.Alpha4)){
				weaponType = 4;
			}


			switch(weaponType){
				//basic weapon
				case 0: 
					if (Input.GetKey (KeyCode.CapsLock)) {//Capslock取消蓄力
						cSpeed = 0;
						slider.value = 0;
					}
					
					if (Input.GetMouseButton (0) && isShooting == false) {//案住左鍵且球沒在飛 -> 可蓄力 & 丟球
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
							if (windChange) {
								Turn ();              // <-------------------- 這邊換turn
								ChangeWind ();
								shelter.GetComponent<changeShelter> ().shelterChange ();
							}
						}
						
						//射擊了
						if (cSpeed > 0f) {
							isShooting = true;
							windChange = true; //下一球需要新的風向
							
							//更新剩餘時間並顯示
							currentTime = TurnTime;   //<------------------這邊更新時間
							TimeCountDownText.text = string.Format ("{0:00.00}", currentTime);
							
							cSpeed += minSpeed;
							BallFly.speed = cSpeed;
							temp = Destroy_time;
							Destroy (Instantiate (balls, this.transform.position, this.transform.rotation), Destroy_time);
							time = 0f;
							cSpeed = 0f;
							slider.value = 0;
						}
					}
					break;

				//ShotGun
				case 1:
					break;

				//Staff;
				case 2:
					if (isShooting == true) {
						//ball destory time
						if (temp > 0) {
							temp -= Time.deltaTime;
						}
						if (temp <= 0 || GameObject.FindGameObjectWithTag ("FireBall") == null) {
							isShooting = false;
							if (windChange) {
								Turn ();              // <-------------------- 這邊換turn
								ChangeWind ();
								shelter.GetComponent<changeShelter> ().shelterChange ();
							}
						}
					}
					
					if (Input.GetMouseButtonDown(0) && isShooting == false) {
						isShooting = true;
						windChange = true; //下一球需要新的風向
						
						//更新剩餘時間並顯示
						currentTime = TurnTime;   //<------------------這邊更新時間
						TimeCountDownText.text = string.Format ("{0:00.00}", currentTime);
						
						temp = Destroy_time;
						Destroy (Instantiate (FireBall, this.transform.position, this.transform.rotation), Destroy_time);
					}

						
					break;

				//Shuriken;
				case 3:
					break;

				//Detector
				case 4:
					break;
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
		if (TurnCount == 0) { // game end
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

	void ChangeWind(){
		windChange = false;

		if (needWind == false) {
			return;
		}

		float Windmix;

		WindX = WindZ = 0;
		RandDir = Random.Range (0, 7);
		direction.transform.Rotate (0,(RandDir - x) * 45,0);
		Debug.Log (RandDir);
		if (RandDir < 2 || RandDir == 7) {
			WindZ = -1*Random.Range(0.1f,1f);
		}
		if (RandDir > 2 && RandDir < 6) {
			WindZ = 1*Random.Range(0.1f,1f);
		}
		if (RandDir > 0 && RandDir < 4) {
			WindX = -1*Random.Range(0.1f,1f);
		}
		if (RandDir > 4 && RandDir <= 7) {
			WindX = 1*Random.Range(0.1f,1f);
		}

		Windmix = Mathf.Sqrt(WindX * WindX + WindZ * WindZ);
		windrangetext.text = "Wind: " + string.Format ("{0:0.00}", Windmix*5);

		x = RandDir;

	}
}
