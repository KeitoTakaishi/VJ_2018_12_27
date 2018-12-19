using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePipes : MonoBehaviour {
    [SerializeField]
    GameObject pipe;
    List<GameObject> pipes;
	void Start () {
		
	}
	
	void Update () {
		if(Time.frameCount % 60 == 0) {
            pipes.Add(Instantiate(pipe, new Vector3(Random.Range(-50f, 50f), 0.0f, Random.Range(-50f, 50f)), Quaternion.identity));
        }
	}
}
