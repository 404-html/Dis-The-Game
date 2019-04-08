using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject player;
	public GameObject camera;
	public Transform teleportPoint;
	public ParticleSystem particle;
	public AudioSource sound;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		camera = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {

		if (player.transform.position == teleportPoint.transform.position) 
		{
			camera.transform.parent = null;
		}
			

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.name == "Player")
			{
			particle.transform.position = this.transform.position;
			particle.Play ();
			sound.Play ();
			camera.transform.parent = player.transform;
			player.transform.position = teleportPoint.transform.position;
			particle.transform.position = teleportPoint.transform.position;
			}
		
	}
}
