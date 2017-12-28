using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeShelter : MonoBehaviour {
    int numOfShelter = 6;
    int lastShelter;
    int nextShelter;

    public GameObject DM0;
    public GameObject DM1;
    public GameObject DM2;
    public GameObject DM3;
    public GameObject DM4;
    public GameObject DM5;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void closeShelter()
    {
        DM0.SetActive(false);
        DM1.SetActive(false);
        DM2.SetActive(false);
        DM3.SetActive(false);
        DM4.SetActive(false);
        DM5.SetActive(false);
    }
    public void shelterChange()
    {
        do
        {
            nextShelter = Random.Range(0, numOfShelter);
        } while (nextShelter == lastShelter);

        lastShelter = nextShelter;
        closeShelter();

        switch (nextShelter)
        {
            case 0:
                DM0.SetActive(true);
                break;
            case 1:
                DM1.SetActive(true);
                break;
            case 2:
                DM2.SetActive(true);
                break;
            case 3:
                DM3.SetActive(true);
                break;
            case 4:
                DM4.SetActive(true);
                break;
            case 5:
                DM5.SetActive(true);
                break;
        }


    }
}
