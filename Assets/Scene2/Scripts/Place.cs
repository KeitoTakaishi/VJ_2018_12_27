using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class Place : MonoBehaviour {	
	
	#region variable
    public GameObject[] fonts;
    private Vector3[] pos;
	private Vector3[] vel;
    const int num = 72;
    float stepDegree;
    float radius = 40.0f;
	private Vector3[] rootPos;
    private int mode = 0;
	#endregion

	#region Property

	public Vector3[] RootPos
    {
        get { return RootPos; }
    }

	

	#endregion
	

	#region mono

	private void OnEnable()
	{
		fonts = new GameObject[num];
		pos = new Vector3[num];
		vel = new Vector3[num];
		stepDegree = 2.0f*Mathf.PI / num;
		rootPos = new Vector3[num];
	}

	void Start () {
        GeneText();
        if (mode == 0)
        {
            setCirxle();
        }
        else if (mode == 1)
        {
            Alignment();
        }
	}
	
	void Update () {
        if (Time.frameCount % 240 == 1)
        {
            mode = Random.Range(0.0f, 1.0f) > 0.5 ? 0 : 1;
        }
        if (mode == 0)
        {
            RotateText();

        } else if(mode == 1){
            Alignment();
            SlideUpdatePos();
        }
	}
	
	#endregion

	#region PrivateFunc
    //円状に配置している
	void GeneText()
	{
		var path = "RowModel/row";
		for (int i = 0; i < fonts.Length; i++){
			string index = path + (i + 1).ToString();
			fonts[i] = (GameObject)Resources.Load(index);
            fonts[i].tag = "Font";
			//pos[i] = new Vector3(radius * Mathf.Sin(stepDegree * i), 0.0f, radius * Mathf.Cos(stepDegree * i));
			//fonts[i] = Instantiate(fonts[i], pos[i], Quaternion.identity);
			//fonts[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		}
	}

    void setCirxle()
    {
        for (int i = 0; i < fonts.Length; i++)
        {
            //string index = path + (i + 1).ToString();
            //fonts[i] = (GameObject)Resources.Load(index);
            pos[i] = new Vector3(radius * Mathf.Sin(stepDegree * i), 0.0f, radius * Mathf.Cos(stepDegree * i));
            fonts[i] = Instantiate(fonts[i], pos[i], Quaternion.identity);
            fonts[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

	void RotateText()
	{
		for (int i = 0; i < fonts.Length; i++)
		{
			var t = Time.realtimeSinceStartup/5.0f;
			pos[i] = new Vector3(radius * Mathf.Sin(stepDegree * i + t), 0.0f, radius * Mathf.Cos(stepDegree * i + t));
			fonts[i].transform.position = pos[i];
			rootPos[i] = pos[i];
		}
	}

    //縦に配置
	void Alignment()
	{
		int row = 8;
		int column = 9;
		float rowStep = 15.0f;
		float columnStep = 25.0f;
		for (int i = 0; i < column; i++)
		{
			for (int j = 0; j < row; j++)
			{
				var curRow = j - row / 2;	//横
				var curColumn = i - column / 2;

				pos[i * row + j] = new Vector3(curRow * rowStep, curColumn* columnStep, 0);
				fonts[i * row + j].transform.position = pos[i * row + j];
				rootPos[i * row + j] = pos[i * row + j];
			}
		}
	}
	
	private void SlideUpdatePos()
	{
		int row = 8;
		int column = 9;
		float rowStep = 10.0f;
		float columnStep = 25.0f;
		float minHeight = -100.0f;
		float maxHeight = 100.0f;
		for (int i = 0; i < column; i++)
		{
			for (int j = 0; j < row; j++)
			{
				var curRow = j - row / 2;	//横
				var curColumn = i - column / 2;

				if (j % 2 == 0)
				{
					if (pos[i * row + j].y > maxHeight)
					{
						pos[i*row+j] = new Vector3(pos[i*row+j].x, minHeight, pos[i*row+j].z);
					}
					pos[i * row + j] += new Vector3(0.0f, 0.3f, 0.0f);
					fonts[i * row + j].transform.position = pos[i * row + j];
					rootPos[i * row + j] = pos[i * row + j];
				}
				else
				{
					if (pos[i * row + j].y < minHeight)
					{
						pos[i*row+j] = new Vector3(pos[i*row+j].x, maxHeight, pos[i*row+j].z);
					}
					pos[i * row + j] -= new Vector3(0.0f, 0.3f, 0.0f);
					fonts[i * row + j].transform.position = pos[i * row + j];
					rootPos[i * row + j] = pos[i * row + j];
				}
			}
		}
	}
	#endregion
	
	
}
