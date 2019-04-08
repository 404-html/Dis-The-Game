using UnityEngine;
using System.Collections;

public class BeastController : MonoBehaviour {

public float moveSpeed;
private float moveVelocity;
public float JumpHeight;

public Transform groundCheck;
public float groundCheckRadius;
public LayerMask whatIsGround;
public bool grounded;

private bool doubleJumped;

private Animator anim;

public Transform firePoint;
public GameObject bullet;
public float shotDelay;
private float shotDelayCounter;

public float knockback;
public float knockbackLength;
public float knockbackCount;
public bool knockFromRight;

private Rigidbody2D myrigidbody2d;

public bool shooted;
public bool ulted;
public bool hitted;
public float hurtTime;

public bool canMove;

public AudioSource jumpSound;
public float accelerationFactor;
public float acceleration;
// Use this for initialization
void Start () {
	anim = GetComponent<Animator> ();
	
	myrigidbody2d = GetComponent<Rigidbody2D> ();
	
}

void FixedUpdate () {
	
	grounded = Physics2D.OverlapCircle (groundCheck.position , groundCheckRadius, whatIsGround);
}

// Update is called once per frame
void Update () {
	
		accelerationFactor = acceleration + acceleration* Time.frameCount/500;

	if (!canMove) 
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
		anim.SetFloat ("Speed",0); 
		return;
		
	}
	
	if (grounded) {
		anim.SetBool ("Swirl", false);
		doubleJumped = false;
		
	}
	
	anim.SetBool ("Grounded", grounded);
	
	if (Input.GetButtonDown("Jump") && grounded)
	{
		jumpSound.pitch = 1f;
		Jump ();
		
		
	}
	
	if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded) 
	{
		anim.SetBool ("Swirl", true);
		jumpSound.pitch = 1.2f;
		Jump ();
		
		
		
		doubleJumped = true;
	}
	
	//moveVelocity = 0f;
	
		moveVelocity = moveSpeed * accelerationFactor;
	
	if (knockbackCount <= 0)
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
	} else {
		if(knockFromRight)
			myrigidbody2d.velocity = new Vector2(-knockback, knockback);
		if (!knockFromRight)
			myrigidbody2d.velocity = new Vector2(knockback, knockback);
		knockbackCount -= Time.deltaTime;
		
		
	}
	
	anim.SetFloat ("Speed",Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x)); 
		anim.speed = 1f * accelerationFactor;
	if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
		transform.localScale = new Vector3 (1f, 1f, 1f);
	} else if (GetComponent<Rigidbody2D> ().velocity.x < 0)
	{
		transform.localScale = new Vector3 (-1f, 1f, 1f);
	}
	
	if (Input.GetButtonDown("Fire1"))
	{
		shooted = true;
		//Instantiate(bullet, firePoint.position, firePoint.rotation);
		shotDelayCounter = shotDelay;
	} 
	
	if(Input.GetButton("Fire1"))
	{
		shotDelayCounter -= Time.deltaTime;
		
		if(shotDelayCounter <= 0)
		{
			shotDelayCounter = shotDelay;
			//Instantiate(bullet, firePoint.position, firePoint.rotation);
			shooted = true;
			
		}
	}
	if(Input.GetButton("Fire2"))
	{
		ulted = true;
		
	}
	
	
	//START KORUTYNY MIGANIA
	if (hitted == true) {
		StartCoroutine ("HurtBlinker");
		hurtTime -= Time.deltaTime;
		if(hurtTime <0)
		{
			hurtTime = 1;
			hitted = false;
		}
	}
}

public void Jump()
{
	GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, JumpHeight);
	jumpSound.Play();
	
}

void OnCollisionEnter2D(Collision2D other)
{
	if (other.transform.tag == "MovingPlatform") 
	{
		
		transform.parent = other.transform;
	}
}

void OnCollisionExit2D(Collision2D other)
{
	if (other.transform.tag == "MovingPlatform") 
	{
		
		transform.parent = null;
	}
}

// public void HurtCollider (cośtam)
//{
//	Start Courutine HurtBlinker(cośtam) czy jakoś takk
//}

//W TYM NADOLE HurtBlinker()  powinno być HurtBlinker(cośtam) a w yieldzie zamiast hurtTime to w nawiasie cośtam

public IEnumerator HurtBlinker()
{
	//ignore collision with enemys
	int enemyLayer = LayerMask.NameToLayer ("Enemy");
	int playerLayer = LayerMask.NameToLayer ("Player");
	
	Physics2D.IgnoreLayerCollision (enemyLayer, playerLayer);
	
	//start looping blink anim
	anim.SetLayerWeight (1, 1);
	//wait to end unvulnevjdsnble
	yield return new WaitForSeconds(hurtTime);
	//stop blinging and re-enable collision
	
	Physics2D.IgnoreLayerCollision (enemyLayer, playerLayer, false);
	anim.SetLayerWeight (1, 0);
	
	hitted = false;
}
}
