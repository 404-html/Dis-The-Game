using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateSaver : MonoBehaviour {

	public ScoreManager scoreManager;
	public bool nullifying;

	// Use this for initialization
	void Start () {
		scoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (nullifying == true) 
		{
			PlayerPrefs.SetInt ("WeaponPoints" , 0);
		}
		ScoreManager.saveScore ();

	}
}
