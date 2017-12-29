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

	//shelter
	public GameObject shelter;

	//104703034
	public GameObject direction;
	private int x = 0;
	private int RandDir;
	public static int Wind;

	//for GameResult UI
	public GameObject gameResultUI;

    //bow
    public GameObject bow;
    public GameObject arrow;
    float bowPullRate=0.5f;
    float arrowPullRate = 0.00205f;


    public Text windrangetext;
	private bool windChange;

	// Use this for initialization
	void Start ()
	{
		slider.value = 0;

		isGameStart = false;
		currentTime = TurnTime;

		ChangeWind ();
		shelter.GetComponent<changeShelter>().shelterChange();

	}

	// Update is called once per frame
	void Update ()
	{
        bow.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, bowPullRate * cSpeed);
        arrow.transform.localPosition = new Vector3(0,0.12f-arrowPullRate*cSpeed,0);
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
                    arrow.SetActive(true);
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
						ChangeWind ();
						shelter.GetComponent<changeShelter>().shelterChange();
                        
                        //	windChange = false;
                    }
				}


				if (cSpeed > 0f) {

					windChange = true;

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

        arrow.SetActive(false);

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
