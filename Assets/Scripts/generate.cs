using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate : MonoBehaviour {
    [SerializeField] private GameObject _sphere;
    GameObject[] _spheres;
    void Start () {
        int _num = 50;
        _spheres = new GameObject[_num];
        for(var i = 0; i < _num; i++) {
            _spheres[i] = Instantiate(_sphere, Random.insideUnitSphere*5.0f, Quaternion.identity);
        }
	}
	
	void Update () {
		
	}
}
