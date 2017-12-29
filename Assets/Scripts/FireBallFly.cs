using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallFly : MonoBehaviour {

	static public float speed = 10f;
	public Rigidbody rb;
	public GameObject ExplodeEffect;
	void Start () {

		rb = GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward * speed);
	}

	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce (transform.forward * speed);
	}

	private void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Constraint") {
			DestoryBall (this.gameObject);
		}
	}

	//destory ball by trigger
	private void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Constraint") == true) {
			DestoryBall (this.gameObject);
		}
	}

	private void DestoryBall(GameObject g){
		FindObjectOfType<AudioManger> ().Play ("ExplodeSound");
		GameObject effectD = (GameObject)Instantiate (ExplodeEffect, transform.position, transform.rotation);
		Destroy (g);
	}
}