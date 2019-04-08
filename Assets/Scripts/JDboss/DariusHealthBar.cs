using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DariusHealthBar : MonoBehaviour {

	public HurtDarius enemyHealthScript;
	public Slider healthBar;


	// Use this for initialization
	void Start () {
		healthBar.maxValue = enemyHealthScript.dariusHealth;
	}

	// Update is called once per frame
	void Update () {
		healthBar.value = enemyHealthScript.dariusHealth;
	}
}


