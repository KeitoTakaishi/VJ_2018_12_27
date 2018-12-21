using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerLocation : MonoBehaviour {
    public GameObject[] dancers = new GameObject[5];

    private Vector3[] pos = new Vector3[5];
    private Vector3[] initPos = new Vector3[5];
    
	void Start () {

        for(int i = 0; i < 5; i++) {
            initPos[i] = new Vector3(0.0f, 0.0f, 0.0f);
        }

        pos[0] = new Vector3(0.0f, 0.0f, 0.0f);
        pos[1] = new Vector3(10f, 0.0f, 0.0f);
        pos[2] = new Vector3(0.0f, 0.0f, 10f);
        pos[3] = new Vector3(0.0f, 0.0f, -10f);
        pos[4] = new Vector3(-10f, 0.0f, 0.0f);
	    	
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.P)) {
            dancers[1].transform.position = pos[1];
            dancers[2].transform.position = pos[2];
            dancers[3].transform.position = pos[3];
            dancers[4].transform.position = pos[4];
        } else if(Input.GetKeyDown(KeyCode.O)) {
            dancers[1].transform.position = dancers[0].transform.position;
            dancers[2].transform.position = dancers[0].transform.position;
            dancers[3].transform.position = dancers[0].transform.position;
            dancers[4].transform.position = dancers[0].transform.position;
        }
	}
}
