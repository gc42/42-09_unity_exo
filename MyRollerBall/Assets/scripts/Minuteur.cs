using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minuteur : MonoBehaviour {

	public float minuteur;
	
	// Use this for initialization
	void Start () {
		minuteur = 5.0f;	
	}
	
	// Update is called once per frame
	void Update () {
		if (minuteur > 0){
			minuteur -=	Time.deltaTime;
		}
		else {
			Debug.Log("GAME OVER"); // Affichage message
		}
		
	}
}
