using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnwithperson : MonoBehaviour {

	public Transform target;
	private float x;
	private float y;
	public float Xsens;
	public float Ysens;
	public float backwardDisX;
	public float backwardDisY;
	public float backwardDisZ;
	private Quaternion rotationEuler;
	private Vector3 camPos;

	// Use this for initialization
	void Start () {
		x = 0;
		y = 100;
	}
	
	// Update is called once per frame
	void Update () {
		x -= Input.GetAxis ("Mouse X") * Xsens * Time.deltaTime;
		y += Input.GetAxis ("Mouse Y") * Ysens * Time.deltaTime;

		if (x > 360) {
			x -= 360;
		} else if (x < 0) {
			x += 360;
		}
		if (y > 100) {
			y = 100;
		} else if (y < 100) {
			y = 100;
		}
		rotationEuler = Quaternion.Euler (y, 0, x);
		camPos = new Vector3 (backwardDisX,backwardDisY,backwardDisZ) + target.position;
		transform.rotation = rotationEuler;
		transform.position = camPos;
	}
}
