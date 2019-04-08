using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hecarim_1 : MonoBehaviour {

	public GameObject player;
	public GameObject hecarim;
	public GameObject nervarien;
	public int cutsceneOrder;
	private float waitTime;
	//
	public Transform disPlace;
	public Transform nervaPlace;
	public Transform hecaPlace;
	//

	public GameObject dialog1;
	public GameObject dialog2;
	public GameObject dialog3;
	public GameObject dialog4;
	public GameObject dialog5;
	public GameObject dialog6;
	public GameObject dialog7;
	public GameObject dialog8;
	public GameObject dialog9;
	public TextBoxManager theTextBox;
	public GameObject textBox;


	public bool startedOpeningHecarim;

	public AudioSource morton1;
	public AudioSource morton2;
	public AudioSource morton3;
	public AudioSource morton4;
	public AudioSource morton5;
	public AudioSource morton6;
	public AudioSource morton7;
	public AudioSource morton8;
	public AudioSource morton9;

	public string levelToLoad;

	// Use this for initialization
	void Start () {
		
		theTextBox = FindObjectOfType<TextBoxManager> ();
		waitTime = 2f;
	}
	
	// Update is called once per frame
	void Update () {



		if (player.transform.position == disPlace.transform.position) {
			player.GetComponent<Animator> ().SetFloat ("Speed", 0);
		}



		if (cutsceneOrder == 0) {
			
			player.GetComponent<Animator> ().SetBool ("Walk", true);
			player.transform.position = Vector3.MoveTowards (player.transform.position, disPlace.position, Time.deltaTime * 5);
			if (player.transform.position == disPlace.transform.position) {
				player.GetComponent<Animator> ().SetBool ("Walk", false);

				waitTime -= Time.deltaTime;
				if (waitTime <= 1f) {
					player.transform.localScale = new Vector3 (-1f, 1f, 1f);
					if (waitTime <= 0) {
						player.transform.localScale = new Vector3 (1f, 1f, 1f);
						nervarien.GetComponent<Animator> ().SetBool ("Walking", true);
						nervarien.transform.position = Vector3.MoveTowards (nervarien.transform.position, nervaPlace.position, Time.deltaTime * 5);
						if (nervarien.transform.position == nervaPlace.transform.position) {
							nervarien.GetComponent<Animator> ().SetBool ("Walking", false);
							player.transform.localScale = new Vector3 (-1f, 1f, 1f);
							Debug.Log("Order1");
							cutsceneOrder = 1;
						}

					}

				}

			}

		}


		if (cutsceneOrder == 1) {
			dialog1.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) {
				Debug.Log ("Order2");
				cutsceneOrder = 2;
			}  



		}

		if (cutsceneOrder == 2) {
			theTextBox.currentLine = 0;
			player.transform.localScale = new Vector3 (1f, 1f, 1f);
			hecarim.transform.position = Vector3.MoveTowards (hecarim.transform.position, hecaPlace.position, Time.deltaTime * 15);
			if (hecarim.transform.position == hecaPlace.transform.position) {
				
				if (startedOpeningHecarim == false) {
					hecarim.GetComponent<Animator> ().SetInteger ("State", 9);
					StartCoroutine ("OpeningHecarimCo");
					startedOpeningHecarim = true;
				}
			}

		}

		if (cutsceneOrder == 3) {
			dialog2.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) 
			{
				Debug.Log ("Order4");
				cutsceneOrder = 4;
			}  
		}

		if (cutsceneOrder == 4) 
		{
			theTextBox.currentLine = 0;
			morton1.enabled = true;
			if (morton1.isPlaying == false)
			{
				Debug.Log ("Order5");
				cutsceneOrder = 5;
			}

		}

		if (cutsceneOrder == 5) 
		{
			dialog3.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) 
			{
				Debug.Log ("Order6");
				cutsceneOrder = 6;
			}  
		}

		if (cutsceneOrder == 6) 
		{
			morton2.enabled = true;
			theTextBox.currentLine = 0;
			if (morton2.isPlaying == false)
			{
				Debug.Log ("Order7");
				cutsceneOrder = 7;
			}

		}

		if (cutsceneOrder == 7) 
		{
			dialog4.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) 
			{
				Debug.Log ("Order8");
				cutsceneOrder = 8;
			}  
		}

		if (cutsceneOrder == 8) 
		{
			morton3.enabled = true;
			theTextBox.currentLine = 0;
			if (morton3.isPlaying == false)
			{
				Debug.Log ("Order9");
				cutsceneOrder = 9;
			}

		}

		if (cutsceneOrder == 9) 
		{
			dialog5.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) 
			{
				Debug.Log ("Order10");
				cutsceneOrder = 10;
			}  
		}

		if (cutsceneOrder == 10) 
		{
			morton4.enabled = true;
			theTextBox.currentLine = 0;
			if (morton4.isPlaying == false)
			{
				Debug.Log ("Order11");
				cutsceneOrder = 11;
			}

		}

		if (cutsceneOrder == 11) 
		{
			dialog6.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) 
			{
				Debug.Log ("Order12");
				cutsceneOrder = 12;
			}  
		}

		if (cutsceneOrder == 12) 
		{
			morton5.enabled = true;
			theTextBox.currentLine = 0;
			if (morton5.isPlaying == false)
			{
				Debug.Log ("Order13");
				cutsceneOrder = 13;
			}

		}

		if (cutsceneOrder == 13) 
		{
			dialog7.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) 
			{
				Debug.Log ("Order14");
				cutsceneOrder = 14;
			}  
		}

		if (cutsceneOrder == 14) 
		{
			morton6.enabled = true;
			theTextBox.currentLine = 0;
			if (morton6.isPlaying == false)
			{
				Debug.Log ("Order15");
				cutsceneOrder = 15;
			}

		}

		if (cutsceneOrder == 15) 
		{
			dialog8.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) 
			{
				Debug.Log ("Order16");
				cutsceneOrder = 16;
			}  
		}

		if (cutsceneOrder == 16) 
		{
			morton7.enabled = true;
			theTextBox.currentLine = 0;
			if (morton7.isPlaying == false)
			{Debug.Log ("Order17");
				cutsceneOrder = 17;
			}

		}

		if (cutsceneOrder == 17) 
		{
			dialog9.SetActive (true);
			if (theTextBox.currentLine > theTextBox.endAtLine) 
			{
				Debug.Log ("Order18");
				cutsceneOrder = 18;
			}  
		}

		if (cutsceneOrder == 18) 
		{
			morton8.enabled = true;
			theTextBox.currentLine = 0;
			if (morton8.isPlaying == false)
			{
				Application.LoadLevel (levelToLoad);
				Debug.Log ("Order19");
				cutsceneOrder = 19;
			}

		}

	}

	public IEnumerator OpeningHecarimCo()
	{
		hecarim.GetComponent<Animator>().SetInteger ("State", 6);
		yield return new WaitForSeconds (0.38f);
		hecarim.GetComponent<Animator>().SetInteger ("State", 7);
		Debug.Log ("Order3");
		cutsceneOrder = 3;
		startedOpeningHecarim = false;
	}
}
