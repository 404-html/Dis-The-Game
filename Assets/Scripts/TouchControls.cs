using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

	private PlayerController thePlayer;
	private TextBoxManager theTextBox;
	private PauseMenu pauseMenu;
	private HealthManager healthManager;
	public bool textBoxAction;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		theTextBox = FindObjectOfType<TextBoxManager> ();
		pauseMenu = FindObjectOfType<PauseMenu> ();
		healthManager = FindObjectOfType<HealthManager> ();
	}
	
	public void LeftArrow ()
	{
		thePlayer.Move (-1);
	}

	public void RightArrow ()
	{
		thePlayer.Move (1);
	}

	public void UnpressedArrow ()
	{
		thePlayer.Move (0);
	}

	public void Flame ()
	{
		if (healthManager.isDead == false) 
		{
			thePlayer.Flame ();
		}
	}

	public void Jump ()
	{
		if (theTextBox.isActive == false) {
			thePlayer.Jump ();
		} else 
		{
			textBoxAction = true;
		}
	}

	public void UnpressedJump()
	{
		//textBoxAction = false;
	}

	public void Ultimate ()
	{
		thePlayer.Ultimate();
	}

	public void Pause()
	{
		pauseMenu.isPaused = true;
	}
}
