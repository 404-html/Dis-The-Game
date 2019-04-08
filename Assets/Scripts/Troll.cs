using UnityEngine;
using System.Collections;

public class Troll : MonoBehaviour {

	private PlayerController thePlayer;
	
	public float moveSpeed;
	public float playerRange;
	
	public LayerMask playerLayer;
	
	public bool playerInRange;
	public bool facingAway;
	public bool followOnLookAway;
	public float turnTime;
	private float realTurnTime;

	// Use this for initialization
	
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();


	}
	
	// Update is called once per frame
	void Update () {
		
		playerInRange = Physics2D.OverlapCircle (transform.position, playerRange, playerLayer);

		if (thePlayer.hitted == true)
		{
			return;
		}
		if (!followOnLookAway)
		{
		
			if (playerInRange)
			{
				transform.position = Vector3.MoveTowards (transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
				return;

			}
		}
		if ((thePlayer.transform.position.x < transform.position.x && thePlayer.transform.localScale.x < 0) ||
			(thePlayer.transform.position.x > transform.position.x && thePlayer.transform.localScale.x > 0)) 
		{


			facingAway = true;
			GetComponent<Animator> ().SetBool ("facingAway", true); 
			GetComponent<EnemyHealthManager> ().enabled = true;
		} 
		else 
		{



			realTurnTime -= Time.deltaTime;
			if (realTurnTime < 0)
			{

			facingAway = false;
			GetComponent<Animator> ().SetBool ("facingAway", false); 
			GetComponent<EnemyHealthManager>().enabled = false;
			GetComponent<EnemyHealthManager>().enemyHealth = 1;
			realTurnTime = turnTime; 
			}
		}

		if (playerInRange && facingAway)
		{
			transform.position = Vector3.MoveTowards (transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);

			
		}

	}
	
	void OnDrawGizmosSelected ()
	{
		Gizmos.DrawSphere(transform.position, playerRange);
	}
}

