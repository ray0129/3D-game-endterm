using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathPoint : MonoBehaviour {

	public static Transform[] points; //宣告一個全域陣列存points

	void Awake(){
		points = new Transform[transform.childCount];

		for (int i = 0; i < points.Length; i++) { //find all points
			points [i] = transform.GetChild (i);
		}

	}

}
