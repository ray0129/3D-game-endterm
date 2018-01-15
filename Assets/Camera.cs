using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public float X, Y, Z;
	// Use this for initialization
	public float speed = 1f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (X, Y, Z);

	}
}
