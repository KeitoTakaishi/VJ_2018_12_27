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
        ps1.startSpeed = KnobIndicatorGroups.knobVal[0] * 10.0f;
        ps2.startSpeed = KnobIndicatorGroups.knobVal[1] * 10.0f;
        ps3.startSpeed = KnobIndicatorGroups.knobVal[2] * 10.0f;
        ps4.startSpeed = KnobIndicatorGroups.knobVal[3] * 10.0f;
    }
}
