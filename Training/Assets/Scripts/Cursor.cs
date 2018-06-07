using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{

	public Image viseur;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if (Physics.Raycast(transform.position, fwd, out hit))
		{
			if (hit.transform.tag == "jetonTag")
			{
				viseur.color = Color.red;
			}
			else
			{
				viseur.color = Color.white;
			}
		}

	}
}
