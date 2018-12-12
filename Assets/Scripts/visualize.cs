﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualize : MonoBehaviour {

    [SerializeField]private GameObject _oscObj;
    private uOSC.server _server;
    [SerializeField] private Material geom;
	void Start () {
        _server = _oscObj.GetComponent<uOSC.server>();
	}
	
	void Update () {
        geom.SetFloat("_Height", _server.val);
        geom.SetInt("_ID", this.GetInstanceID());
        //Debug.Log("value :" + _server.val);
	}
}
