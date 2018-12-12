using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class rePlace : MonoBehaviour {
    
    
    #region variable
    List<GameObject> child;
    List<Vector3> initPos;
    List<Vector3> modifyPos;
    List<Vector3> dir;
    Material mat;
    int childNum;
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

        mat = Resources.Load("ModelMat") as Material;
        VerticalLayoutPos();
	}
	
	void Update () {
	    
        if (Input.GetKey(KeyCode.A))
        {
            for (int i = 0; i < childNum; i++)
            {
                //child[i].transform.position = 1.0f*Mathf.Sin(Time.realtimeSinceStartup/10.0f*Mathf.Rad2Deg);
                var d = initPos[i] - child[i].transform.position; 
                child[i].transform.position += d.normalized * 0.2f;
            }
        }
	}
    
    //縦書くに並べるためのFunc
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
