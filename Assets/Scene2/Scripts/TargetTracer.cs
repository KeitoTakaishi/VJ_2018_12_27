using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracer : MonoBehaviour {
    private GameObject[] fonts = new GameObject[72];
    public Transform[] targets = new Transform[72];

    void Start() {
        fonts = GameObject.FindGameObjectsWithTag("Font");
        int id = 0;
        foreach (var f in fonts) {

            targets[id] = f.transform;
            ++id;
        }

	}
	
	void Update () {
		
	}
}
