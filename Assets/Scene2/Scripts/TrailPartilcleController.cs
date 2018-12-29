using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPartilcleController : MonoBehaviour {
    public GameObject trailParticle;
    private ParticleSystem trailPs;

    void Start () {
        trailPs = trailParticle.GetComponent<ParticleSystem>();	
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.R)) {
            trailPs.Play();
        }
	}
}
