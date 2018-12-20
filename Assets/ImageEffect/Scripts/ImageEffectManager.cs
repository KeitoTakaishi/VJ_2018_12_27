/*
 * midiコンと連携して使う用のimage filter
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using KUtil;

public class ImageEffectManager : MonoBehaviour {

    #region public
    public Mosaic mosaic;
    public float maxMosaiceScale = 32;
    public float effectTime = 0.25f;

    #endregion

    IEnumerator ActionMosaic()
    {
        float duration = effectTime;
        while (duration > 0f) {
            duration = Mathf.Max(duration - Time.deltaTime, 0);
            mosaic.scale = Easing.Ease(EaseType.QuadOut, maxMosaiceScale, 1, 1f - duration / effectTime);
            yield return null;
        }
    }


    void MidiChecker()
    {
        if (MidiPad.isPressed[0]) {
            StartCoroutine(ActionMosaic());
        }else if (MidiPad.isPressed[1]) {

        }else if (MidiPad.isPressed[2]) {

        }else if (MidiPad.isPressed[3]) {

        }else if (MidiPad.isPressed[4]) {

        }else if (MidiPad.isPressed[5]) {

        }else if (MidiPad.isPressed[6]) {

        }else if (MidiPad.isPressed[7]) {

        }
    }


    void Start () {
		
	}
	
	void Update () {
        MidiChecker();

    }
}
