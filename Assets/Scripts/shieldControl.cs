using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldControl : MonoBehaviour {
    public float destroy_time;
    private float during_time=0;
    private int usingWeapon;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (MineManager.touchShield==true)
        {
            usingWeapon = BallControll.weaponType;
            BallControll.weaponType = 5;
            MineManager.touchShield = false;
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
