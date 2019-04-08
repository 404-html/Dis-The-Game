using UnityEngine;
using System.Collections;

public class SmartBullet : MonoBehaviour {

	public Transform direction;
	public PlayerController player;
	public float moveSpeed;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		direction.transform.position = player.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, direction.position, Time.deltaTime * moveSpeed);
	}
}
