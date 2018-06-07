using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

	public GameObject bullet;
	public int power;

	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonUp(0))
		{
			GameObject balle = (GameObject) Instantiate(bullet, this.transform.position, Quaternion.identity);
			balle.SetActive(true);
			balle.GetComponent<Rigidbody>().AddForce(this.transform.forward * power);
		}
	}
}
