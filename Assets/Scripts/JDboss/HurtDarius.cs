using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtDarius : MonoBehaviour {

	public int dariusHealth;

	public GameObject deathEffect;

	public int pointsOnDeath;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (dariusHealth <= 0)
		{
			Instantiate(deathEffect, transform.position, transform.rotation);
			ScoreManager.AddPoints(pointsOnDeath);
			GetComponent<AudioSource> ().pitch = 1f;
			Destroy(gameObject);
		}

	}

	public void giveDamage (int damageToGive)
	{
		dariusHealth -= damageToGive;
		GetComponent<AudioSource> ().pitch += 0.1f;
		GetComponent<AudioSource> ().Play ();

	}
}