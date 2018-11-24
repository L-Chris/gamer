using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planes : MonoBehaviour {

    public Transform[] planes;

	// Use this for initialization
	void Start () {
        Transform[] objs = GetComponentsInChildren<Transform>();
        planes = new Transform[20];

        for (int i = 1; i < objs.Length; i++)
        {
            planes[i - 1] = objs[i];
        }

        for (int i = 1; i < 19; i++)
        {
            Transform tmp = GameObject.CreatePrimitive(PrimitiveType.Plane).transform;
            tmp.position = new Vector3(0, 0, i * 15);
            planes[i] = tmp;
        }

	}
	
	// Update is called once per frame
	void Update () {
	}
}
