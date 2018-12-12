using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtil : MonoBehaviour
{
    Vector3 bufferpos;
    [SerializeField]
    GameObject target;
    Vector3 nextPos;

    float t; //time for interpolation
    public float rad = 10.0f;

    #region mono
    enum InterpolationMode{
        Lerp,
        Slerp
    }

    [SerializeField]
    InterpolationMode im;
    void Start()
    {
        bufferpos = this.transform.position;

    }

    void Update()
    {
        if (Time.frameCount % 30 == 0)
        {
            bufferpos = this.transform.position;
            nextPos = Random.insideUnitSphere * rad;
            t = 0.0f;
            transform.LookAt(target.transform);

        }


        if (im == InterpolationMode.Lerp){
            //transform.position = Vector3.Lerp(bufferpos, nextPos, t);
            transform.position = InterpolationLerp(bufferpos, nextPos, t);
        }else if(im == InterpolationMode.Slerp){
            transform.position = Vector3.Slerp(bufferpos, nextPos, t);
        }
        transform.LookAt(target.transform);
        t += Time.deltaTime;
        if (t > 1.0f){
            t = 1.0f;
        }

    }
    #endregion


    Vector3 InterpolationLerp(Vector3 from, Vector3 to, float time){
        Vector3 dir = to - from;
        Vector3 result = to + dir * time;
        return result;
    }

}
