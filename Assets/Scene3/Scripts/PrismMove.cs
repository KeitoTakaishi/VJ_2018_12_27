using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismMove : MonoBehaviour {

	void Start () {
        Destroy(this.gameObject, 3.0f);
	}
	
	void Update () {
        this.transform.position += new Vector3(0.0f, 0.0f, -0.01f);
        this.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), Time.realtimeSinceStartup/40 % 360.0f);
	}
}
