using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
public class NewAndro : MonoBehaviour {

	string url = "https://chopey.com/cloud/GameStatus.json";
	public GameObject cokolwiek;
	private bool onOff;
	private bool incaseOnOff;
	public string gpLink;
	public GameObject incaseText;
	public string message2;
	// Use this for initialization
	void Start () {
		
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www));

	}

	void Update()
	{
		if (onOff) {
			cokolwiek.SetActive (true);
		
		} 
		else 
		{
			cokolwiek.SetActive (false);
		
		}

		if (incaseOnOff) 
		{
			//incaseText.SetActive (true);
			//incaseText.GetComponent<Text> ().text = message2;
		} 
		else 
		{
			incaseText.SetActive (false);
		}
	}


	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		if (www.error == null) {
			var obj = JSON.Parse (www.text);

			bool newVersion = obj["newVersion"].AsBool;
			bool msgBool = obj["msgBool"].AsBool;
			gpLink = obj ["downloadUrl"];
			string message = obj ["message"];
			if (newVersion == true) 
			{
				onOff = true;
				cokolwiek.SetActive (true);
				Debug.Log ("JestGit");
				//Destroy (this);
			} 
			else 
			{
				onOff = false;
				cokolwiek.SetActive (false);
				//Destroy (this);
			}

			if (msgBool == true) 
			{
				incaseText.SetActive (false);
				message2 = message;
				incaseText.GetComponent<Text> ().text = message;
				incaseOnOff = true;
			} 
			else 
			{
				incaseText.SetActive (false);
				incaseOnOff = false;
			}

		} 
	}

}
