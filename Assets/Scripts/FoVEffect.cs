using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoVEffect : MonoBehaviour {
    private Camera _cam;
    private float _NextVal;
    private float _CurVal;
    private float t;
    [SerializeField]
    private float interval = 60;
    private float[] _fovVal = { 25.0f, 120.0f, 179.0f };
	void Start () {
        _cam = this.GetComponent<Camera>();
        
	}
	
	void Update () {
        t += 1.0f / interval;

		if(Time.frameCount % 10 == 0) {
            _CurVal = _cam.fieldOfView;
            _NextVal = _fovVal[Random.Range(0, 3)];
            t = 0.0f;
        }

       // _cam.fieldOfView = Mathf.Lerp(_CurVal, _NextVal, t);
    }
}
