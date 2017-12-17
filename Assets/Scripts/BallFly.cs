using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFly : MonoBehaviour {
	static public float speed = 0.1f;
	public Rigidbody rb;
	// Use this for initialization

	//wind influence 
	private float WindX = 0; //range from 0.1 to 1 
	private float WindY = 0; 
	private float WindZ = 0; 

	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward * speed);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce (WindX, WindY, WindZ); //world location 
	}

	private void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Constraint") {
			Destroy (this.gameObject);
		}
		if (collision.gameObject.tag == "Cube") {
			Destroy (this.gameObject);
			Destroy (collision.gameObject);
		}
	}

	//destory ball by trigger
	private void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Constraint") == true) {
			Destroy (this.gameObject);
		}
	}

}
