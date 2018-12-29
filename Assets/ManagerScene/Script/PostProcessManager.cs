using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.PostProcessing;
using uOSC;

public class PostProcessManager : MonoBehaviour {

    public GameObject cam;
    PostProcessingBehaviour behaviour;
    

	void Start () {
        behaviour = cam.GetComponent<PostProcessingBehaviour>();
        
	}
	
	void Update () {
      var s = behaviour.profile.bloom.settings;
        s.bloom.intensity = server.high >3.0f ? 3.0f : server.high;
      behaviour.profile.bloom.settings= s;
	}
}
