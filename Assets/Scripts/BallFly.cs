using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFly : MonoBehaviour {
	static public float speed = 0.1f;
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward * speed);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
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
}
