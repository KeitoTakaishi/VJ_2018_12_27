﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;

public class Spawner : MonoBehaviour {
    public GameObject prism;
    private List<GameObject> _prisms;

	void Start () {
        _prisms = new List<GameObject>();
    }
	
	void Update () {
        if (server.val == 1.0f) {
            _prisms.Add(Instantiate(prism, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity));
        }
	}
}