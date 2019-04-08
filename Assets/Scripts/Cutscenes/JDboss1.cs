using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDboss1 : MonoBehaviour {

	public GameObject player;
	public GameObject darquel;
	public GameObject uberpow;
	public int cutsceneOrder;
	private float waitTime;
	public Transform disPlace;
	public Transform uberpowPlace;
	public TextBoxManager theTextBox;
	public GameObject textBox;

	public GameObject dialog1;
	public GameObject dialog2;
	public GameObject dialog3;
	public GameObject dialog4;

	public GameObject JDboss;
	public Animator JDanim;

	public GameObject biel;
	public AudioSource thunder;
	public Sprite uberpowUnmasked;
	public string levelToLoad;
	// Use this for initialization
	void Start () {
		
		theTextBox = FindObjectOfType<TextBoxManager> ();
		waitTime = 2f;

		JDanim = JDboss.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (cutsceneOrder == 0) {
			player.GetComponent<Animator> ().SetBool ("Walk", true);
			player.transform.position = Vector3.MoveTowards (player.transform.position, disPlace.position, Time.deltaTime * 5);
			if (player.transform.position == disPlace.transform.position) {
				player.GetComponent<Animator> ().SetBool ("Walk", false);

				cutsceneOrder = 1;
			}
		}

		if (cutsceneOrder == 1) {
			
			dialog1.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				cutsceneOrder = 2;
			}
		}

		if (cutsceneOrder == 2) {
			uberpow.GetComponent<Animator> ().SetInteger ("UberpowOrder", 1);
			uberpow.transform.position = Vector3.MoveTowards (uberpow.transform.position, uberpowPlace.position, Time.deltaTime * 3);
			if (uberpow.transform.position == uberpowPlace.transform.position) {
				theTextBox.currentLine = 0;
				uberpow.GetComponent<Animator> ().SetInteger ("UberpowOrder", 0);
				cutsceneOrder = 3;
			}
		}

		if (cutsceneOrder == 3) {
			dialog2.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				JDanim.SetInteger ("Order", 0);

				waitTime = 1.5f;
				cutsceneOrder = 4;
			}
		}

		if (cutsceneOrder == 4) {
			biel.SetActive (true);
			waitTime -= Time.deltaTime;
			if (waitTime <= 1f) {
				uberpow.GetComponent<Animator> ().SetInteger ("UberpowOrder", 2);
				thunder.enabled = true;

				if (waitTime <= 0) {
					

					biel.SetActive (false);
				
					theTextBox.currentLine = 0;
					cutsceneOrder = 5;
				}
			}
		}

			if (cutsceneOrder == 5) {
				dialog3.SetActive (true);
				if (theTextBox.currentLine > theTextBox.endAtLine) {
					JDanim.SetInteger ("Order", 0);
					waitTime = 0.43f;
					cutsceneOrder = 6;
				}
			}

		if (cutsceneOrder == 6) {
			JDanim.SetInteger ("Order", 1);
			waitTime -= Time.deltaTime;
			if (waitTime <= 0) 
			{
				theTextBox.currentLine = 0;
				cutsceneOrder = 7;
			}
		}

		if (cutsceneOrder == 7) {
			JDanim.SetInteger ("Order", 2);
			dialog4.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				JDanim.SetInteger ("Order", 0);
				waitTime = 0.43f;
				cutsceneOrder = 8;
			}
		}
		if (cutsceneOrder == 8) {

			Application.LoadLevel (levelToLoad);
		}


	}
}
