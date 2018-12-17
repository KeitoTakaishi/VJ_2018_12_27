using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismMesh : MonoBehaviour {
    MeshFilter _mf;
	void Start () {
        _mf = this.GetComponent<MeshFilter>();
        //_mf.mesh.SetIndices(_mf.mesh.GetIndices(0), MeshTopology.Lines, 0);
	}
	
	void Update () {
		
	}
}
