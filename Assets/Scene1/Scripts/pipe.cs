using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour {

	void Start () {
        var scaleXZ = Random.Range(0.1f, 0.5f);
        this.transform.localScale = new Vector3(scaleXZ, Random.Range(1.0f, 3.0f), scaleXZ);
        Destroy(this.gameObject,10.0f);
    }
	
	void Update () {
		
	}
}
