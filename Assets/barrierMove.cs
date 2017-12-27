using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierMove : MonoBehaviour {

	public float speed = 5f; //move speed

	private Transform target;
	private int PointIndex = 0;

	void Start () {
		target = pathPoint.points [0]; 
	}
	

	void Update () {
		Vector3 dir = target.position - transform.position; // where to go
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World); //方向 * 速度 * 時間, 世界坐標系

		if(Vector3.Distance(transform.position, target.position) <= 0.2f){ //如過夠靠近pathPoint (避免計算意外)
			GetNextPathPoint();
		}
	}

	void GetNextPathPoint(){
		PointIndex++;
		PointIndex %= 4;
		target = pathPoint.points [PointIndex];
	}
}
