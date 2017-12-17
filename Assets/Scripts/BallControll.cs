using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallControll : MonoBehaviour {
	public GameObject balls;
	public float time;
	public float Destroy_time = 3;
	public float maxSpeed = 150f;
	public float minSpeed = 3f;
	public float cSpeed = 0f;
	public float increase_speed = 25f;
	public GameObject cam;
	public Slider slider;
	// Use this for initialization
	void Start () {
		slider.value = 0;
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > 0.5f) {
			if (Input.GetMouseButton (0)) {
				if (cSpeed < maxSpeed) {
					cSpeed += Time.deltaTime * increase_speed;
					slider.value += Time.deltaTime * increase_speed;
				} else {
					cSpeed = maxSpeed;
				}
			} else {
				if (cSpeed > 0f) {
					cSpeed += minSpeed;
					BallFly.speed = cSpeed;
					Destroy(Instantiate (balls, this.transform.position, this.transform.rotation),Destroy_time);
					time = 0f;
					cSpeed = 0f;
					slider.value = 0;
				}
			}
		}
	}
}
