using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class testParticle : MonoBehaviour {
    public GameObject flower;
    ParticleSystem ps;

	void Start () {
        ps = flower.GetComponent<ParticleSystem>();
	}
	
	void Update () {
        ps.startColor = new Color(KnobIndicatorGroups.knobVal[0], KnobIndicatorGroups.knobVal[1], KnobIndicatorGroups.knobVal[2]);
        ps.startSpeed = KnobIndicatorGroups.knobVal[3] * 40.0f;
    }
}
