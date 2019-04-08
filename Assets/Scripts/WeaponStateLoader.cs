using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateLoader : MonoBehaviour {

	public ScoreManager scoreManager;
	public float waitTime;
	public int weaponPoints;
	// Use this for initialization
	void Start () {


		scoreManager = FindObjectOfType<ScoreManager> ();
		scoreManager.weaponPoints = (PlayerPrefs.GetInt ("WeaponPoints"));
			waitTime = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		
		waitTime -= Time.deltaTime;
		if (waitTime <= 0) {
			weaponPoints = (PlayerPrefs.GetInt ("WeaponPoints"));
				for (int i = 0; i < weaponPoints -1 ; i++) {
					ScoreManager.AddPoints (1);
				}
				Destroy (gameObject);
			
		}

	}
}
