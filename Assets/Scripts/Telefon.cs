using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Telefon : MonoBehaviour {

	public PlayerController player;
	private float time;
	private bool ulted;
	private Sprite sprajt;
	public Sprite pusty;
	// Use this for initialization
	void Start () {
		time = 1.1f;

		player = FindObjectOfType<PlayerController> ();
		sprajt = this.GetComponent<Image> ().sprite;
		this.GetComponent<Image> ().sprite = pusty;
	}
	
	// Update is called once per frame
	void Update () {

		if (player.ulted == true &&  KarthusManager.score >= 3) 
		{
			ulted = true;
		}

		if (ulted == true) 
		{
			//this.GetComponent<Animator> ().SetBool ("Ulted", true);
			this.GetComponent<Image> ().sprite = sprajt;



			time -= Time.deltaTime;
			if (time <= 0) 
			{
				this.GetComponent<Image> ().sprite = pusty;
				//this.GetComponent<Animator>().SetBool("Ulted", false);
				ulted = false;
			}



		}


			




	}
}
