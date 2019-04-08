using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DariusMovement : MonoBehaviour {

	public GameObject darius;
	public Animator anim;
	public GameObject player;
	public int ultTurn;
	public int drawInt;
	public bool canDraw;

	public Transform playerMarker;
	public Transform highestJumpPoint;
	public Transform dariusOnPlatformPoint;

	public float platformJumpCoordinate;
	public Transform platformJumpParabole;
	public bool coordinateLoaded;
	private bool doszedl;

	private float waitTime;
	private bool leci;
	private bool dolecial; 
	private bool stoiPoLocie;
	private bool ultuje;
	private bool leciJebany;
	private bool spadaSkurwysyn;

	private int order;

	public Transform currentPoint;

	public Transform[] points;

	public int pointSelection;

	public GameObject swingSound;
	public GameObject hitSound;



	// Use this for initialization
	void Start () {
		anim = darius.GetComponent<Animator> ();
		waitTime = 0.915f;
		drawInt = 1;
		ultTurn = 1;
		currentPoint = points [pointSelection];
	}
	
	// Update is called once per frame
	void Update () {

		if (drawInt != 0) {
			if (pointSelection == 0) {
				
			

				anim.SetInteger ("State", 1);

			}
			if (pointSelection == 1) {
				


				anim.SetInteger ("State", 10);
			}
		} else {
			darius.transform.localScale = new Vector3 (-1f, 1f, 1f);
		}


		if (ultTurn <= 2 && ultTurn > 0)
		{
			if (canDraw == true) 
			{
				drawInt = Random.Range (1, 3);
				print (drawInt);
			}

		} 
		else 
		{
			if (canDraw == true) {
				drawInt = 0;
				ultTurn = 0;
			}
		}


		if (drawInt == 0) {
			darius.transform.localScale = new Vector3 (-1f, 1f, 1f);
			//playerMarker.transform.position = new Vector3 (player.transform.position.x, -0.4f, 0);
			//highestJumpPoint.transform.position = new Vector3 (playerMarker.transform.position.x - 7f, 15f, 0);

			// ZAZNACZENIE POŁOWY TRASY MIĘDZY DARIUSEM A PLATFORMĄ I POSTAWIENIE PUNKTU
			if (coordinateLoaded == false) {
				platformJumpCoordinate = (darius.transform.position.x - dariusOnPlatformPoint.transform.position.x) / 2;
				coordinateLoaded = true;
			}


		
			platformJumpParabole.transform.position = new Vector3 (dariusOnPlatformPoint.transform.position.x + platformJumpCoordinate, 13f, 0);

			// ==================
			// ==================
			if (order == 0) {
				canDraw = false;
				anim.SetInteger ("State", 2);
				waitTime -= Time.deltaTime;
				if (waitTime <= 0) {
					waitTime = 1.5f;
					order = 1;
				}
			}
			if (order == 1) {
				darius.transform.position = Vector3.MoveTowards (darius.transform.position, platformJumpParabole.transform.position, Time.deltaTime * 25f);

				anim.SetInteger ("State", 6);
				//GameObject.FindGameObjectWithTag ("Darius").GetComponent<PolygonCollider2D> ().enabled = false;
				if (darius.transform.position == platformJumpParabole.transform.position) {


					order = 2;
				}

			}

			if (order == 2)
			{
				darius.transform.position = Vector3.MoveTowards (darius.transform.position, dariusOnPlatformPoint.transform.position, Time.deltaTime * 25f);

				if (darius.transform.position == dariusOnPlatformPoint.transform.position ) {
					order = 3;
				}
			}

			if (order == 3) 
			{
				waitTime -= Time.deltaTime;
				swingSound.GetComponent<AudioSource> ().Play ();
				anim.SetInteger ("State", 7);
				if (waitTime <= 0) {

					order = 4;
				}
			}
			if (order == 4)
			{
				anim.SetInteger ("State", 4);
				darius.transform.localScale = new Vector3 (-1f, 1f, 1f);
				playerMarker.transform.position = new Vector3 (player.transform.position.x, -0.4f, 0);
				highestJumpPoint.transform.position = new Vector3 (playerMarker.transform.position.x - 7f, 15f, 0);
				darius.transform.position = Vector3.MoveTowards (darius.transform.position, highestJumpPoint.transform.position, Time.deltaTime * 40f);
				if(darius.transform.position == highestJumpPoint.transform.position )
					{
					waitTime = 0.2f;
						playerMarker.transform.position = new Vector3 (player.transform.position.x -12f, -0.4f, 0);
						order = 5;
					}
			}
			if (order == 5) 
			{
				hitSound.GetComponent<AudioSource> ().Play ();
				darius.transform.position = Vector3.MoveTowards (darius.transform.position, playerMarker.transform.position, Time.deltaTime * 60f);
				if (darius.transform.position == playerMarker.transform.position ) 
				{
					darius.transform.position = new Vector3 (darius.transform.position.x, darius.transform.position.y, darius.transform.position.z);
					anim.SetInteger ("State", 8);
					waitTime -= Time.deltaTime;
					if (waitTime <= 0) 
					{
						waitTime = 3f;
						order = 6;
					}
				}
			}
			if (order == 6) 
			{
				anim.SetInteger ("State", 5);
				waitTime -= Time.deltaTime;
				if (waitTime <= 0) 
				{
					waitTime = 0.5f;
					order = 7;
				}
			}

			if (order == 7) 
			{
				anim.SetInteger ("State", 9);
				waitTime -= Time.deltaTime;
				if (waitTime <= 0) 
				{
					waitTime = 0.915f;
					ultTurn++;
					canDraw = true;
					order = 0;
				}
			}

		}

		//============
		//============

		if (drawInt == 1) 
		{
			
			canDraw = false;
			darius.transform.position = Vector3.MoveTowards (darius.transform.position, currentPoint.position, Time.deltaTime * 10);
			if (darius.transform.position == currentPoint.position) {
				pointSelection++;
				canDraw = true;;
				ultTurn++;
				if (pointSelection == points.Length) {
					pointSelection = 0;

				}
				currentPoint = points [pointSelection];
			}

		}

		if (drawInt == 2) 
		{
			


			canDraw = false;
			darius.transform.position = Vector3.MoveTowards (darius.transform.position, currentPoint.position, Time.deltaTime * 10);
			if (darius.transform.position == currentPoint.position) {
				pointSelection++;
				canDraw = true;;
				ultTurn++;
				if (pointSelection == points.Length) {
					pointSelection = 0;

				}
				currentPoint = points [pointSelection];
			}




		}




	}
}
