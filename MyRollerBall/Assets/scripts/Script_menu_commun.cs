using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_menu_commun : MonoBehaviour {

	Color _couleurEntree;
	Color _couleurSortie;
	int _tailleEntree;
	int _tailleSortie;

	Text m_Text;
	Graphic m_Graphic;


	// Use this for initialization
	void Start () {
		m_Text = GetComponent<Text>();		
		m_Graphic = GetComponent<Graphic>();
		_couleurEntree = Color.green;
		_couleurSortie = Color.white;
		_tailleEntree = 90;
		_tailleSortie = 70;
	}
	
	// Update is called once per frame
	void Update () {
		OnMouseEnter();
		OnMouseExit();
		
	}

	void OnMouseEnter() {
		m_Graphic.color = _couleurEntree;
		m_Text.fontSize = _tailleEntree;
	}

	void OnMouseExit() {
		m_Graphic.color = _couleurSortie;
		m_Text.fontSize = _tailleSortie;
	}
}
