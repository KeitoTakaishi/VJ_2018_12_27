using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour {

	void Start () {
        var mf = this.GetComponent<MeshFilter>();
        mf.mesh.SetIndices(mf.mesh.GetIndices(0), MeshTopology.LineStrip, 0);
                       
	}
	void Update () {
		
	}
}
