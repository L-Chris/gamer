using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planes : MonoBehaviour {

    public Transform[] planes;
    private int stage = 1;

	// Use this for initialization
	void Start () {
        Transform[] objs = GetComponentsInChildren<Transform>();
        planes = new Transform[20];

        for (int i = 1; i < objs.Length; i++)
        {
            planes[i - 1] = objs[i];
        }
	}
	
    Transform CreateNextPlane ()
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Transform tmp = obj.transform;
        obj.tag = "Stage";
        tmp.parent = transform;
        float distance = UnityEngine.Random.Range(10.0f, 30.0f);
        float lastZ = planes[stage - 1].position.z + distance;
        tmp.position = new Vector3(0, 0, lastZ);
        planes[stage++] = tmp;
        obj.name = stage.ToString();
        return tmp;
    }

	// Update is called once per frame
	void Update () {}
}
