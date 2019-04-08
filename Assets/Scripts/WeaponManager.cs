using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletlvl1;
	public GameObject bulletlvl2;
	public GameObject bulletlvl3;
	public PlayerController playerController;
	public bool check;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {


			check = playerController.shooted;

			if (playerController.shooted == true) {
				check = true;
				if (ScoreManager.weaponLvl <= 1) {
					Instantiate (bulletlvl1, firePoint.position, firePoint.rotation);
					playerController.shooted = false;
				}
				if (ScoreManager.weaponLvl == 2) {
					Instantiate (bulletlvl2, firePoint.position, firePoint.rotation);
					playerController.shooted = false;
				}
				if (ScoreManager.weaponLvl >= 3) {
					Instantiate (bulletlvl3, firePoint.position, firePoint.rotation);
					playerController.shooted = false;
				}

			}
		
	
	}


}
