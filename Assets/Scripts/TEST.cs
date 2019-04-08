using UnityEngine;
using System.Collections;

public class TEST : MonoBehaviour {

	public GameObject Tyl;
	public GameObject Przod;
	public SpriteRenderer SpriteTyl;
	public SpriteRenderer SpritePrzod;
	void Start(){
		Tyl.transform.position = new Vector3(Tyl.transform.position.x,Tyl.transform.position.y,1-(SpriteTyl.sprite.bounds.size.x/(SpritePrzod.sprite.bounds.size.x/(1-Przod.transform.position.z))));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
