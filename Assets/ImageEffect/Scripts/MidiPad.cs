using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using MidiJack;

public class MidiPad : MonoBehaviour
{
    List<KnobIndicator> indicators;
    public Text[] padMessages = new Text[8];
    public static bool[] isPressed = new bool[8];

    void Start()
    {
        DontDestroyOnLoad(this);
        for(int i = 0; i < 8; i++) {
            isPressed[i] = false;
        }
        indicators = new List<KnobIndicator>();
    }

    void Update()
    {
        for (int i = 36; i < 44; i++) {
            if (MidiMaster.GetKeyDown(i)) {
                string podMessage = "ID" + i + ":" + "-Pressed";
                padMessages[i % 36].text = podMessage;
                isPressed[i % 36] = true;
            } else {
                string podMessage = "ID" + i + ":" + "-Do not Pressed";
                padMessages[i % 36].text = podMessage;
                isPressed[i % 36] = false;
            }
        }
    }
}
