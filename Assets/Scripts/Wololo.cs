using UnityEngine;
using System.Collections;

public class Wololo : MonoBehaviour {

	public Sprite newImage;
	private SpriteRenderer thisSpriteRenderer;
	public GameObject Particle;
	public Transform particleStartPoint;
	public bool Wolololed;
	public bool lvl3;
	private float animationTime;
	private bool startedAnimationCo;
	// Use this for initialization
	void Start () {
		thisSpriteRenderer = GetComponent<SpriteRenderer> ();
		animationTime = 0.8f;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(lvl3 == true && Wolololed == true)
		{
			animationTime -= Time.deltaTime;
			this.GetComponent<Animator> ().SetInteger ("State", 2);
			if(animationTime <= 0)
			{
				this.GetComponent<Animator>().SetInteger("State" , 3);
			}

		} 

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		{
			if (other.name == "Player" && Wolololed == false) {
				
				Instantiate (Particle, particleStartPoint.transform.position, particleStartPoint.transform.rotation);
				GetComponent<AudioSource>().Play ();
				Wolololed = true;
				if (lvl3 == false) {
					thisSpriteRenderer.sprite = newImage;
				} else
				{
					if (startedAnimationCo == false) {
						StartCoroutine ("AnimationCo");
						startedAnimationCo = true;
					}
				}


			}
		}
	}

	public IEnumerator AnimationgCo ()
	{
		this.GetComponent<Animator> ().SetInteger ("State", 2);
		yield return new WaitForSeconds(0.5f);
		this.GetComponent<Animator>().SetInteger("State" , 3);
		startedAnimationCo = false;
	}
}
