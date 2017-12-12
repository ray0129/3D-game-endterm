using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour {
	public GameObject balls;
	public float time;
	public float Destroy_time = 3;
	public GameObject cam;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > 0.5f) {
			if (Input.GetKeyUp (KeyCode.Mouse0)) {
				Destroy(Instantiate (balls, this.transform.position, this.transform.rotation),Destroy_time);
				time = 0f;
			}
		}
	}
}
