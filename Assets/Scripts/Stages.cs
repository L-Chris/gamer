using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stages : MonoBehaviour {

    public GameObject[] stages;
    private GameObject ball;
    private Canvas canvas;
    private int stageId = 1;

	// Use this for initialization
	void Start () {
        Transform[] trans = GetComponentsInChildren<Transform>();
        stages = new GameObject[20];
        ball = GameObject.Find("Ball");
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        for (int i = 1; i < trans.Length; i++)
        {
            stages[i - 1] = trans[i].gameObject;
        }
	}
	
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.J) || ball.transform.position.y <= -5)
        {
            Reset();
        }
    }

    void Reset()
    {
        for (int i = 1; i < stages.Length; i++)
        {
            Destroy(stages[i]);
        }
        stageId = 1;
        ball.SendMessage("Reset");
    }

    void CreateNextStage ()
    {
        if (stageId >= stages.Length)
        {
            Array.Resize<GameObject>(ref stages, stages.Length + 20);
        }
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Transform tmp = obj.transform;
        tmp.localScale = new Vector3(10.0f, 1, 10.0f);
        obj.tag = "Stage";
        tmp.parent = transform;
        float distance = UnityEngine.Random.Range(10.0f, 30.0f);
        float lastZ = stages[stageId - 1].transform.position.z + distance;
        tmp.position = new Vector3(0, 0, lastZ);
        stages[stageId++] = obj;
        obj.name = stageId.ToString();
        // update ui
        canvas.SendMessage("SetScore", stageId - 1);
    }
}
