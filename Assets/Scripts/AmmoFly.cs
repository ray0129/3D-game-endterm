using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoFly : MonoBehaviour {
	public float speed = 10f;
	public Rigidbody rb;
	public GameObject HitEffect;
	// Use this for initialization

	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward * speed);
	}


	private void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Constraint") {
			FindObjectOfType<AudioManger> ().Play ("HitSound");
			GameObject effectD = (GameObject)Instantiate (HitEffect, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
	}

	//destory ball by trigger
	private void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Constraint") == true) {
			FindObjectOfType<AudioManger> ().Play ("HitSound");
			GameObject effectD = (GameObject)Instantiate (HitEffect, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
	}

}