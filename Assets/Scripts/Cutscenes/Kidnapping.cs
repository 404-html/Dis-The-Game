using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kidnapping : MonoBehaviour {

	public GameObject player;
	public GameObject nitro;
	public GameObject nervarien;
	public GameObject yerba;
	private GameObject yerba2;
	private GameObject kiara;
	private GameObject kiaraPokaz;

	public int cutsceneOrder;
	private float waitTime;

	public Transform yerbaPlace;
	public Transform yerbaDisappearPlace;
	public GameObject dialog1;
	public GameObject dialog2;
	public GameObject dialog3;
	public GameObject dialog4;

	public TextBoxManager theTextBox;
	public GameObject textBox;

	public string levelToLoad;
	public string levelTag;
	public GameObject biel;
	public AudioSource nitroDeath;
	public Sprite bestia;
	public AudioSource thunder;
	public AudioSource roar;
	// Use this for initialization
	void Start () {

		theTextBox = FindObjectOfType<TextBoxManager> ();
		waitTime = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {

		if (cutsceneOrder == 0) 
		{
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				cutsceneOrder = 1;
			}
		}

		if (cutsceneOrder == 1) 
		{
			biel.SetActive(true);
			waitTime -= Time.deltaTime;
			if (waitTime <= 1f)
			{
				nitroDeath.enabled = true;
				Destroy (nitro);

				if (waitTime <= 0)
				{
					biel.SetActive(false);
					Instantiate (yerba, yerbaPlace.transform.position, yerbaPlace.transform.rotation);
					theTextBox.currentLine = 2;
					cutsceneOrder = 2;
				}
			}
		}

		if (cutsceneOrder == 2) 
		{
			dialog2.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				cutsceneOrder = 3;
			}  

		}

		if (cutsceneOrder == 3) 
		{
			kiara = GameObject.Find ("Kiara");
			kiaraPokaz = GameObject.Find ("KiaraPokaz");
			kiara.transform.position = Vector3.MoveTowards (kiara.transform.position, kiaraPokaz.transform.position, Time.deltaTime * 1);
			if (kiara.transform.position == kiaraPokaz.transform.position) 
			{
				theTextBox.currentLine = 2;
				cutsceneOrder = 4;
			}
		}

		if ( cutsceneOrder == 4)
		{
			dialog3.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				cutsceneOrder = 5;
			}  
		}

		if (cutsceneOrder == 5) 
		{
			yerba2 = GameObject.Find ("YerbaAboveAll(Clone)");

			yerba2.transform.position = Vector3.MoveTowards (yerba2.transform.position, yerbaDisappearPlace.transform.position, Time.deltaTime * 5);
			if (yerba2.transform.position == yerbaDisappearPlace.transform.position) 
			{
				theTextBox.currentLine = 2;
				cutsceneOrder = 6;
			}

		}

		if ( cutsceneOrder == 6)
		{
			dialog4.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				waitTime = 9f;
				cutsceneOrder = 7;
			}  
		}

		if ( cutsceneOrder == 7)
		{
			waitTime -= Time.deltaTime;
			biel.SetActive(true);
			player.GetComponent<Animator> ().enabled = false;
			player.GetComponent<SpriteRenderer> ().sprite = bestia;
			player.transform.localScale = new Vector3 (1.5f, 1.5f, 1.2f);
			player.transform.position = new Vector3 (-17.4f, 6f, 0f);
			thunder.enabled = true;
			if (waitTime <= 7f) 
			{
				roar.enabled = true;
				if (waitTime <= 4f) 
				{
					biel.SetActive(false);
					if (waitTime <= 1.5f) 
						PlayerPrefs.SetInt (levelTag, 1);
					
						Application.LoadLevel (levelToLoad);
				}
			}

		}
	}
}
