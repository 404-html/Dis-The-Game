using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDboss2 : MonoBehaviour {

	public GameObject player;
	public int cutsceneOrder;
	private float waitTime;
	public Transform disPlace;

	public TextBoxManager theTextBox;
	public GameObject textBox;

	public GameObject dialog1;
	public GameObject dialog2;

	public Sprite spuszczonaGlowa;
	public Sprite gokuDis;

	public GameObject animacja;
	public GameObject mainHUD;

	public string lvlToLoad;
	// Use this for initialization
	void Start () {
		
		theTextBox = FindObjectOfType<TextBoxManager> ();
		waitTime = 2f;
		theTextBox.currentLine = 0;
		mainHUD.SetActive (false);
		theTextBox.disableClicking = true;


	}
	
	// Update is called once per frame
	void Update () {

		if (cutsceneOrder == 0) {
			dialog1.SetActive (true);

			if (theTextBox.currentLine <= theTextBox.endAtLine) 
			{
				waitTime -= Time.deltaTime;
				if (waitTime <= 0) 
				{
					
					theTextBox.automaticClick = true;
					waitTime = 2f;
				}
			}

			if (theTextBox.currentLine > theTextBox.endAtLine) {
				cutsceneOrder = 1;
			}
		}

		if (cutsceneOrder == 1) {
			player.transform.localScale = new Vector3 (-1f, 1f, 1f);
			player.GetComponent<Animator> ().SetBool ("Walk", true);
			player.transform.position = Vector3.MoveTowards (player.transform.position, disPlace.position, Time.deltaTime * 1);
			if (player.transform.position == disPlace.transform.position) {
				player.GetComponent<Animator> ().SetBool ("Walk", false);
				cutsceneOrder = 2;
			}
		}
		if (cutsceneOrder == 2) {
			player.GetComponent<Animator> ().SetBool ("Walk", false);
			waitTime -= Time.deltaTime;
			if (waitTime <= 1f)
			{
				player.GetComponent<Animator> ().enabled = false;
				player.GetComponent<SpriteRenderer> ().sprite = spuszczonaGlowa;
				if (waitTime <= 0) 
				{
					theTextBox.currentLine = 0;
					cutsceneOrder = 3;
				}
			}
		}



		if (cutsceneOrder == 3) {
			dialog2.SetActive (true);
			if (theTextBox.currentLine <= theTextBox.endAtLine) 
			{
				waitTime -= Time.deltaTime;
				if (waitTime <= 0) 
				{

					theTextBox.automaticClick = true;
					waitTime = 2f;
				}
			}
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				waitTime = 1f;
				cutsceneOrder = 4;
			}
		}

		if (cutsceneOrder == 4) 
		{
			player.GetComponent<SpriteRenderer> ().sprite = gokuDis;
			waitTime -= Time.deltaTime;
			if (waitTime <= 0) 
			{
				animacja.GetComponent<Animator> ().SetBool ("Start", true);
				waitTime = 5.5f;
				cutsceneOrder = 5;
			}
		}

		if (cutsceneOrder == 5) 
		{
			waitTime -= Time.deltaTime;
			if (waitTime <= 0) 
			{
				Application.LoadLevel (lvlToLoad);
			}
		}

	}
}
