using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMesh : MonoBehaviour {
    MeshFilter mf;
	void Start () {
        var mf = this.GetComponent<SkinnedMeshRenderer>();
        mf.sharedMesh.SetIndices(mf.sharedMesh.GetIndices(0), MeshTopology.Lines, 0);
    }
	
	void Update () {
		
	}
}
