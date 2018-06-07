using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag("jetonTag"))
		{
			col.gameObject.SetActive(false);
			Player_FirstPerson.Set_count(1);
//			print("1 point va etre ajoute a 'count'");
		}
		
		else if (col.gameObject.CompareTag("fosse"))
		{
			Destroy(this.gameObject);
		}
	}
}
