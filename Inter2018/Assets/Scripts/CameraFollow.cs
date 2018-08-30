using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float moveSpeed;
	
	// Update is called once per frame
	void Update () {

		if (target != null)
		{
			transform.position = Vector3.Lerp (transform.position, target.transform.position, Time.deltaTime * moveSpeed);
		}
	}
}
