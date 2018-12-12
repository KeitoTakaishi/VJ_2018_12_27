using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MainScene
{
    public class GenerateMesh : MonoBehaviour
    {
        private List<string> ModifyData;
        private int[] CycleData;
        private CreateCSV _CreateCSV;
        private const int num = 72;
        List<float>[] tempData;


        private Mesh mesh;
        private MeshFilter mf;



        void Start()
        {
            //cycle日数をセット
            CycleData = new int[num];
            InitCycleData(ref CycleData);

            ModifyData = new List<string>();
            //CSVData -> Year:temperature

            _CreateCSV = GameObject.Find("CSV").GetComponent<CreateCSV>();
            _CreateCSV.LoadFile(ref ModifyData, "ModifyData");



            tempData = new List<float>[num];
            for (int i = 0; i < num; i++){
                tempData[i] = new List<float>();
            }

            SevrntyTwoDataBase(ModifyData, ref tempData);


            //CreateMesh
            mesh = new Mesh();
            mesh = CreateMesh(ref mesh, tempData[0]);
            mf = GetComponent<MeshFilter>();
            mf.sharedMesh = mesh;
            mf.mesh.SetIndices(mf.mesh.GetIndices(0), MeshTopology.LineStrip, 0);

        }

        void Update()
        {
            //this.transform.position += new Vector3(Time.deltaTime*4.0f, 0.0f, 0.0f);
        }


		private void InitCycleData(ref int[] dates)
		{
            for (int i = 0; i < 72; i++){
                dates[i] = 5;
            }
            dates[0] =  4;
            dates[27] = 6;
            dates[30] = 6;
            dates[34] = 6;
            dates[39] = 6;
            dates[40] = 6;
            dates[42] = 4;
            dates[43] = 6;
            dates[48] = 6;
            dates[68] = 4;
            dates[69] = 6;
		}


        //csvから72候型のデータを作成
        private void SevrntyTwoDataBase(List<string> data, ref List<float>[] temp){
            int CurSeason;//71まで回ったら初期化
            int CurDate;//3
            CurSeason = 0;
            CurDate = 0;


            //Debug.Log("count;" + data.Count);

            for (int i = 0; i < data.Count;)
            {
                if (int.Parse(data[i].Split(':')[0]) % 4 != 0)
                {
                    for (int j = 0; j < CycleData[CurSeason]; j++)
                    {
                        var t = float.Parse(data[i].Split(':')[1]);
                        tempData[CurSeason].Add(t);
                        i++;
                    }
                    CurSeason += 1;
                    if (CurSeason > 71)
                    {
                        CurSeason = 0;
                    }
                }else{
                    if (CurSeason != 11){
                        for (int j = 0; j < CycleData[CurSeason]; j++)
                        {
                            var t = float.Parse(data[i].Split(':')[1]);
                            tempData[CurSeason].Add(t);
                            i++;
                        }
                    }else{
                        for (int j = 0; j < CycleData[CurSeason]+1; j++)
                        {
                            var t = float.Parse(data[i].Split(':')[1]);
                            tempData[CurSeason].Add(t);
                            i++;
                        }
                    }
                    CurSeason += 1;
                    if (CurSeason > 71)
                    {
                        CurSeason = 0;
                    }
                }
            }
        } 


        private Mesh CreateMesh(ref Mesh mesh, List<float>data){

            Debug.Log(data.Count);
            List<Vector3> vertex = new List<Vector3>();
            List<int> index = new List<int>();
            int Date = data.Count;
            int ArrIndex = 0;
            float StepSize = 1.0f;
            for (int i = 0; i < Date; i++){
                vertex.Add(new Vector3((-Date/2 + ArrIndex)*StepSize, data[i], 0.0f));
                index.Add(i);
                ArrIndex++;
            }
           
            mesh.SetVertices(vertex);
            mesh.SetTriangles(index.ToArray(), 0);
            mesh.RecalculateNormals();

            return mesh;
        }
    }
}
