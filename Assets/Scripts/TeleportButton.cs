using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportButton : MonoBehaviour {



	private bool wc;
	public BigTeleport teleport;
	public Sprite wcisniety;
	// Use this for initialization
	void Start () {

		teleport = FindObjectOfType<BigTeleport> ();
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.name == "Player" && wc == false) {
			teleport.addPoint ();
			this.GetComponent<SpriteRenderer> ().sprite = wcisniety;
			this.GetComponent<AudioSource>().Play();
			wc = true;
		}
	}

}
