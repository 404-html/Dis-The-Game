using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHurt : MonoBehaviour {

	public GameObject impactEffect;
	public int damageToGive;
	public AudioSource sound;
	// Use this for initialization
	void Start () {
		sound = GameObject.Find ("JinxHit").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
		void OnTriggerEnter2D(Collider2D other)
	{
		{
			if (other.tag == "Darius") {
				//Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
				//Destroy(other.gameObject);
				//ScoreManager.AddPoints(pointsForKill);
				sound.Play ();
				other.GetComponent<HurtDarius> ().giveDamage (damageToGive);
				Instantiate (impactEffect, transform.position, transform.rotation);
				Destroy (gameObject);


			}
		
		}
	}

	
}
