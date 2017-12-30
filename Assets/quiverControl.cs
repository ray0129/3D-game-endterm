using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quiverControl : MonoBehaviour {
    public float destroy_time;
    private float during_time = 0;
    private int usingWeapon=0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (BallControll.touchQuiver == true)
        {
            BallControll.weaponType = 6;
            BallControll.touchQuiver = false;
            during_time = 0;
        }
        during_time += Time.deltaTime;
        if (during_time > destroy_time)
        {

            BallControll.weaponType = usingWeapon;
            BallControll.toolUsing = false;
            this.gameObject.SetActive(false);
        }
    }
}
