using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_FirstPerson : MonoBehaviour
{

	public static int 		vie = 100;
	public static int 		munitions = 1000;
	public static bool 		hasJetons = false;
	
	public Text      countText;
	public Text      winText;

	private static int      count;
	private GameObject      go_FireWork;
	private float 			exposure;
	



	public static void Set_count(int addNumber)
	{
		count = count + addNumber;
//		print("1 point ajoute a 'count' par un Bullet qui touche un jeton.");
//		Debug.Log("Total points :" + count.ToString());
	}
	
	void Start()
	{
		count = 0;
		winText.text = "";

		go_FireWork = GameObject.Find("Fireworks");
		go_FireWork.SetActive(false);

	}

	void Update()
	{
		SetCountText();
	}

	private void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag("jetonTag"))
		{
			hasJetons = true;
			print("J'ai un jeton de plus. Total : " + count.ToString());
			col.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
		
		else if (col.gameObject.CompareTag("fosse"))
		{
			Debug.Log("T'est tombe trop bas !! Retenter ta chance est ton avenir...");
			SceneManager.LoadScene(0);
		}
		
//		else if (col.gameObject.name == "door")
//		{
//			if (hasJetons)
//			{
//				Destroy(col.gameObject);
//			}
//			else
//			{
//				print("J'ai deja attrappe des jetons, dujus!!");
//			}
//		}
		
		else if (col.gameObject.CompareTag("Bullet"))
		{
			vie = vie - Random.Range(5, 15);
			print(vie);
			if (vie <= 0)
			{
				print("Perdu !");
			}
		}
	}

	private void SetCountText()
	{
		this.countText.text = "Jetons ramasses : " + count.ToString();

		if (count >= 5)
		{
			this.winText.text = "Vous avez ramasse tous les jetons, bravo !!!!";
			go_FireWork.SetActive(true);

			StartCoroutine(reduceExposure());
			
		}
	}

	IEnumerator reduceExposure()
	{
		// Pour faire la nuit, reduction de l'exposition du skyDome
		
		for (int i = 0; i < 8; i++)
		{
			yield return new WaitForSeconds(1.0f);
			exposure -= 0.2f;
			RenderSettings.skybox.SetFloat("_Exposure", exposure);
		}
		yield return null;
	}

	void OnApplicationQuit()
	{
		RenderSettings.skybox.SetFloat("_Exposure", 1.3f);
	}

	
	
}
