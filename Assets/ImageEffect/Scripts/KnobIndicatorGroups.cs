using UnityEngine;
using System.Collections.Generic;
using MidiJack;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KnobIndicatorGroups : MonoBehaviour
{
    public GameObject prefab;
    List<KnobIndicator> indicators;
    public Text[] knobMessages = new Text[8];
    public static float[] knobVal = new float[8];


    void Start()
    {
        DontDestroyOnLoad(this);
        indicators = new List<KnobIndicator>();
    }

    void Update()
    {
        var channels = MidiMaster.GetKnobNumbers();
        //Debug.Log(channels + " : channels");

        // If a new chennel was added...
        if (indicators.Count != channels.Length)
        {
            // Instantiate the new indicator.
            var go = Instantiate<GameObject>(prefab);
            go.transform.position = Vector3.right * indicators.Count;

            // Initialize the indicator.
            var indicator = go.GetComponent<KnobIndicator>();
            //加わるたびにchannelのidとしている
            indicator.knobNumber = channels[indicators.Count];

            // Add it to the indicator list.
            indicators.Add(indicator);
        }


        for (var i = 0; i < indicators.Count; i++) {
            knobVal[i] = MidiMaster.GetKnob(indicators[i].knobNumber);
            Debug.Log(i + " : " + knobVal[i]);
            if (SceneManager.GetActiveScene().name == "ManagerScene") {
                knobMessages[i].text = knobVal[i].ToString();
            }
        }


    }
}
