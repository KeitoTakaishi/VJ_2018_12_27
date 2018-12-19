using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    SkinnedMeshRenderer _smr;

    void Start () {
        _smr = this.GetComponent<SkinnedMeshRenderer>();
        _smr.sharedMesh.SetIndices(_smr.sharedMesh.GetIndices(0), MeshTopology.Lines, 0);
	}
	
	void Update () {
		
	}
}
