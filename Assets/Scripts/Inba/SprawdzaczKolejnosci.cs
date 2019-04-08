using UnityEngine;
using System.Collections;

public class SprawdzaczKolejnosci : MonoBehaviour {


	public int kolejnoscPodmiotu;
	public KolejnoscScen kolejnoscScen;
	public GameObject podmiot;
	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
		kolejnoscScen = FindObjectOfType<KolejnoscScen> ();
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null)
			return;

		if (kolejnoscPodmiotu == kolejnoscScen.kolejnosc) 
		{
			podmiot.SetActive(true);
			kolejnoscScen.kolejnosc = kolejnoscScen.kolejnosc +1;
		}
	}
}
