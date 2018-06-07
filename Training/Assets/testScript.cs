using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour {

	float smooth    = 3.0f;
	float tiltAngle = 60.0f;

	public Transform[] waypoints;

	// Use this for initialization
	void Start () {

		Rigidbody rb = GetComponent<Rigidbody>();
		
		// Change the mass of the Rigidbody.
		rb.mass = 2f;

		// Add force on the Rigidbody
		// rb.AddForce(Vector3.up * 2000f);

		waypoints = new Transform[transform.childCount];
		int i = 0;

		foreach (Transform t in transform)
		{
			waypoints[i++] = t;
			//code
			t.position += Vector3.up * 1.0f;
			t.rotation = Quaternion.Euler(0, 45, 0);
		}

		
		
	}
	
	// Update is called once per frame
	void Update () {

		waypoints = new Transform[transform.childCount];
		int i = 0;

		foreach (Transform t in transform)
		{
			
			waypoints[i++] = t;
			// Smoothly tilts a transform towards a target rotation.
			float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle;

			Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);

			// Dampen returns to the initial rotation
			t.transform.rotation = Quaternion.Slerp(t.transform.rotation, target, Time.deltaTime * smooth);
			
		}
		
	}
}
