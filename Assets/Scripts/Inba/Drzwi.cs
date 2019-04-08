using UnityEngine;
using System.Collections;

public class Drzwi : MonoBehaviour {

	public Sprite openSprite;
	public bool done;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (done == false){
		if (other.GetComponent<PlayerController> () == null)
			return;
		
		this.GetComponent<SpriteRenderer> ().sprite = openSprite;
		this.GetComponent<AudioSource> ().Play ();
		done = true;
		}
	}
	

}
