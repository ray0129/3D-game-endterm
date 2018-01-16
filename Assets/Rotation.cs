using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	public GameObject mine;
	private float time;
	public float speed;

	// Use this for initialization
	void Start () {
		time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (time >= 5f) {
			mine.transform.Rotate (0, 0, 90);
			time = 0f;
		}
		time += Time.deltaTime;
		*/
		if (Time.deltaTime == 0) {
			return;
		} else {
			mine.transform.Rotate (0, 0, speed);
		}
	}
}
