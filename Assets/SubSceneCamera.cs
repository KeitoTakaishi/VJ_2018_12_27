﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubSceneCamera : MonoBehaviour
{
    [SerializeField] Camera sceneCamera;
    [SerializeField] RenderTexture outPutTexture;
    [SerializeField] int channel;

    void Start()
    {
        if (SceneManager.GetActiveScene() == gameObject.scene) {
            sceneCamera.targetTexture = null;
        } else {
            sceneCamera.targetTexture = outPutTexture;
            //var ctrl = FindObjectOfType(typeof(SceneSelectorController)) as SceneSelectorController;
            //ctrl.RegisterScene(channel, this);
        }
    }

    public void SetActive(bool flag)
    {
        bool isActive = gameObject.activeSelf;
        if (flag && !isActive) {
            Enable();
        } else if (!flag && isActive) {
            Disable();
        }
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        sceneCamera.targetTexture.DiscardContents();
        gameObject.SetActive(false);
    }
}
