/*
 textの複製と動きのエフェクトを作成している
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTransform : MonoBehaviour {
    float t = 0.0f;
    GameObject[] SubMessage;
    bool isInstance = false;

	void Start () {
        SubMessage = new GameObject[4];
  
            for (int i = 0; i < 4; i++){
                SubMessage[i] = GameObject.Find("SubMessage");
                SubMessage[i] = (GameObject)Instantiate(SubMessage[i], SubMessage[i].transform.position, SubMessage[i].transform.rotation);
                SubMessage[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                SubMessage[i].transform.SetParent(Camera.main.transform);
            }
            isInstance = true;


    }

    void Update () {
        //t = Time.deltaTime * 10.0f;
        //this.transform.Rotate(0.0f, t, 0.0f);

        //if(Input.GetKeyDown(KeyCode.A)){
        //    for (int i = 0; i < 4; i++){
        //        SubMessage[i] = GameObject.Find("SubMessage");
        //        SubMessage[i] = (GameObject)Instantiate(SubMessage[i], SubMessage[i].transform.position, SubMessage[i].transform.rotation);
        //        SubMessage[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //        SubMessage[i].transform.SetParent(Camera.main.transform);
        //    }
        //    isInstance = true;
        //}

        if(isInstance == true){
            for (int i = 0; i < 4; i++)
            {
                SubMessage[i].transform.position += new Vector3((i - 1.5f)*0.3f, 0.0f, 0.0f);
            }
        }
	}
}
