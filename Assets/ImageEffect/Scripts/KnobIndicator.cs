using UnityEngine;
using System.Collections.Generic;
using MidiJack;

public class KnobIndicators : MonoBehaviour
{
    public GameObject prefab;

    List<KnobIndicator> indicators;

    void Start()
    {
        DontDestroyOnLoad(this);
        indicators = new List<KnobIndicator>();
    }

    void Update()
    {
        var channels = MidiMaster.GetKnobNumbers();

        if (indicators.Count != channels.Length)
        {
            var go = Instantiate<GameObject>(prefab);
            var indicator = go.GetComponent<KnobIndicator>();
            //加わるたびにchannelのidとしている
            indicator.knobNumber = channels[indicators.Count];
            indicators.Add(indicator);
        }
    }
}
