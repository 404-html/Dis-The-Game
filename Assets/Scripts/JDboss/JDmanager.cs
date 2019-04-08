using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDmanager : MonoBehaviour {

	public HurtDarius dariusHP;
	public EnemyHealthManager jinxHP;

	public string levelToLoad;
	public float waitTime;

	public GameObject musicSpawner;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () {

		if (dariusHP.dariusHealth <= 0 && jinxHP.enemyHealth <= 0) 
		{
			waitTime -= Time.deltaTime;
				if (waitTime <= 0)
				{
				Destroy (GameObject.FindGameObjectWithTag ("Music"));
				Destroy (musicSpawner);
					Application.LoadLevel (levelToLoad);
				}
		}

	}
}
