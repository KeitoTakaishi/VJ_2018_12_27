using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffectApply : MonoBehaviour
{
    public Material[] _MatArraay;

    private Material _mat;
    [SerializeField]
    public Material mat
    {
        get { return _mat; }
        set { _mat = value; }
    }

    public int IntervalFrameNum = 120;
    private Vector2 blur_vec;
    private int curentId = 0;
    private RenderTexture _FrameBuffer;
    private int FrameCount = 0;
    private int id = 0;
    void Start()
    {
        mat = _MatArraay[curentId];
        _FrameBuffer = new RenderTexture(Screen.width, Screen.height, 0);
        curentId =(int)Random.Range(0,_MatArraay.Length);
    }

    void Update()
    {
        
        if(Time.frameCount % IntervalFrameNum == 1)
        {
            //curentId = (curentId + 1) % _MatArraay.Length;
            curentId = (int)Random.Range(0, _MatArraay.Length);
            //mat = _MatArraay[curentId];
            mat = _MatArraay[id];
            id = (id + 1) % _MatArraay.Length; 
        }

        blur_vec = new Vector2(Random.RandomRange(0.0f, 0.01f), Random.RandomRange(0.0f, 0.01f));
        mat.SetVector("_blur_vec", blur_vec);
        mat.SetFloat("_TimeMag", Time.realtimeSinceStartup);
        if(Time.frameCount % 5 == 1) {
            mat.SetFloat("_Threshold", Random.Range(-0.8F, 0.75F));
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture dest)
    {
        
        Graphics.Blit(source, _FrameBuffer);
        mat.SetTexture("_Buffer", _FrameBuffer);

        Graphics.Blit(source, dest, mat);

        FrameCount++;
        if(FrameCount % 4 == 0) _FrameBuffer = source;
    }
   
}