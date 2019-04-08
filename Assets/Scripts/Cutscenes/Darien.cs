using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darien : MonoBehaviour {

	public GameObject player;
	public GameObject darien;



	public int cutsceneOrder;
	private float waitTime;


	public TextBoxManager theTextBox;

	public Transform disPlace;

	public AudioSource teleportSound;
	public GameObject teleport;


	public Transform darienPlace;
	public Transform disPlace1;
	public Transform disPlace2;
	public Transform disPlace3;

	public GameObject music;
	public GameObject bg;

	public GameObject dialog1;
	public GameObject dialog2;
	public GameObject dialog3;

	public string levelTag;
	public string LevelToLoad;
	public ScoreManager scoreManager;
	public GameObject dark;
	// Use this for initialization
	void Start () {

		scoreManager = FindObjectOfType<ScoreManager> ();
		theTextBox = FindObjectOfType<TextBoxManager> ();
		player.SetActive (false);
		waitTime = 1;
		teleport.GetComponent<Animator> ().SetBool ("On", true);
	}
	
	// Update is called once per frame
	void Update () {

		if (player.transform.position == disPlace.transform.position) {
			player.GetComponent<Animator> ().SetFloat ("Speed", 0);
		}


		if (cutsceneOrder == 0) 
		{
			waitTime -= Time.deltaTime;

			if (waitTime <= 0f) 
			{
				waitTime = 20f;
				cutsceneOrder = 1;
			}

		}


		if (cutsceneOrder == 1) 
		{
			player.SetActive (true);
			teleportSound.Play ();
			cutsceneOrder = 2;

		}

		if (cutsceneOrder == 2) 
		{
			player.GetComponent<Animator> ().SetBool ("Walk", true);
			player.transform.position = Vector3.MoveTowards (player.transform.position, disPlace1.position, Time.deltaTime * 5);

			if (player.transform.position == disPlace1.transform.position) 
			{
				cutsceneOrder = 3;
			}
		}

		if (cutsceneOrder == 3) 
		{
			player.GetComponent<Animator> ().SetBool ("Walk", true);
			player.transform.position = Vector3.MoveTowards (player.transform.position, disPlace2.position, Time.deltaTime * 5);

			if (player.transform.position == disPlace2.transform.position) 
			{
				cutsceneOrder = 4;
			}
		}

		if (cutsceneOrder == 4) 
		{
			player.GetComponent<Animator> ().SetBool ("Walk", true);
			player.transform.position = Vector3.MoveTowards (player.transform.position, disPlace3.position, Time.deltaTime * 5);

			if (player.transform.position == disPlace3.transform.position) 
			{
				player.GetComponent<Animator> ().SetBool ("Walk", false);
				cutsceneOrder = 5;
			}
		}

		if (cutsceneOrder == 5) 
		{
			music.SetActive (true);
			var kolor = bg.GetComponent<SpriteRenderer> ().color;
			kolor.a += Time.deltaTime/3;
			bg.GetComponent<SpriteRenderer> ().color = kolor;
			cutsceneOrder = 6;
		}

		if (cutsceneOrder == 6) 
		{
			darien.transform.position = Vector3.MoveTowards (darien.transform.position, darienPlace.position, Time.deltaTime/2);
			var kolor = bg.GetComponent<SpriteRenderer> ().color;
			kolor.a += Time.deltaTime/3;
			bg.GetComponent<SpriteRenderer> ().color = kolor;
			waitTime -= Time.deltaTime;
			if (waitTime <= 0) 
			{
				dialog1.SetActive (true);
			}

			if (darien.transform.position == darienPlace.transform.position)
			{
				theTextBox.currentLine = 0;
				cutsceneOrder = 7;
			}

		}

		if (cutsceneOrder == 7) 
		{
			dialog2.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				waitTime = 4;
				cutsceneOrder = 8;
			}  
		}

		if (cutsceneOrder == 8) 
		{
			var kolor = dark.GetComponent<SpriteRenderer> ().color;
			kolor.a += Time.deltaTime;
			dark.GetComponent<SpriteRenderer> ().color = kolor;
			waitTime -= Time.deltaTime;

			if (waitTime <= 0) 
			{
				theTextBox.currentLine = 0;
				cutsceneOrder = 9;
			}
		}

		if (cutsceneOrder == 9) 
		{
			dialog3.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {

				ScoreManager.saveScore ();
				PlayerPrefs.SetInt (levelTag, 1);
				Application.LoadLevel (LevelToLoad);
			}  
		}


	}
}
