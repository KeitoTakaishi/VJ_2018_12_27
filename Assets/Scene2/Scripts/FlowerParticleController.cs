using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;

public class FlowerParticleController : MonoBehaviour {

    public GameObject flower1;
    ParticleSystem ps1;
    public GameObject flower2;
    ParticleSystem ps2;
    public GameObject flower3;
    ParticleSystem ps3;
    public GameObject flower4;
    ParticleSystem ps4;


    void Start () {
        ps1 = flower1.GetComponent<ParticleSystem>();
        ps2 = flower2.GetComponent<ParticleSystem>();
        ps3 = flower3.GetComponent<ParticleSystem>();
        ps4 = flower4.GetComponent<ParticleSystem>();
	}
	
	void Update () {
        //ps1.emission = 
        //ps2.startSpeed = server.val;
        //ps3.startSpeed = server.val;
        //ps4.startSpeed = server.val;
    }
}
