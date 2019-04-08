using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hecarim_2 : MonoBehaviour {

	public GameObject player;
	public GameObject kot;
	public int cutsceneOrder;
	private float waitTime;

	public GameObject dialog1;
	public GameObject dialog2;
	public GameObject dialog3;
	public GameObject dialog4;
	public GameObject dialog5;

	public TextBoxManager theTextBox;
	public GameObject textBox;

	public AudioSource morton1;
	public AudioSource morton2;
	public AudioSource morton3;
	public AudioSource morton4;

	public string levelToLoad;
	public string levelTag;
	// Use this for initialization
	void Start () {

		theTextBox = FindObjectOfType<TextBoxManager> ();
		waitTime = 2f;
		player.GetComponent<Animator> ().SetFloat ("Speed", 0);
		cutsceneOrder = 1;
	}
	
	// Update is called once per frame
	void Update () {

		if (cutsceneOrder == 1)
		{
			dialog1.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				cutsceneOrder = 2;
			}  
		}

		if (cutsceneOrder == 2) 
		{
			theTextBox.currentLine = 0;
			morton1.enabled = true;
			if (morton1.isPlaying == false)
			{
				cutsceneOrder = 3;
			}

		}

		if (cutsceneOrder == 3)
		{
			dialog2.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				cutsceneOrder = 4;
			}  
		}

		if (cutsceneOrder == 4) 
		{
			theTextBox.currentLine = 0;
			morton2.enabled = true;
			if (morton2.isPlaying == false)
			{
				cutsceneOrder = 5;
			}

		}

		if (cutsceneOrder == 5)
		{
			dialog3.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				cutsceneOrder = 6;
			}  
		}

		if (cutsceneOrder == 6) 
		{
			theTextBox.currentLine = 0;
			morton3.enabled = true;
			if (morton3.isPlaying == false)
			{
				cutsceneOrder = 7;
			}

		}

		if (cutsceneOrder == 7)
		{
			dialog4.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				cutsceneOrder = 8;
			}  
		}

		if (cutsceneOrder == 8) 
		{
			theTextBox.currentLine = 0;
			morton4.enabled = true;
			if (morton4.isPlaying == false)
			{
				cutsceneOrder = 9;
			}

		}

		if (cutsceneOrder == 9)
		{
			dialog5.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				cutsceneOrder = 10;
			}  
		}
		if (cutsceneOrder == 10) {
			PlayerPrefs.SetInt (levelTag, 1);
			Application.LoadLevel (levelToLoad);
		}

	}
}
