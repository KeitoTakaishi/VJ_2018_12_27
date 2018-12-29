using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {
    public GameObject panel;
    private Image img;
	void Start () {
        img = panel.GetComponent<Image>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z)){
            StartCoroutine(Fade());
        }
	}

    IEnumerator Fade()
    {
        float c = 1.0f;
        float alpha = 0.0f;
        float step = 1.0f / 30.0f;
        for(int i = 0; i < 30; i++) {
            c -= 1.0f / 30.0f;
            alpha += step;
            img.color = new Color(c, c, c, alpha);
            yield return null;
        }
        yield return null;
             
    }
}
