using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour {

	public string levelTag;
	// Use this for initialization
	void Start () {
		
		PlayerPrefs.SetInt (levelTag, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
