using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour {

    public GameObject _mainCam;
    public GameObject _otherCam;
    bool isRender = true;
	void Start () {
        _mainCam.SetActive(isRender);
        _otherCam.SetActive(!isRender);
	}
	
	void Update () {
		if(Time.frameCount % 600 == 1) {
            isRender = !isRender;
            _mainCam.SetActive(isRender);
            _otherCam.SetActive(!isRender);
        }
	}
}
