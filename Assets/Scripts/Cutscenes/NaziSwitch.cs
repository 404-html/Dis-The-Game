using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaziSwitch : MonoBehaviour {

	public Wiec manager;
	public GameObject operationObj;
	public Sprite naziSprite;
	public Transform newPosition;


	// Use this for initialization
	void Start () {

		manager = FindObjectOfType<Wiec>();
	}
	
	// Update is called once per frame
	void Update () {

		if ( manager.naziTransform == true)
		{
			operationObj.GetComponent<SpriteRenderer>().sprite = naziSprite;
			operationObj.transform.position = newPosition.transform.position;
			this.GetComponent<NaziSwitch> ().enabled = false;
		}

	}
}
