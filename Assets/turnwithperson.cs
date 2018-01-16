using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnwithperson : MonoBehaviour {

	public Transform target;
	public float x;
	public float y;
	public float backwardDisX;
	public float backwardDisY;
	public float backwardDisZ;
	private Quaternion rotationEuler;
	private Vector3 camPos;
	public GameObject firsp;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		y = firsp.transform.rotation.eulerAngles.y;
		rotationEuler = Quaternion.Euler (90, y, 0);
		camPos = new Vector3 (backwardDisX,backwardDisY,backwardDisZ) + target.position;
		transform.rotation = rotationEuler;
		transform.position = camPos;
	}
}
