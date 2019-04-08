using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinxMovement : MonoBehaviour {

	public GameObject jinx;
	public GameObject gun;
	public Transform playerTarget;
	public PlayerController player;
	public Transform shootPoint;
	public float waitTime;
	public GameObject rocket;
	public GameObject jinxShootSound;
	// Use this for initialization
	void Start () {
		
		waitTime = 2f;

	}
	
	// Update is called once per frame
	void Update () {

		waitTime -= Time.deltaTime;
		if (waitTime <= 0) 
		{
			jinxShootSound.GetComponent<AudioSource>().Play ();
			Instantiate(rocket, shootPoint.transform.position, shootPoint.transform.rotation);
			waitTime = 2f;
		}


		}

}
