using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
	
	public AudioSource source;
	public AudioClip defaultClip;
	public AudioClip[] characterClip;
	public string[] characterName;
	//private string actualName;
	//private bool isDoing=false; 
	
	public GameObject textBox;
	public Text theText;
	
	
	public TextAsset textFile;
	public string[] textLines;
	
	public int currentLine;
	public int endAtLine;
	
	public PlayerController player;
	
	public bool isActive;
	
	public bool stopPlayerMovement;
	
	private bool isTyping = false;
	private bool cancelTyping = false;
	
	public float typeSpeed;
	
	public int generalOrder = 1;

	public bool automaticClick;
	public bool disableClicking;

	public TouchControls touchControls;

	// Use this for initialization
	void Start ()
	{
		touchControls = FindObjectOfType<TouchControls> ();
		player = FindObjectOfType<PlayerController> ();
		
		if (textFile != null)
		{
			textLines = (textFile.text.Split('\n'));
		}
		
		if (endAtLine == 0) 
		{
			endAtLine = textLines.Length -1;
		}
		
		if (isActive) {
			EnableTextBox ();
		} else {
			DisableTextBox ();
		}
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (!isActive) 
		{
			return;
		}
		//theText.text = textLines [currentLine];
		if (disableClicking == false) {
			if (Input.GetButtonDown ("Jump") || touchControls.textBoxAction == true ) {
				if (touchControls.isActiveAndEnabled) {
					touchControls.textBoxAction = false;
				}
				if (!isTyping) {
				
					currentLine += 1;
				
					if (currentLine > endAtLine) {
					
						DisableTextBox ();
						generalOrder += 1;
						return;
					} else {
					
						for (int i = 0; i < characterName.Length; i++) {
							if (textLines [currentLine].Substring (0, characterName [i].Length) == characterName [i]) {
							
								defaultClip = characterClip [i];
							
								break;
							}
						}
						if (!isTyping) {
							StartCoroutine (TextScroll (textLines [currentLine]));
						}
					}
				} else if (isTyping && !cancelTyping) {
					cancelTyping = true;
				}
			}
		}

		if (automaticClick == true) 
		{
			if(!isTyping)
			{

				currentLine +=1;

				if (currentLine > endAtLine) 
				{

					DisableTextBox();
					generalOrder +=1;
					return;
				} else 
				{

					for(int i=0; i<characterName.Length; i++){
						if(textLines[currentLine].Substring (0,characterName[i].Length) == characterName[i]){

							defaultClip = characterClip[i];

							break;
						}
					}
					if(!isTyping){
						StartCoroutine(TextScroll(textLines[currentLine]));
					}
				}
			} else if(isTyping && !cancelTyping)
			{
				cancelTyping = true;
			}

			automaticClick = false;
		}
		
		
	}
	
	private IEnumerator TextScroll (string lineOfText)
	{
		int letter = 0;
		theText.text = "";
		isTyping = true;
		cancelTyping = false;
		while (isTyping && !cancelTyping && (letter < lineOfText.Length -1))
		{
			if(source != null && defaultClip != null){
				source.PlayOneShot(defaultClip);
			}
			theText.text += lineOfText[letter];
			letter += 1;
			yield return new WaitForSeconds(typeSpeed);
		}
		theText.text = lineOfText;
		isTyping = false;
		cancelTyping = false;
	}
	
	public void EnableTextBox()
	{
		textBox.SetActive(true);
		isActive = true;
		if (stopPlayerMovement)
		{
			player.GetComponent<Animator> ().SetBool ("Grounded", true);
			player.canMove = false;
		}
		if(!isTyping){
			for(int i=0; i<characterName.Length; i++){
				if(textLines[currentLine].Substring (0,characterName[i].Length) == characterName[i]){
					
					defaultClip = characterClip[i];
					
					break;
				}
			}
			StartCoroutine(TextScroll(textLines[currentLine]));
		}
	}
	
	public void DisableTextBox()
	{
		
		textBox.SetActive(false);
		isActive = false;
		player.canMove = true;
		
	}
	
	public void ReloadScript(TextAsset theText)
	{
		if (theText != null) 
		{
			textLines = new string[1];
			textLines = (theText.text.Split('\n'));
		}
	}
}