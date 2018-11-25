using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject target;
    public float damping = 10;
    Vector3 offset;

	void Start () {
        offset = transform.position - target.transform.position;
	}
	
	void Update () {}

    void FixedUpdate ()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = position;
    }
}
