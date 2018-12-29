using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaclePs : MonoBehaviour {

    public ParticleSystem ps1;
    public ParticleSystem ps2;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E)) {
            ps1.Play();
            ps2.Play();
        }
	}
}
