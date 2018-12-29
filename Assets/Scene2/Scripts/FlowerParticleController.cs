using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;
using MidiJack;

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
        if (Input.GetKeyDown(KeyCode.L)) {
            ps1.Play();
            ps2.Play();
            ps3.Play();
            ps4.Play();
        }
    }
}
