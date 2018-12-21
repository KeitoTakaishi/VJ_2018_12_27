using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uOSC;

public class FPSViewer : MonoBehaviour {
    float frameNum = 0;
    float time = 0.0f;


    string fps;
    string low;


    public Text fpsText;
    public Text lowText;
    public Text midText;
    public Text highText;
	void Start () {
		
	}
	
	void Update () {
       
        fpsText.text = "FPS : " + (1f / Time.deltaTime).ToString();
        
        lowText.text = "OSC-Low : " + server.val.ToString();
        midText.text = "OSC-Mid : " + server.mid.ToString();
        highText.text = "OSC-High : " + server.high.ToString();
        //lowText.text = server.val.ToString();
    }
}