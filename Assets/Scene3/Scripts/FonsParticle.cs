using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class FonsParticle : MonoBehaviour {
    public GameObject[] FontsPartilse = new GameObject[3];
    private ParticleSystem[] ps = new ParticleSystem[3];


    void Start () {
	    for(int i = 0; i < 3; i++) {
            ps[i] = FontsPartilse[i].GetComponent<ParticleSystem>();
        }	
	}
	
	void Update () {
        if (MidiPad.isPressed[7]) {
            ps[0].Play();
        }else if (MidiPad.isPressed[5]) {
            ps[1].Play();
        }else if (MidiPad.isPressed[6]) {
            ps[2].Play();
        }
    }
}
