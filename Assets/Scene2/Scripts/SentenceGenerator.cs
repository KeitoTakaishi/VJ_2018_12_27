/*
説明の文章を表示するためのスクリプト
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System.IO;
using System.Linq;
using SimpleJSON;
using System.Text;


public class SentenceGenerator : MonoBehaviour
{
    #region Variable

    private string m_jsonFilePath;
    private JSONNode m_jsonData;
    private int num = 72;
    private string[] SenData;
    public GameObject OCS;
    //private OscManager ocsManager;
    private int tempId=0;
    TextMesh tm;
    Vector2 screenSize;
    Camera cam;

    #endregion

    void Start()
    {
        ReadFile();
        SenData = new String[num];
        for(int i = 0; i < SenData.Length; i++)
        {
            SenData[i] = "";
        }
        
        LoadData(ref SenData);
       // ocsManager = OCS.GetComponent < OscManager >();



        /*
        screenSize.x = Screen.currentResolution.width;
        screenSize.y = Screen.currentResolution.height;
        cam = Camera.main;

        //this.transform.position = new Vector3(1.0f, 45.0f, cam.transform.position.z + 10.0f);
        */
        tm = this.GetComponent<TextMesh>();
        
    }

    void Update()
    {
        //if (tempId != ocsManager.ID)
        //{
        //    SelectData(ocsManager.ID);
        //    tempId = ocsManager.ID;
        //}
    }


    void ReadFile()
    {
        m_jsonFilePath = Application.dataPath + "/Json/ExpressSentence.json";
        string fileText = "";
        Debug.Log(m_jsonFilePath.ToString());
        if (File.Exists(Application.dataPath + m_jsonFilePath))
        {
            Debug.Log("Suc");
        }

        FileInfo file = new FileInfo(m_jsonFilePath);
        using (StreamReader sr = new StreamReader(file.OpenRead(), Encoding.UTF8))
        {
            fileText = sr.ReadToEnd();

            // JSONをパースして値を取り出す
            m_jsonData = JSONNode.Parse(fileText);
        }
    }

    void LoadData(ref String[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = m_jsonData["SenData"][i]["Sen"];
        }
    }

    void SelectData(int id)
    {
        //\nを必要がある
        tm.text = SenData[id - 1];
    }

}