using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float            speed = 800;
    public Text             countText;
    public Text             winText;

    private Rigidbody       rb;
    private int             count;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
	}
	
	// FixedUpdate is called on several frames for Physics
	void FixedUpdate () 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical   = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("jetonTag"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText ();
        }

        else if (other.gameObject.CompareTag("fosse"))
        {
            //this.transform.position == (0, 0, 0);
            Debug.Log("T'es mort. Retenter ta chance ?");
            SceneManager.LoadScene(0);

        }
	}

    private void SetCountText ()
    {
        countText.text = "Jetons ramasses : " + count.ToString();

        if (count >= 20)
            winText.text = "Vous avez ramasse tous les jetons! Bravo!!";
    }
}
