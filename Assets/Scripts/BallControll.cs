using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour {
	public GameObject balls;
	public float time;
	public float Destroy_time = 3;
	public GameObject direction;
	private int x=0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		int j = Random.Range (0, 7);
		time += Time.deltaTime;
		if (time > 0.5f) {
			if (Input.GetKeyUp (KeyCode.Mouse0)) {
				direction.transform.Rotate (0, 0,(j-x)*45);
				Debug.Log(j);
				x = j;
				Destroy(Instantiate (balls, this.transform.position, this.transform.rotation),Destroy_time);
			}
		}
	}
}
