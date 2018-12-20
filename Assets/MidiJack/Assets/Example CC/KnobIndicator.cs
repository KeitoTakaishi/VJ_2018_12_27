using UnityEngine;
using MidiJack;

public class KnobIndicator : MonoBehaviour
{
    public int knobNumber;

    void Awake()
    {
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        var s = MidiMaster.GetKnob(knobNumber);
        Debug.Log("knobNumber" + " : " + knobNumber + " " + "value" + ":" + s);
    }
}
