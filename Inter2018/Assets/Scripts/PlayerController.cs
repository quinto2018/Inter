using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public float moveSpeed = 20.0f;
	private Vector3 direction;
	private CharacterController characterController;

	public Camera cam;

	private RaycastHit hit;
	private Ray ray;
	public LayerMask layer;
	private Vector3 currentLookTarget = Vector3.zero;
	private float distance = 30f;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		direction.x = Input.GetAxis ("Horizontal");
		direction.z = Input.GetAxis ("Vertical");

		Vector3 moveDirection = new Vector3 (direction.x, 0, direction.z);
		characterController.SimpleMove (moveDirection * moveSpeed);

		ray = cam.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (ray.origin, ray.direction * distance, Color.red);

		if (Physics.Raycast (ray, out hit, distance, layer, QueryTriggerInteraction.Ignore))
		{
			if (hit.point != currentLookTarget) 
			{
				currentLookTarget = hit.point;
				Vector3 position = new Vector3 (hit.point.x, transform.position.y, hit.point.z);

				Quaternion rot = Quaternion.LookRotation (position - transform.position);
				transform.rotation = Quaternion.Lerp (transform.rotation, rot, Time.deltaTime * 5f);
			}
		}

	}
}
