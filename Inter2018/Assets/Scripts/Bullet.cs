using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform positionShoot;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (!IsInvoking ("InstantiateBullet"))
			{
				InvokeRepeating ("InstantiateBullet", 0f, 1f);
			}
		}
		if (Input.GetKeyUp (KeyCode.Space))
		{
				CancelInvoke("InstantiateBullet");	
		}
		
	}

	void InstantiateBullet()
	{
		if (bulletPrefab != null)
		{
			GameObject tempBullet = Instantiate (bulletPrefab) as GameObject;
			tempBullet.transform.position = positionShoot.position;
			tempBullet.GetComponent<Rigidbody> ().velocity = transform.parent.forward * speed;
		}
	}
}
