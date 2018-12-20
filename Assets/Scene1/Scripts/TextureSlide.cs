using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSlide : MonoBehaviour {
    public Material ground;
    public float scrollSpeed  = 1.0f;
	void Start () {
		
	}
	
	void Update () {
        float offset = Time.time * scrollSpeed;
        ground.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
