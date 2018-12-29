/*
 Groupのfontにつけるスクリプト
 */

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using uOSC;

public class rePlace : MonoBehaviour {
    
    
    #region variable
    List<GameObject> child;
    List<Vector3> initPos;
    List<Vector3> modifyPos;    //修正後のposition
    List<Vector3> dir;
    Material mat;
    int childNum;
    GameObject textManager;
    Place _place;
    int id = 0; //自分62候id
    #endregion

    

    private void OnEnable()
    {
        child = new List<GameObject>();
        initPos = new List<Vector3>();
        modifyPos = new List<Vector3>();
        dir = new List<Vector3>();
        childNum = transform.childCount;
       
    }

    void Start () {
        //var index = int.Parse(this.gameObject.name.Replace("row"," ").Replace("(Clone)", " "));
        textManager = GameObject.Find("FontsManager");
        _place = textManager.GetComponent<Place>();
        mat = Resources.Load("ModelMat") as Material;
        VerticalLayoutPos();
	}
	
	void Update () {
	    
        if (Input.GetKey(KeyCode.Q))
        {
            for (int i = 0; i < childNum; i++)
            {
                //var d = (initPos[i] - child[i].transform.position);
                var index = int.Parse(this.gameObject.name.Replace("row", " ").Replace("(Clone)", " "));
                var d = (_place.culcPos[index-1] - child[i].transform.position);
                child[i].transform.position += d.normalized * d.magnitude / 10.0f;
            }
        } 

        else if (Input.GetKey(KeyCode.W)) {
            VerticalLayoutPos();
        }


        for (int i = 0; i < childNum; i++) {
            //float scale = server.val > 5.0f ? 5.0 : server;
            child[i].transform.localScale = new Vector3(server.val / 5.0f, server.val / 5.0f, server.val / 5.0f);
        }



    }
    
    //縦書くに並べるためのFunc
    //parentPosが基準になっている座標
    private void VerticalLayoutPos()
    {
        var parentPos = this.transform.position;
        float textStep = 6.0f;

        for (int i = 0; i < childNum; i++)
        {
            child.Add(transform.GetChild(i).gameObject);
            initPos.Add(child[i].transform.position);

            child[i].transform.position = new Vector3(parentPos.x, parentPos.y - (i-1.5f) * textStep, parentPos.z);
            modifyPos.Add(child[i].transform.position);
            dir.Add((initPos[i] - modifyPos[i]).normalized);

            //文字数が3文字であった場合
            if (childNum == 3){
                child[i].transform.localScale = new Vector3(0.85f,0.85f,0.85f);
            }

            //change material
            var gChildNum = child[i].transform.childCount;

            for (int j = 0; j < gChildNum; j++){
                var c = child[i].transform.GetChild(j).gameObject;
                c.GetComponent<MeshRenderer>().material = mat;
            }
        }
    }
}
