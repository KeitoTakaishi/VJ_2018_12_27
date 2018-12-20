using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;

public class ParticleController : MonoBehaviour {
    public GameObject Rock;
    private ParticleSystem ps;
    public Material Rockmat;
	void Start () {
        ps = Rock.GetComponent<ParticleSystem>();
	}
	
	void Update () {
        Rockmat.SetFloat("val", server.val*1.0f);
	}
}
