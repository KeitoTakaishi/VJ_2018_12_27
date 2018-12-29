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
    public RadiationBlur radiationBlur;
    public Distortion distortion;
    public Reflection reflection;
    public RandomInvert randomInvert;
    public RGBShift rgbShift;


    public float maxMosaiceScale = 32;
    public float effectTime = 0.75f;
    public float maxRadiationBlurPower = 32f;
    public float maxDistortionPower = 0.1f;
    public float maxRGBShiftPower = 16;

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
    
    IEnumerator ActionRadiationBlur()
    {
        float duration = effectTime;
        while (duration > 0f) {
            duration = Mathf.Max(duration - Time.deltaTime, 0);
            radiationBlur.power = Easing.Ease(EaseType.QuadOut, maxRadiationBlurPower, 1, 1f - duration / effectTime);
            yield return null;
        }
    }

    IEnumerator ActionDistortion()
    {
        float duration = effectTime;
        while (duration > 0f) {
            duration = Mathf.Max(duration - Time.deltaTime, 0);
            distortion.power = Easing.Ease(EaseType.QuadOut, maxDistortionPower, 0, 1f - duration / effectTime);
            yield return null;
        }
    }

    IEnumerator ActionRGBShift()
    {
        float duration = effectTime;
        while (duration > 0f) {
            duration = Mathf.Max(duration - Time.deltaTime, 0);
            rgbShift.shiftPower = Easing.Ease(EaseType.QuadOut, maxRGBShiftPower, 0, 1f - duration / effectTime);
            yield return null;
        }
    }

    void ActionReflectionLR()
    {
        reflection.horizontalReflect = !reflection.horizontalReflect;
    }

    void ActionReflectionTB()
    {
        reflection.verticalReflect = !reflection.verticalReflect;
    }

    void MidiChecker()
    {
        Debug.Log(MidiPad.isPressed[0]);
        if (MidiPad.isPressed[0]) {
            StartCoroutine(ActionMosaic());
        }else if (MidiPad.isPressed[1]) {
            StartCoroutine(ActionRadiationBlur());
        }else if (MidiPad.isPressed[2]) {
            StartCoroutine(ActionDistortion());
        }else if (MidiPad.isPressed[3]) {
            ActionReflectionLR();
        }else if (MidiPad.isPressed[4]) {
            ActionReflectionTB();
        }else if (MidiPad.isPressed[5]) {
            randomInvert.StartInvert();
        } else if (MidiPad.isPressed[6]) {
            StartCoroutine(ActionRGBShift());
        } else if (MidiPad.isPressed[7]) {

        }
    }


    void ResetEffect()
    {
        mosaic.isCircle = false;
        mosaic.ChangeCircleFlag();
        //mosaic.enabled = false;
        radiationBlur.power = 0;

        distortion.enabled = true;
        distortion.power = 0;

        reflection.horizontalReflect = false;
        reflection.verticalReflect = false;
    }


    void Start () {
        ResetEffect();
    }
	
	void Update () {
        effectTime = KnobIndicatorGroups.knobVal[4];
        maxRGBShiftPower = KnobIndicatorGroups.knobVal[2] * 168;

        MidiChecker();
    }
}
