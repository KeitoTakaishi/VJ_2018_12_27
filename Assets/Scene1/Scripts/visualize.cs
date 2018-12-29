using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;
public class visualize : MonoBehaviour {

    [SerializeField] private Material geom;
	void Start () {
        //DontDestroyOnLoad(this);
        //_server = _oscObj.GetComponent<uOSC.server>();
	}
	
	void Update () {
        geom.SetFloat("_Height", server.val / 3.0f);
        geom.SetFloat("_High", server.high / 3.0f);
        geom.SetInt("_ID", this.GetInstanceID());
	}
}
