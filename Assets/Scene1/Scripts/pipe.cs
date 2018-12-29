using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;

public class pipe : MonoBehaviour {
    public GameObject[] pipes;
    public float[] offSet;
	void Start () {
        offSet = new float[pipes.Length];
        for(int i = 0; i < offSet.Length; i++) {
            offSet[i] = UnityEngine.Random.RandomRange(-10.0f, 10.0f);
        }
    }
	
	void Update () {
		for(int i = 0; i < pipes.Length; i++) {
            pipes[i].transform.localScale = new Vector3(pipes[i].transform.localScale.x,
               server.high + offSet[i], pipes[i].transform.localScale.z);
        }
	}
}
