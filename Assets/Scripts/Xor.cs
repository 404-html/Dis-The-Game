using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xor : MonoBehaviour {

	public GameObject s1;
	public GameObject s2;
	public GameObject s3;
	public GameObject s4;
	public GameObject s5;
	public GameObject s6;
	public GameObject sound;
	public GameObject blokada;
	public Transform unlockPos;
	public float moveSpeed;

	public GameObject silnik;
	public GameObject ekran;
	public Sprite ekranGoodSprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
			if(s1.GetComponent<XorSwitch> ().up == true &&
			   s2.GetComponent<XorSwitch> ().up == true &&
			   s3.GetComponent<XorSwitch> ().up == false &&
			   s4.GetComponent<XorSwitch> ().up == false &&
				s5.GetComponent<XorSwitch> ().up == true &&
			   s6.GetComponent<XorSwitch> ().up == false) {
			sound.GetComponent<AudioSource> ().enabled = true;
				blokada.transform.position = Vector3.MoveTowards (blokada.transform.position, unlockPos.position, Time.deltaTime * moveSpeed);
				Destroy(silnik);
				ekran.GetComponent<SpriteRenderer> ().sprite = ekranGoodSprite;
			}
	
	}
}
