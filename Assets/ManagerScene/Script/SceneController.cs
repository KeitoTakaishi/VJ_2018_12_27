using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	void Start () {
        DontDestroyOnLoad(this);
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            SceneManager.LoadScene("Scene1");
        }else if (Input.GetKeyDown(KeyCode.S)) {
            SceneManager.LoadScene("Scene2");
        }else if (Input.GetKeyDown(KeyCode.D)) {
            SceneManager.LoadScene("Scene3");
        }else if (Input.GetKeyDown(KeyCode.F)) {
            SceneManager.LoadScene("Scene4");
        }
    }
}
