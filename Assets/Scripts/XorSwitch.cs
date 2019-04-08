using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XorSwitch : MonoBehaviour {


	public bool up;
	public Sprite off;
	public Sprite onn;
	public AudioSource sound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		{

			if (other.tag == "Projectile")
			{
				sound.Play ();
				if(up)
				{
					this.GetComponent<SpriteRenderer> ().sprite = off;
					up = false;
				} 
				else
				{
					this.GetComponent<SpriteRenderer> ().sprite = onn;
					up = true;
				}
			}
		}
}
}
