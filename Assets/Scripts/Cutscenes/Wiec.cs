using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiec : MonoBehaviour {

	public bool naziTransform;

	public int cutsceneOrder;
	private float waitTime;

	public GameObject dialog1;
	public GameObject dialog2;
	public GameObject dialog3;
	public GameObject dialog4;
	public GameObject dialog5;
	public GameObject dialog6;
	public GameObject dialog7;
	public GameObject dialog8;
	public GameObject dialog9;
	public GameObject dialog10;
	public GameObject dialog11;
	public GameObject dialog12;
	public GameObject dialog13;
	public GameObject dialog14;
	public GameObject dialog15;
	public GameObject dialog16;
	public GameObject dialog17;
	public GameObject dialog18;

	public TextBoxManager theTextBox;
	public GameObject textBox;

	public AudioSource morton1;
	public AudioSource morton2;
	public AudioSource morton3;
	public AudioSource morton4;
	public AudioSource morton5;
	public AudioSource morton6;
	public AudioSource crowd;
	public AudioSource crowdShort;

	public string levelToLoad;
	public string levelTag;


	public AudioSource thunder;
	public GameObject biel;

	// Use this for initialization
	void Start () {

		naziTransform = false;
		cutsceneOrder = 1;
		theTextBox = FindObjectOfType<TextBoxManager> ();
		waitTime = 2f;
	}
	
	// Update is called once per frame
	void Update () {

		if (cutsceneOrder == 1)
		{
			dialog1.SetActive (true);
			morton5.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && morton5.isPlaying == false ) {
				theTextBox.currentLine = 0;
				morton5.enabled = false;
				cutsceneOrder = 2;
			}  
		}

		if (cutsceneOrder == 2)
		{
			dialog2.SetActive (true);
			morton1.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && morton1.isPlaying == false) {
				theTextBox.currentLine = 0;
				morton1.enabled = false;
				cutsceneOrder = 3;
			}  
		}

		if (cutsceneOrder == 3)
		{
			dialog3.SetActive (true);
			crowdShort.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && crowdShort.isPlaying == false) {
				crowdShort.enabled = false;
				theTextBox.currentLine = 0;
				cutsceneOrder = 4;
			}  
		}

		if (cutsceneOrder == 4)
		{
			dialog4.SetActive (true);
			morton2.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && morton2.isPlaying == false) {
				theTextBox.currentLine = 0;
				morton2.enabled = false;
				cutsceneOrder = 5;
			}  
		}

		if (cutsceneOrder == 5)
		{
			dialog5.SetActive (true);
			crowdShort.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && crowdShort.isPlaying == false) {
				crowdShort.enabled = false;
				theTextBox.currentLine = 0;
				cutsceneOrder = 6;
			}  
		}

		if (cutsceneOrder == 6)
		{
			dialog6.SetActive (true);
			morton3.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && morton3.isPlaying == false) {
				theTextBox.currentLine = 0;
				morton3.enabled = false;
				cutsceneOrder = 7;
			}  
		}

		if (cutsceneOrder == 7)
		{
			dialog7.SetActive (true);
			morton4.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && morton4.isPlaying == false) {
				theTextBox.currentLine = 0;
				morton4.enabled = false;
				cutsceneOrder = 8;
			}  
		}

		if (cutsceneOrder == 8)
		{
			dialog8.SetActive (true);
			morton5.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && morton5.isPlaying == false) {
				theTextBox.currentLine = 0;
				morton5.enabled = false;
				cutsceneOrder = 9;
			}  
		}

		if (cutsceneOrder == 9)
		{
			dialog9.SetActive (true);
			morton6.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && morton6.isPlaying == false) {
				theTextBox.currentLine = 0;
				morton6.enabled = false;
				cutsceneOrder = 10;
			}  
		}

		if (cutsceneOrder == 10)
		{
			dialog10.SetActive (true);
			morton1.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && morton1.isPlaying == false) {
				theTextBox.currentLine = 0;
				morton1.enabled = false;
				cutsceneOrder = 11;
			}  
		}

		if (cutsceneOrder == 11)
		{
			dialog11.SetActive (true);
			morton2.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && morton2.isPlaying == false) {
				theTextBox.currentLine = 0;
				morton2.enabled = false;
				cutsceneOrder = 12;
			}  
		}

		if (cutsceneOrder == 12)
		{
			dialog12.SetActive (true);
			crowdShort.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && crowdShort.isPlaying == false) {
				crowdShort.enabled = false;
				theTextBox.currentLine = 0;
				cutsceneOrder = 13;
			}  
		}

		if (cutsceneOrder == 13) 
		{
			waitTime -= Time.deltaTime;
			biel.SetActive(true);
			thunder.enabled = true;
			naziTransform = true;
			if (waitTime <= 0) 
			{
				biel.SetActive(false);
				cutsceneOrder = 14;
			}
		}

		if (cutsceneOrder == 14)
		{
			dialog13.SetActive (true);
			morton3.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && morton3.isPlaying == false) {
				morton3.enabled = false;
				theTextBox.currentLine = 0;
				cutsceneOrder = 15;
			}  
		}

		if (cutsceneOrder == 15)
		{
			dialog14.SetActive (true);
			crowdShort.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && crowdShort.isPlaying == false) {
				crowdShort.enabled = false;
				theTextBox.currentLine = 0;
				cutsceneOrder = 16;
			}  
		}

		if (cutsceneOrder == 16)
		{
			dialog15.SetActive (true);
			morton4.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && morton4.isPlaying == false) {
				morton4.enabled = false;
				theTextBox.currentLine = 0;
				cutsceneOrder = 17;
			}  
		}

		if (cutsceneOrder == 17)
		{
			dialog16.SetActive (true);
			crowdShort.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && crowdShort.isPlaying == false) {
				crowdShort.enabled = false;
				theTextBox.currentLine = 0;
				cutsceneOrder = 18;
			}  
		}

		if (cutsceneOrder == 18)
		{
			dialog17.SetActive (true);
			morton5.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && morton5.isPlaying == false) {
				morton5.enabled = false;
				theTextBox.currentLine = 0;
				cutsceneOrder = 19;
			}  
		}

		if (cutsceneOrder == 19)
		{
			dialog18.SetActive (true);
			crowd.enabled = true;
			if (theTextBox.currentLine > theTextBox.endAtLine && crowd.isPlaying == false) {
				crowd.enabled = false;
				theTextBox.currentLine = 0;
				cutsceneOrder = 20;
			}  
		}

		if (cutsceneOrder == 20)
		{
			PlayerPrefs.SetInt (levelTag, 1);
			Application.LoadLevel (levelToLoad);
		}

	}
}
